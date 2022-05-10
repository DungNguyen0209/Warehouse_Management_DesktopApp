using System.Windows.Controls;
using MessageBox = WarehouseManagementDesktopApp.Core.ComponentUI.MessageBox;
using WarehouseManagementDesktopApp.Core.Service.ComponentUIServices;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class UpdateGoodLocationViewModel : BaseViewModel
{
    private readonly IApiService _apiService;
    public ICommand SearchCommand { get; set; }
    private string _row;
    private string _column;
    private string _depth;
    private bool _isDialogOpen = false;
    private ContentControl _contentControl = new ContentControl();
    private double _width;
    private double _height;
    private int id { get; set; }
    private bool SearchFlag { get; set; }
    public bool IsDialogOpen { get { return _isDialogOpen; } set { _isDialogOpen = value; OnPropertyChanged(); } }
    public string Row { get => _row; set { _row = value; OnPropertyChanged(); } }
    public string Column { get => _column; set { _column = value; OnPropertyChanged(); } }
    // Enable Choose Location
    //private bool _isEditable = false;
    //public bool IsEditable { get => _isEditable; set { _isEditable = value; OnPropertyChanged(); } }
    private string _selfId = string.Empty;
    public string SelfId { get => _selfId; set { _selfId = value; OnPropertyChanged(); } }
    //RowId
    private string _rowId = string.Empty;
    public string RowId
    {
        get => _rowId;
        set
        {
            if (int.TryParse(value, out _))
            {
                _rowId = value;
                OnPropertyChanged();
            }
            else
            {
                value = string.Empty;
            }
        }
    }
    //CellId
    private string _cellId = string.Empty;
    public string CellId
    {
        get => _cellId;
        set
        {
            if (int.TryParse(value, out _))
            {
                _cellId = value;
                OnPropertyChanged();

            }
            else
            {
                value = string.Empty;
            }
        }
    }
    public string Depth { get => _depth; set { _depth = value; OnPropertyChanged(); } }
    public LocationCardItemListViewModel LocationCardItemList { get; set; }
    public GoodLocationUpdateDialogViewModel GoodLocationUpdateDialog { get; set; }
    public event EventHandler<List<int>> AddImageEvent;
    private Shelf ShelfInformation { get; set; }
    public double HeightOfContent { get => _height; set { _height = value; OnPropertyChanged(); } }
    public double WidthOfContent { get => _width; set { _width = value; OnPropertyChanged(); } }
    public ContentControl Content { get => _contentControl; set { _contentControl = value; OnPropertyChanged(); } }


    public UpdateGoodLocationViewModel(IApiService apiService)
    {
        _apiService = apiService;
        ShelfInformation = new Shelf() { shelfId = "" };
        SearchCommand = new RelayCommand(async () => SearchSelf());
        LocationCardItemList = new LocationCardItemListViewModel();
        GoodLocationUpdateDialog = new GoodLocationUpdateDialogViewModel();
        GoodLocationUpdateDialog.Complete += UpdateItem;
    }

    private async void SearchSelf()
    {
        await RunCommandAsync(SearchFlag, async () =>
        {

            if (!String.IsNullOrEmpty(SelfId) && ShelfInformation.shelfId != SelfId)
            {
                var self = await _apiService.GetShelf(SelfId);
                if (self.Success)
                {
                    ShelfInformation = self.Resource;
                    if (!String.IsNullOrEmpty(CellId) && !String.IsNullOrEmpty(RowId))
                    {
                        var cell = ShelfInformation.cells.Where(x => x.id == Convert.ToInt16(CellId) && x.rowId == Convert.ToInt16(RowId)).ToList().Last();
                        TextAddImage(cell.slices.First().slots.Last().levelId, cell.slices.Count(), cell.slices.First().slots.Last().id, cell);
                    }

                }
                else
                {
                    MessageBox messageBox = new MessageBox
                    {
                        IsWarning = true,
                        ContentText = self.Error.Message,
                    };
                    messageBox.Show();
                }
            }



        });
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
    private void TextAddImage(int row, int column, int depth, Cell cell)
    {
        if (row != null && column != null && depth != null)
        {

            Canvas panel = new Canvas()
            {
                Height = 847.04,
                Width = 442.04
            };
            Button button = new Button();
            panel.Children.Add(button);
            Content.Content = panel;
            Content.Content = UpdatUI(panel, new List<int> { row, column, depth });

            // AddImageEvent?.Invoke(Convert.ToInt32(_row), Convert.ToInt32(_column), Convert.ToInt32(_depth));
            AddImageEvent?.Invoke(this, new List<int> { row, column, depth });
            LocationCardItemList.Items.Clear();
            if (cell != null)
            {
                ObservableCollection<LocationCardItemViewModel> locationList = new ObservableCollection<LocationCardItemViewModel>();
                foreach (var item in cell.slices)
                {
                    LocationCardItemViewModel card = new LocationCardItemViewModel()
                    {
                        ProductId = item.item.itemId,
                        ProductName = item.item.name,
                        Id = item.id,
                        Collumn = "Hàng" + Convert.ToString(item.id),
                        IsEmptySpace = cell.slices.Any(a => a.slots.Any(b => b.containerId == null))
                    };
                    locationList.Add(card);

                }
                LocationCardItemList.Items = locationList;
                LocationCardItemList.ClickItem += OpenDialog;
            }
        }
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
                double marginbottom = (panel.Height - row * 50) / 2 + (j - 1) * 25 + 200;
                CubeGenerate.CreateBasketForUpdateLocation(panel, marginright, marginbottom);
            }
        }
        return panel;
    }
}
