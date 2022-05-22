

namespace WarehouseManagementDesktopApp.Core.ViewModels;
public class GoodLocationUpdateDialogViewModel : BaseViewModel
{
    public static GoodLocationUpdateDialogViewModel Instance => new GoodLocationUpdateDialogViewModel();
    private string _productId = string.Empty;
    private string _productName = string.Empty;
    private string _piecesPerKilogram = string.Empty;
    private string _minimumStockLevel = string.Empty;
    private string? _maximumStockLevel = string.Empty;
    private int _unit = 0;
    private int _itemSource = 0;
    private int selectedIndex = 0;
    private ObservableCollection<string> productNameSource = new ObservableCollection<string>();
    private ObservableCollection<string> productIdSource = new ObservableCollection<string>();

    public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
    public ObservableCollection<string> ProductIdSource { get { return productIdSource; } set { productIdSource = value; OnPropertyChanged(); } }
    public ObservableCollection<string> ProductNameSource { get { return productNameSource; } set { productNameSource = value; OnPropertyChanged(); } }
    public string ProductId { get=> _productId; set { _productId = value;OnPropertyChanged(); } }
    public string ProductName { get=> _productName; set { _productName = value; OnPropertyChanged(); } }
    public string MinimumStockLevel { get => _minimumStockLevel; set { _minimumStockLevel = value; OnPropertyChanged(); } }
    public string MaximumStockLevel { get => _maximumStockLevel; set { _maximumStockLevel = value; OnPropertyChanged(); } }

    public string PiecesPerKilogram { get => _piecesPerKilogram;set { _piecesPerKilogram = value;OnPropertyChanged(); } }
    public int Unit { get => _unit; set { _unit = value;OnPropertyChanged(); } }
    public int ItemSource { get => _itemSource; set { _itemSource = value; OnPropertyChanged(); } }
    public ICommand CompleteCommand { get; set; }
    // item1 = productname , item2 = productId
    public Action<string, string,string,string, string,int, int> Complete;

    public GoodLocationUpdateDialogViewModel()
    {
        CompleteCommand = new RelayCommand(() => Complete?.Invoke(ProductName, ProductId, PiecesPerKilogram,MinimumStockLevel,MaximumStockLevel,Unit,ItemSource));
    }
}
