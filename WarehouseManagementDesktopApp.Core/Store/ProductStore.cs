namespace WarehouseManagementDesktopApp.Core.Store;

public class ProductStore : BaseViewModel
{
    private ObservableCollection<string> _productName = new ObservableCollection<string>();
    private ObservableCollection<string> _productId = new ObservableCollection<string>();
    public ObservableCollection<string> ProductName
    {
        get => _productName;
        set
        {
            _productName = value;
            OnPropertyChanged();
            ProductChanged();
        }
    }

    public ObservableCollection<string> ProductId
    {
        get => _productId;
        set
        {

            _productId = value;
            OnPropertyChanged();
            ProductChanged();
        }
    }
    public event Action ProductUpdate;

    public void ProductChanged()
    {
        if (ProductName.Count() > 0 && ProductId.Count() > 0)
        {
            ProductUpdate?.Invoke();
        }
    }
}
