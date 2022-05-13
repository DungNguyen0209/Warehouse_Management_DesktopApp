using WarehouseManagementDesktopApp.Core.Domain.Model.API;
using WarehouseManagementDesktopApp.Core.Domain.ViewModel;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
#pragma warning disable CS8618
    public class GoodReceiptOrderViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;
        private readonly IExcelExporter _excelExporter;
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;
        private string filePath;
        private bool ReadingFlag { get; set; }
        private ObservableCollection<GoodReceiptOrderForViewModel> _goodsReceiptList = new ObservableCollection<GoodReceiptOrderForViewModel>();
        public ChatMessageListDesignModel? ChatMessageList { get; set; }

        public ObservableCollection<GoodReceiptOrderForViewModel> GoodsReceiptList { get => _goodsReceiptList; set { _goodsReceiptList = value; } }
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NavigateGoodReceiptView { get; set; }
        private GoodReceiptReport goodReceiptReports;

        public ICommand UploadFile { get; set; }
        public ICommand PostServerExcel { get; set; }
        public ICommand ReloadCommand { get; set; }
        private bool postExcelFlag { get; set; }
        public string FilePath { get => filePath; set { filePath = value; OnPropertyChanged(); } }

        public bool loadFlag { get; private set; }

        public GoodReceiptOrderViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService, IExcelExporter excelExporter, ChatMessageListDesignModel chatMessageListDesignModel, IApiService apiService, IMapper mapper)
        {
            _navigationStore = navigationStore;
            _excelExporter = excelExporter;
            ChatMessageList = chatMessageListDesignModel;
            _apiService = apiService;
            _mapper = mapper;
            NavigateGoodReceiptView = new NavigateCommand(_GoodReceiptOrdernavigationService);
            UploadFile = new RelayCommand(() => ReadExcel());
            PostServerExcel = new RelayCommand(async () => PostExcelFile());
            ReloadCommand = new RelayCommand(async () => LoadUnfinishedGoodReceipt());
            LoadUnfinishedGoodReceipt();
        }

        private async void PostExcelFile()
        {
            await RunCommandAsync(postExcelFlag, async () =>
            {
                GoodReceiptEntry goodIssueEntry = new GoodReceiptEntry()
                {
                    entries = new List<EntryOfGoodReceipt>(),
                };
                goodIssueEntry.goodsReceiptId = FilePath;
                goodIssueEntry.timestamp = DateTime.Now.ToString("yyyy-MM-dd");
                goodIssueEntry.approverId = "";
                foreach (var item in GoodsReceiptList)
                {
                    EntryOfGoodReceipt miniitem = new EntryOfGoodReceipt() { itemId = item.ProductId };
                    if (!String.IsNullOrEmpty(item.Mass))
                    {
                        miniitem.TotalQuantity = Convert.ToInt16(item.Mass);
                    }
                    else
                    {
                        miniitem.TotalQuantity = Convert.ToInt16(item.Quantity);
                    }
                    goodIssueEntry.entries.Add(miniitem);
                }
                var result = await _apiService.PostGoodsReceipts(goodIssueEntry);
                if (result.Success)
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        IsWarning = false,
                        ContentText = "Truy xuất thành công"
                    };
                    messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    messageBox.Show();
                    GoodsReceiptList.Clear();
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        IsWarning = true,
                        ContentText = "Lỗi Trong Qúa Trình Truy Xuất Server"
                    };
                    messageBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    messageBox.Show();
                }
            });
        }

        private void ReadExcel()
        {
            ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> response = _excelExporter.ReadReceipt();
            foreach (var item in response.Resource)
            {
                GoodsReceiptList.Add(item);
            }
            FilePath = _excelExporter.FilePath;
        }
        private async void LoadUnfinishedGoodReceipt()
        {
            await RunCommandAsync(loadFlag, async () =>
            {
                var result = await _apiService.GetUnfinishedGoodsReceipt(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(1));
                if (result.Success)
                {
                    if (result.Success)
                    {
                        ChatMessageList.Items.Clear();
                        var messageList = new ChatMessageListDesignModel();
                        goodReceiptReports = result.Resource;
                        foreach (var item in goodReceiptReports.items)
                        {
                            ChatMessageListItemDesignModel messageitem = new ChatMessageListItemDesignModel
                            {
                                Id = item.goodsReceiptId,
                                Message = "Đơn nhập kho " + item.goodsReceiptId,
                                MessageSentTime = (DateTimeOffset)item.timestamp,
                                ProfilePictureRGB = "3099c5",
                                SentByMe = true,
                            };
                            messageList.Items.Add(messageitem);
                        }
                        ChatMessageList = messageList;
                        foreach (var item in ChatMessageList.Items)
                        {
                            item.ClickEvent += LoadReceipt;
                        }
                    }
                }
            });
        }

        private void LoadReceipt(string Id)
        {
            ObservableCollection<GoodReceiptOrderForViewModel> goodReceiptOrderlist = new ObservableCollection<GoodReceiptOrderForViewModel>();
            var result = goodReceiptReports.items.Where(S => S.goodsReceiptId == Id).ToList();
            int i = 1;
            foreach (var item in result.Last().entries)
            {
                if (item.item.unit == EUnit.Kilogram)
                {

                    var gooditem = new GoodReceiptOrderForViewModel()
                    {
                        Id = Convert.ToString(i++),
                        ProductId = item.item.itemId,
                        ProductName = item.item.name,
                        Mass = CaculateRecepitQuantity(item.containers),
                        Quantity ="",
                        Infomartion = item.note
                    };
                    goodReceiptOrderlist.Add(gooditem);
                }
                else
                {
                    var gooditem = new GoodReceiptOrderForViewModel()
                    {
                        Id = Convert.ToString(i++),
                        ProductId = item.item.itemId,
                        ProductName = item.item.name,
                        Quantity = CaculateRecepitQuantity(item.containers),
                        Infomartion = item.note,
                        Mass =""
                    };
                    goodReceiptOrderlist.Add(gooditem);
                }
            }

            GoodsReceiptList = goodReceiptOrderlist;
        }
        private string CaculateRecepitQuantity(List<ContainerOfGoodReceiptReport> containers)
        {
            double Sum = 0;
            foreach (var item in containers)
            {
                Sum += item.actualQuantity;
            }
            return Sum.ToString();
        }
    }
#pragma warning restore
    }
