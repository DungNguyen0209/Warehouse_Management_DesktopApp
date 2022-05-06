

namespace WarehouseManagementDesktopApp.Core.ViewModels;
public class GoodLocationUpdateDialogViewModel : BaseViewModel
{
    public static GoodLocationUpdateDialogViewModel Instance => new GoodLocationUpdateDialogViewModel();
    private string _productId = string.Empty;
    private string _productName = string.Empty;
    public string ProductId { get=> _productId; set { _productId = value;OnPropertyChanged(); } }
    public string ProductName { get=> _productName; set { _productName = value; OnPropertyChanged(); } }
    public ICommand CompleteCommand { get; set; }
    // item1 = productname , item2 = productId
    public Action<string, string> Complete;

    public GoodLocationUpdateDialogViewModel()
    {
        CompleteCommand = new RelayCommand(() => Complete?.Invoke(ProductName, ProductId));
    }
}
