
using Persistence.SqliteDB.Domain.Interfaces;
using Persistence.SqliteDB.Model;
using WarehouseManagementDesktopApp.Core.Domain.ViewModel;

#pragma warning disable CS8618
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodReceiptViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly IProductsDatabaseService _productsDatabaseService;
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;
        private readonly GoodReceiptNavigationStore _navigationStore;
        private int _selected;

        private string _basketId;
        private string _productId;
        private string _productName;
        private string _productionDate;
        private string? _plannedQuantity;
        private string? _actualQuantity;
        private string? c;
        private string? _goodReceiptId;
        private string _unit;
        private int _selectedTarget = 0;
        public string BasketId { get => _basketId; set { _basketId = value; OnPropertyChanged(); } }
        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }
        public string GoodReceiptId { get => _goodReceiptId; set { _goodReceiptId = value; OnPropertyChanged(); } }
        public string ProductId { get => _productId; set { _productId = value; OnPropertyChanged(); } }

        public string ProductName { get => _productName; set { _productName = value; OnPropertyChanged(); } }

        public string ProductionDate { get => _productionDate; set { _productionDate = value; OnPropertyChanged(); } }
        public string? PlannedQuantity { get => _plannedQuantity; set { _plannedQuantity = value; OnPropertyChanged(); } }
        public string? ActualQuantity { get => _actualQuantity; set { _actualQuantity = value; OnPropertyChanged(); } }
        public string Unit { get => _unit; set { _unit = value; OnPropertyChanged(); } }
        public int SelectedTarget { get => _selectedTarget; set { _selectedTarget = value; OnPropertyChanged(); } }
        private int selectedUnit = 0;
        public int SelectedUnit { get => selectedUnit; set { selectedUnit = value; OnPropertyChanged(); } }
        private bool saveFlag { get; set; }
        private bool addFlag { get; set; }
        private bool searchFlag { get; set; }
        private bool finishFlag { get; set; }
        private bool uploadFlag { get; set; }
        private ObservableCollection<GoodsReceiptForViewModel> _goodsReceiptList = new ObservableCollection<GoodsReceiptForViewModel>();
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ObservableCollection<GoodsReceiptForViewModel> GoodsReceiptList { get => _goodsReceiptList; set { _goodsReceiptList = value; } }
        public int SelectedIndexItem
        {
            get => _selected; set
            {

                _selected = value;

                InformationChanged();
            }
        }
        public AutoCompleteTextBoxViewModel AutoCompleteTextBoxDC { get; set; }

        public ICommand NavigateGoodReceiptOrderView { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectionCommand { get; set; }
        public ICommand FinishCommand { get; set; }
        public GoodReceiptViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService, IProductsDatabaseService productsDatabaseService, IApiService apiService, IMapper mapper)
        {
            _navigationStore = navigationStore;
            _productsDatabaseService = productsDatabaseService;
            _mapper = mapper;
            NavigateGoodReceiptOrderView = new NavigateCommand(_GoodReceiptOrdernavigationService);
            AutoCompleteTextBoxDC = new AutoCompleteTextBoxViewModel() { HintText = "Tên SP" };
            AutoCompleteTextBoxDC.TextChanged += CheckTextSource;
            GoodsReceiptList = new ObservableCollection<GoodsReceiptForViewModel>();
            //GoodsReceiptForViewModel goodsReceipt = new GoodsReceiptForViewModel { BasketId = "basket1", ProductId = "123", ProductName = "SP_A", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            //GoodsReceiptForViewModel goodsReceipt1 = new GoodsReceiptForViewModel { BasketId = "basket2", ProductId = "1234", ProductName = "SP_B", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            //GoodsReceiptForViewModel goodsReceipt2 = new GoodsReceiptForViewModel { BasketId = "basket3", ProductId = "123", ProductName = "SP_C", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            //GoodsReceiptList.Add(goodsReceipt);
            //GoodsReceiptList.Add(goodsReceipt1);
            //GoodsReceiptList.Add(goodsReceipt2);
            SaveCommand = new RelayCommand(async () => await Save());
            SearchCommand = new RelayCommand(async () => await Search());
            AddProductCommand = new RelayCommand(async () => await Add());
            DeleteCommand = new RelayCommand(async () => Delete());
            FinishCommand = new RelayCommand(async () => Finish());
            _apiService = apiService;
        }

        private async Task Finish()
        {
            await RunCommandAsync(finishFlag, async () =>
            {
                List<ContainerGoodReceipt> receiptlist = new List<ContainerGoodReceipt>();
                foreach (var item in GoodsReceiptList)
                {
                    receiptlist.Add(_mapper.Map<ContainerGoodReceipt>(item));
                }
                var patchcontainer = await _apiService.PatchContainerGoodsReceipts(receiptlist, GoodReceiptId);
                if (patchcontainer.Success)
                {
                    var confirm = await _apiService.PatchConFirmGoodsReceipts(GoodReceiptId);
                    if (confirm.Success)
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = "Nhập kho thành công !",
                            IsWarning = false
                        };
                        messageBox.Show();
                        GoodsReceiptList.Clear();
                        OnPropertyChanged("GoodsReceiptList");
                    }
                    else
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = "Xác nhận đơn nhập kho thất bại !",
                            IsWarning = true
                        };
                        messageBox.Show();
                    }
                }
                else
                {
                    var confirm = await _apiService.PatchConFirmGoodsReceipts(GoodReceiptId);
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Kiểm tra lại thông tin rổ !",
                        IsWarning = true
                    };
                    messageBox.Show();
                }
            });
        }

        private async void Delete()
        {
            GoodsReceiptList.RemoveAt(SelectedIndexItem);
        }

        private async Task Search()
        {
            await RunCommandAsync(searchFlag, async () =>
            {

                var requestItem = await _apiService.GetProductbyId(AutoCompleteTextBoxDC.Text);
                if (requestItem.Success)
                {
                    if (requestItem.Resource == null)
                    {
                        MessageBox messageBox = new MessageBox()
                        {
                            ContentText = "Mã Sản Phẩm này không tồn tại",
                            IsWarning = true,
                        };
                        messageBox.Show();
                    }
                    else
                    {
                        ProductName = requestItem.Resource.name;
                        SelectedUnit = (int)requestItem.Resource.unit;
                    }
                }
            });
        }

        private async Task Add()
        {
            if (GoodsReceiptList.Any(s => s.containerId == BasketId))
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = "Trùng thông tin mã rổ !",
                    IsWarning = true
                };
                messageBox.Show();
            }
            else
            {

                GoodsReceiptForViewModel item = new GoodsReceiptForViewModel()
                {
                    containerId = BasketId,
                    itemId = AutoCompleteTextBoxDC.Text,
                    name = ProductName,
                    ProductionDate = this.Date.ToString("yyyy-MM-dd"),
                    plannedQuantity = PlannedQuantity,
                    actualQuantity = ActualQuantity,
                    Unit = Convert.ToString(this.Unit),

                };
                GoodsReceiptList.Add(item);
                OnPropertyChanged("GoodsReceiptList");
            }
        }

        private async void CheckTextSource()
        {
            AutoCompleteTextBoxDC.SuggestionSource.Clear();
            string typedString = AutoCompleteTextBoxDC.Text;
            ObservableCollection<string> autoList = new ObservableCollection<string>();
            autoList.Clear();

            if (!string.IsNullOrEmpty(AutoCompleteTextBoxDC.Text))
            {
#pragma warning disable CS8602
                var productlist = await _productsDatabaseService.LoadSuggestName(typedString);
#pragma warning restore
                if (productlist != null)
                {
                    foreach (var item in productlist)
                    {
                        autoList.Add(item.IdProduct);
                    }
                    AutoCompleteTextBoxDC.SuggestionSource = autoList;

                }

            }

        }

        private async Task Save()
        {
            await RunCommandAsync(saveFlag, async () =>
            {
                await Task.Delay(1);
                GoodsReceiptList[SelectedIndexItem].plannedQuantity = PlannedQuantity;
                GoodsReceiptList[SelectedIndexItem].actualQuantity = ActualQuantity;
                GoodsReceiptList[SelectedIndexItem].containerId = BasketId;

                CollectionViewSource.GetDefaultView(GoodsReceiptList).Refresh();

            });
        }
        private async void InformationChanged()
        {
            await RunCommandAsync(saveFlag, async () =>
            {
                await Task.Delay(1);

                BasketId = _goodsReceiptList[SelectedIndexItem].containerId;
                ProductId = _goodsReceiptList[SelectedIndexItem].itemId;
                ProductName = _goodsReceiptList[SelectedIndexItem].name;
                PlannedQuantity = _goodsReceiptList[SelectedIndexItem].plannedQuantity;
                ActualQuantity = _goodsReceiptList[SelectedIndexItem].actualQuantity;
                Date = Convert.ToDateTime(_goodsReceiptList[SelectedIndexItem].ProductionDate);

            });
        }

    }
}
#pragma warning restore CS8618
