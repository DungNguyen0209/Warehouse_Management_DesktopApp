namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class UpdateGoodLocationViewModel : BaseViewModel
{
    public ICommand SearchCommand { get; set; }
    private string _row;
    private string _column;
    private string _depth;
    private bool _isDialogOpen = false;
    private int id { get; set; }
    public bool IsDialogOpen { get { return _isDialogOpen; } set { _isDialogOpen = value; OnPropertyChanged(); } }
    public string Row { get => _row; set { _row = value; OnPropertyChanged(); } }
    public string Column { get => _column; set { _column = value; OnPropertyChanged(); } }

    public string Depth { get => _depth; set { _depth = value; OnPropertyChanged(); } }
    public LocationCardItemListViewModel LocationCardItemList { get; set; }
    public GoodLocationUpdateDialogViewModel GoodLocationUpdateDialog { get; set; }
    public UpdateGoodLocationViewModel()
    {
        SearchCommand = new RelayCommand(() => TextAddImage());
        LocationCardItemList = new LocationCardItemListViewModel();
        LocationCardItemList.ClickItem += OpenDialog;
        GoodLocationUpdateDialog = new GoodLocationUpdateDialogViewModel();
        GoodLocationUpdateDialog.Complete += UpdateItem;
    }

    private void UpdateItem(string productName, string productId)
    {
        LocationCardItemList.Items[id].ProductId = productId;
        LocationCardItemList.Items[id].ProductName = productName;
    }

    private void OpenDialog(int id)
    {
        IsDialogOpen = true;
        this.id = id;
        GoodLocationUpdateDialog.ProductId = LocationCardItemList.Items[id].ProductId;
        GoodLocationUpdateDialog.ProductName = LocationCardItemList.Items[id].ProductName;
    }

    public Action<int, int, int> AddImageEvent;
    private void TextAddImage()
    {
        // AddImageEvent?.Invoke(Convert.ToInt32(_row), Convert.ToInt32(_column), Convert.ToInt32(_depth));
        AddImageEvent.Invoke(8, 8, 8);
    }
}
