using System.Windows.Controls;
using WarehouseManagementDesktopApp.Core.Service.ComponentUIServices;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class UpdateGoodLocationViewModel : BaseViewModel
{
    public ICommand SearchCommand { get; set; }
    private string _row;
    private string _column;
    private string _depth;
    private bool _isDialogOpen = false;
    private ContentControl _contentControl = new ContentControl();
    private double _width;
    private double _height;

    private int id { get; set; }
    public bool IsDialogOpen { get { return _isDialogOpen; } set { _isDialogOpen = value; OnPropertyChanged(); } }
    public string Row { get => _row; set { _row = value; OnPropertyChanged(); } }
    public string Column { get => _column; set { _column = value; OnPropertyChanged(); } }

    public string Depth { get => _depth; set { _depth = value; OnPropertyChanged(); } }
    public LocationCardItemListViewModel LocationCardItemList { get; set; }
    public GoodLocationUpdateDialogViewModel GoodLocationUpdateDialog { get; set; }
    public event EventHandler<List<int>> AddImageEvent;
    public double HeightOfContent { get => _height; set { _height = value;OnPropertyChanged(); }}
    public double WidthOfContent { get =>_width; set { _width = value;OnPropertyChanged(); }}
    public ContentControl Content { get => _contentControl; set { _contentControl = value; OnPropertyChanged(); } }


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
    private void TextAddImage()
    {
        Canvas panel = new Canvas()
        {
            Height = 847.04,
            Width = 442.04
        };
        Button button = new Button();
        panel.Children.Add(button);
        Content.Content = panel;
        Content.Content = UpdatUI(panel, new List<int> { 8, 8, 8 });
        // AddImageEvent?.Invoke(Convert.ToInt32(_row), Convert.ToInt32(_column), Convert.ToInt32(_depth));
        AddImageEvent?.Invoke(this, new List<int> { 8,8,8});
    }
    private Canvas UpdatUI(Canvas panel, List<int> data)
    {
        panel.Children.Clear();
        var row = data[0];
        var column = data[1];
        var depth = data[2];
        int halfofdepth = depth / 2;
        for (int j = 1; j <= row; j++)
        {

            for (int k = 1; k <= column; k++)
            {
                double marginright = (panel.Width - column * 60 + 30 * (column - 1)) / 2 + (k - 1) * 50;
                double marginbottom = (panel.Height - row * 50) / 2 + (j - 1) * 25 +200;
                CubeGenerate.CreateBasketForUpdateLocation(panel, marginright, marginbottom);
            }
        }
        return panel;
    }
}
