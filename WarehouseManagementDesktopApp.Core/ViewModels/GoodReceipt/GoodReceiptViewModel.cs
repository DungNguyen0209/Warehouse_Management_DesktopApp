
using Persistence.SqliteDB.Domain.Interfaces;
using Persistence.SqliteDB.Model;
using WarehouseManagementDesktopApp.Core.Domain.ViewModel;

#pragma warning disable CS8618
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodReceiptViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly IProductsDatabaseService _productsDatabaseService;
        private readonly IApiService _apiService;
        private readonly GoodReceiptNavigationStore _navigationStore;
        private int _selected;
        
        private string _basketId;
        private string _productId;
        private string _productName;
        private string _productionDate;
        private string? _currentquantity;
        private string? _mass;
        private string _unit;  
        private int _selectedTarget = 0;
        public string BasketId { get => _basketId; set { _basketId = value;OnPropertyChanged(); } }

        public string ProductId { get => _productId; set { _productId = value;OnPropertyChanged(); } }
        
        public string ProductName { get => _productName; set { _productName = value; OnPropertyChanged(); } }

        public string ProductionDate { get => _productionDate; set { _productionDate = value; OnPropertyChanged(); } }
        public string? CurrentQuantity { get => _currentquantity; set { _currentquantity = value; OnPropertyChanged(); } }
        public string? Mass { get => _mass; set { _mass = value; OnPropertyChanged(); } }
        public string Unit { get => _unit; set { _unit = value; OnPropertyChanged(); } }
        public int SelectedTarget { get => _selectedTarget; set { _selectedTarget = value; OnPropertyChanged(); } }
        private bool saveFlag { get; set; }
        private bool addFlag { get; set; }
        private bool searchFlag { get; set; }
        private bool uploadFlag { get; set; }
        private ObservableCollection<GoodsReceiptForViewModel> _goodsReceiptList = new ObservableCollection<GoodsReceiptForViewModel>();
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ObservableCollection<GoodsReceiptForViewModel> GoodsReceiptList { get => _goodsReceiptList; set { _goodsReceiptList = value;}}
        public int SelectedIndexItem { get => _selected; set { _selected = value; InformationChanged(); } }
        public AutoCompleteTextBoxViewModel AutoCompleteTextBoxDC { get; set; }

        public ICommand NavigateGoodReceiptOrderView { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand UploadCommand { get; set; }
        public ICommand SelectionCommand { get; set; }
        public GoodReceiptViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService, IProductsDatabaseService productsDatabaseService, IApiService apiService)
        {
            _navigationStore = navigationStore;
            _productsDatabaseService = productsDatabaseService;
            NavigateGoodReceiptOrderView = new NavigateCommand(_GoodReceiptOrdernavigationService);
            AutoCompleteTextBoxDC = new AutoCompleteTextBoxViewModel() { HintText = "Tên SP" };
            AutoCompleteTextBoxDC.TextChanged += CheckTextSource;
            GoodsReceiptList = new ObservableCollection<GoodsReceiptForViewModel>();
            GoodsReceiptForViewModel goodsReceipt = new GoodsReceiptForViewModel { BasketId = "basket1", ProductId = "123", ProductName = "SP_A", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            GoodsReceiptForViewModel goodsReceipt1 = new GoodsReceiptForViewModel { BasketId = "basket2", ProductId = "1234", ProductName = "SP_B", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            GoodsReceiptForViewModel goodsReceipt2 = new GoodsReceiptForViewModel { BasketId = "basket3", ProductId = "123", ProductName = "SP_C", ProductionDate = "22-2-2222", Quantity = "100", Mass = "100", Unit = "KG" };
            GoodsReceiptList.Add(goodsReceipt);
            GoodsReceiptList.Add(goodsReceipt1);
            GoodsReceiptList.Add(goodsReceipt2);
            SaveCommand = new RelayCommand(async () => await Save());
            _apiService = apiService;
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
                if(productlist!= null)
                {
                foreach (var item in productlist)
                {
                    autoList.Add(item.Name);
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
                GoodsReceiptList[SelectedIndexItem].Quantity = CurrentQuantity;
                CollectionViewSource.GetDefaultView(GoodsReceiptList).Refresh();

            });
        }
        private async void InformationChanged()
        {
            await RunCommandAsync(saveFlag, async () =>
            {
                await Task.Delay(1);

                BasketId = _goodsReceiptList[SelectedIndexItem].BasketId;
                ProductId = _goodsReceiptList[SelectedIndexItem].ProductId;
                ProductName = _goodsReceiptList[SelectedIndexItem].ProductName;
                CurrentQuantity = _goodsReceiptList[SelectedIndexItem].Quantity;
                ProductionDate = _goodsReceiptList[SelectedIndexItem].ProductionDate;
                Mass = _goodsReceiptList[SelectedIndexItem].Mass;
                Unit = _goodsReceiptList[SelectedIndexItem].Unit;


            });
        }

    }
}
#pragma warning restore CS8618
