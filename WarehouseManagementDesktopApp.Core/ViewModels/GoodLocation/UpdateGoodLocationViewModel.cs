using System.Windows.Controls;
using MessageBox = WarehouseManagementDesktopApp.Core.ComponentUI.MessageBox;
using WarehouseManagementDesktopApp.Core.Service.ComponentUIServices;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class UpdateGoodLocationViewModel : BaseViewModel
{
    private readonly IApiService _apiService;
    public ICommand SearchCommand { get; set; }
    public ICommand ConfirmCommand { get; set; }
    private string _row;
    private string _column;
    private string _depth;
    private bool _isDialogOpen = false;
    private ContentControl _contentControl = new ContentControl();
    private double _width;
    private double _height;
    private int ChoosenSliceIdOfCell { get; set; }
    private bool SearchFlag { get; set; }
    private bool ConfirmFlag { get; set; }
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
    //List help to contain the item have update
    public List<UpdateSliceItem> UpdateitemSource { get; set; }
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
        ConfirmCommand = new RelayCommand(async () => UpdateGood());
        LocationCardItemList = new LocationCardItemListViewModel();
        GoodLocationUpdateDialog = new GoodLocationUpdateDialogViewModel();
        UpdateitemSource = new List<UpdateSliceItem>();
        GoodLocationUpdateDialog.Complete += UpdateItem;
    }

    private async void UpdateGood()
    {
        List<int> idsliceError = new List<int>();
        List<int> idsliceComplete = new List<int>();
        await RunCommandAsync(ConfirmFlag, async () =>
        {
            foreach (var item in UpdateitemSource)
            {
                var result = await _apiService.PathSliceItem(item.shelfId, item.rowId, item.cellId, item.slices, item.itemid);
                if (result.Success)
                {
                    idsliceComplete.Add(item.slices);
                }
                else
                {
                    idsliceError.Add(item.slices);
                }
            }
        });
        if (idsliceComplete.Count() > 0)
        {
            foreach(var id in idsliceComplete)
            {
                UpdateitemSource.RemoveAll(x => x.slices == id);
            };
            MessageBox messageBox = new MessageBox()
            {
                ContentText = "Cập Nhật Thành Công",
                IsWarning = false
            };
            messageBox.Show();
        }
        else
        {
            MessageBox messageBox = new MessageBox()
            {
                ContentText = ReturnErrorMessage(idsliceError),
                IsWarning = true
            };
            messageBox.Show();
        }
    }
    private string ReturnErrorMessage(List<int> sliceError)
    {
        string message = "Cập Nhật Không Thành Công";
        foreach (var item in sliceError)
        {
            message += " Lớp " + Convert.ToString(item) + " + ";
        }
        return message;
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
                        var cell = ShelfInformation.cells.Where(x => x.id == Convert.ToInt16(CellId) && x.rowId == Convert.ToInt16(RowId)).ToList().Last();
                    if (cell.slices.Count()>0)
                    {
                        TextAddImage(cell.slices.First().slots.Last().levelId, cell.slices.Count(), cell.slices.First().slots.Last().id, cell);
                    }
                    else
                    {
                        Clear3DAndCard();
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
                    Clear3DAndCard();
                }
            }



        });
    }

    private async void UpdateItem(string productName, string productId, string piecesPerKilogram, int unit, int itemSource)
    {
        //NewProduct newitem = new NewProduct
        //{
        //    itemId = productId,
        //    name = productName,
        //    piecesPerKilogram = Convert.ToInt32(piecesPerKilogram),
        //    unit = (EUnit)unit,
        //    itemSource = (EItemSource)itemSource,
        //    managerId = "nhmdung"
        //};
        //var responenewitem =await _apiService.PostNewProduct(newitem);
        //if (responenewitem.Success)
        //{
        //    MessageBox messageBox = new MessageBox()
        //    {
        //        ContentText = "Tạo sản phẩm mới thành công",
        //        IsWarning = false,
        //    };
        //    messageBox.Show();
        //    LocationCardItemList.Items.FirstOrDefault(x => x.Id == this.id).ProductId = productId;
        //    LocationCardItemList.Items.FirstOrDefault(x => x.Id == this.id).ProductName = productName;
        //    UpdateSliceItem sliceItem = new UpdateSliceItem()
        //    {
        //        shelfId = ShelfInformation.shelfId,
        //        rowId = Convert.ToInt16(RowId),
        //        cellId = Convert.ToInt16(CellId),
        //        itemid = productId,
        //    };
        //    bool isduplicate = Updateitems.Any(s => s == sliceItem);
        //    if(isduplicate)
        //    {
        //    Updateitems.Add(sliceItem);
        //    }


        //}
        //else
        //{
        //    MessageBox messageBox = new MessageBox()
        //    {
        //        ContentText = "Tạo sản phẩm mới thành công",
        //        IsWarning = false,
        //    };
        //    messageBox.Show();
        //}
        LocationCardItemList.Items.FirstOrDefault(x => x.Id == this.ChoosenSliceIdOfCell).ProductId = productId;
        LocationCardItemList.Items.FirstOrDefault(x => x.Id == this.ChoosenSliceIdOfCell).ProductName = productName;
        UpdateSliceItem sliceItem = new UpdateSliceItem()
        {
            shelfId = ShelfInformation.shelfId,
            rowId = Convert.ToInt16(RowId),
            cellId = Convert.ToInt16(CellId),
            slices = this.ChoosenSliceIdOfCell,
            itemid = productId,
        };
        UpdateitemSource.Add(sliceItem);
    }

    private void OpenDialog(int id)
    {
        if (IsDialogOpen == false)
        {
            IsDialogOpen = true;
            this.ChoosenSliceIdOfCell = id;
            GoodLocationUpdateDialog.ProductId = LocationCardItemList.Items[id - 1].ProductId;
            GoodLocationUpdateDialog.ProductName = LocationCardItemList.Items[id - 1].ProductName;
        }
    }
    private void Clear3DAndCard()
    {
        Canvas panel = new Canvas()
        {
            Height = 847.04,
            Width = 442.04
        };
        Content.Content = panel;
        LocationCardItemList.Items.Clear();

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
                        IsEmptySpace = cell.slices.Any(a => a.slots.Any(b => b.containerId != null))
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
