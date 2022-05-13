using WarehouseManagementDesktopApp.Core.Domain.View.Report;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;
        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }
        private DateTime _stopDate = DateTime.Now;
        public DateTime StopDate
        {
            get { return _stopDate; }
            set { _stopDate = value; OnPropertyChanged(); }
        }
        private int _selectedMode = 0;
        public ChatMessageListDesignModel? ChatMessageList { get; set; }
        private RangeObservableCollection<GoodDataGrid> _goodDataGrids = new RangeObservableCollection<GoodDataGrid>();
        public RangeObservableCollection<GoodDataGrid> GoodsList { get=> _goodDataGrids; set { _goodDataGrids = value;OnPropertyChanged(); } }
        private GoodReceiptReport goodReceiptReports;
        private GoodExportReport GoodExportReport;
        public int SelectedMode { get { return _selectedMode; } set { _selectedMode = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public bool Flag { get; private set; }

        public ReportViewModel(IApiService apiService)
        {
            _apiService = apiService;
            ChatMessageList = new ChatMessageListDesignModel();
            SearchCommand = new RelayCommand(() => Search());
        }

        private async void Search()
        {
            await RunCommandAsync(Flag, async () =>
            {
                switch (SelectedMode)
                {
                    case 0:
                        {
                            var result = await _apiService.GetGoodsReceipt(StartDate, StopDate);
                            if (result.Success)
                            {
                                ChatMessageList.Items.Clear();
                                var messageList = new ChatMessageListDesignModel();
                                goodReceiptReports = result.Resource;
                                foreach(var item in goodReceiptReports.items)
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
                                foreach(var item in ChatMessageList.Items)
                                {
                                    item.ClickEvent += LoadReceipt;
                                }
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Thành Công",
                                    IsWarning = false,
                                };
                                messageBox.Show();
                                break;
                            }
                            else
                            {
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Truy xuất không thành Công",
                                    IsWarning = true,
                                };
                                messageBox.Show();
                                break;
                            }
                        }
                    case 1:
                        {
                            var result = await _apiService.GetGoodsIssue(StartDate, StopDate);
                            if (result.Success)
                            {
                                ChatMessageList.Items.Clear();
                                var messageList = new ChatMessageListDesignModel();
                                GoodExportReport = result.Resource;
                                foreach (var item in GoodExportReport.items)
                                {
                                    ChatMessageListItemDesignModel messageitem = new ChatMessageListItemDesignModel
                                    {
                                        Id = item.goodsIssueId,
                                        Message = "Đơn xuất kho " + item.goodsIssueId,
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
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Thành Công",
                                    IsWarning = false,
                                };
                                messageBox.Show();
                                break;
                            }
                            else
                            {
                                MessageBox messageBox = new MessageBox()
                                {
                                    ContentText = "Truy xuất không thành Công",
                                    IsWarning = true,
                                };
                                messageBox.Show();
                                break;
                            }
                        }
                }
            });
        }

        private void LoadReceipt(string Id)
        {
            if(SelectedMode == 0)
            {
            var result = goodReceiptReports.items.Where(S => S.goodsReceiptId == Id).ToList();
            int i = 1;
            RangeObservableCollection<GoodDataGrid> datalist = new RangeObservableCollection<GoodDataGrid>();
            foreach (var item in result.Last().entries)
            {
                var gooditem = new GoodDataGrid()
                {
                    Id = Convert.ToString(i++),
                    ProductId = item.item.itemId,
                    ProductName = item.item.name,
                    TotalQuantity = CaculateRecepitQuantity(item.containers)

                };
                datalist.Add(gooditem);
            }

            GoodsList = datalist;
            }
            else
            {
                var result = GoodExportReport.items.Where(S => S.goodsIssueId == Id).ToList();
                int i = 1;
                RangeObservableCollection<GoodDataGrid> datalist = new RangeObservableCollection<GoodDataGrid>();
                foreach (var item in result.Last().entries)
                {
                    var gooditem = new GoodDataGrid()
                    {
                        Id = Convert.ToString(i++),
                        ProductId = item.item.itemId,
                        ProductName = item.item.name,
                        TotalQuantity = CaculateIssueQuantity(item.containers)

                    };
                    datalist.Add(gooditem);
                }

                GoodsList = datalist;
            }
        }
        private string CaculateRecepitQuantity(List<ContainerOfGoodReceiptReport> containers)
        {
            double Sum = 0;
            foreach(var item in containers)
            {
                Sum += item.actualQuantity;
            }
            return Sum.ToString();
        }
        private string CaculateIssueQuantity(List<ContainerOfGoodExportReport> containers)
        {
            double Sum = 0;
            foreach (var item in containers)
            {
                if(item.isTaken)
                {

                Sum += item.quantity;
                }
            }
            return Sum.ToString();
        }
    }
}
