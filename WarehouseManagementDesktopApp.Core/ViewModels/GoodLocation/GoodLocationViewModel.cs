using System.Windows.Controls;
using WarehouseManagementDesktopApp.Core.Service.ComponentUIServices;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class GoodLocationViewModel : BaseViewModel
{
#pragma warning disable CS8618
    private readonly IApiService _apiService;
    private readonly ProductStore _productStore;
    private readonly ILocationDatabaseService _locationDatabaseService;
    public ICommand SearchCommand { get; set; }
    public ICommand DrawingCommand { get; set; }
    private string _id;
    private string _name;
    private string _testdepth;
    private int selectedIndex = 0;
    private ObservableCollection<string> productNameSource = new ObservableCollection<string>();
    private ContentControl _contentControl = new ContentControl();
    private ObservableCollection<string> productIdSource;
    public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
    public ObservableCollection<string> ProductIdSource { get { return productIdSource; } set { productIdSource = value; OnPropertyChanged(); } }
    public ObservableCollection<string> ProductNameSource { get { return productNameSource; } set { productNameSource = value; OnPropertyChanged(); } }
    public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }
    public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
    public ContentControl Content { get => _contentControl; set { _contentControl = value; OnPropertyChanged(); } }
    private ObservableCollection<string> locationSource = new ObservableCollection<string>();
    private List<EmptyContainer> emptySlot { get; set; } = new List<EmptyContainer>();
    public ObservableCollection<string> LocationSource
    {
        get => locationSource;
        set
        {
            locationSource = value;
            OnPropertyChanged();
        }
    }

    public string Testdepth { get => _testdepth; set { _testdepth = value; OnPropertyChanged(); } }
    //public List<BasketSlot> emptylist { get; set; }
    public GoodLocationViewModel(IApiService apiService, ILocationDatabaseService locationDatabaseService, ProductStore productStore)
    {
        _apiService = apiService;
        _locationDatabaseService = locationDatabaseService;
        _productStore = productStore;
        ProductIdSource = _productStore.ProductId;
        ProductNameSource = _productStore.ProductName;
        _productStore.ProductUpdate += UpdateProduct;
        SearchCommand = new RelayCommand(() => SearchLocation());
        DrawingCommand = new RelayCommand(() => DrawCell());
        //BasketSlot EmptySlot = new BasketSlot()
        //{
        //    Height = 1,
        //    Width = 4,
        //    Depth = 3
        //};
        //emptylist = new List<BasketSlot>();
        //emptylist.Add(EmptySlot);
    }

    private void UpdateProduct()
    {
        ProductIdSource = _productStore.ProductId;
        ProductNameSource = _productStore.ProductName;
    }

    private async void DrawCell()
    {

        var data = await _locationDatabaseService.LoadDatabase(SelectedIndex + 1);
        if (data.Success && data.Resource != null)
        {
            var result = await _apiService.GetCell(data.Resource.shelfId, data.Resource.rowId, data.Resource.cellId);
            if (result.Success)
            {
                Cell cell = result.Resource;
                cell.slices.Reverse();
                var width = cell.slices.Count();
                var height = cell.slices.First().slots.Max(x => x.levelId);
                var depth = cell.slices.First().slots.Max(X => X.id);
                emptySlot.Clear();
                List<Slice> reverseslices = Enumerable.Reverse(cell.slices).ToList();
                foreach (var item in reverseslices)
                {
                    var containers = item.slots.Where(s => s.container == null).ToList();
                    if (containers != null && containers.Count() > 0)
                    {
                        var sliceId = item.id;
                        foreach (var emptyitem in containers)
                        {
                            EmptyContainer emptyContainer = new EmptyContainer()
                            {
                                Width = item.id,
                                Height = emptyitem.levelId,
                                Depth = emptyitem.id
                            };
                            emptySlot.Add(emptyContainer);
                        }
                    }
                }
                Canvas panel = new Canvas()
                {
                    Height = 880,
                    Width = 700
                };
                Content.Content = panel;
                Content.Content = UpdatUI(panel, width, height, depth, emptySlot);

            }
            else
            {

                MessageBox messageBox = new MessageBox()
                {
                    ContentText = result.Error.Message,
                    IsWarning = true,
                };
                messageBox.Show();
            }
        }
        else
        {
            MessageBox messageBox = new MessageBox()
            {
                ContentText = "Không tìm kiếm được ô",
                IsWarning = true,
            };
            messageBox.Show();

        }
    }

    private async void SearchLocation()
    {
        await _locationDatabaseService.Delete();
        var httprequest = await _apiService.GetContainerByProductId(Id);
        if (httprequest.Success)
        {
            if (httprequest.Resource.Count() > 0)
            {
                var result = httprequest.Resource;
                var locations = result.Select(s => s.location).ToList();
                var responeupdatedatbase = await _locationDatabaseService.AddItemLocation(locations);
                if (responeupdatedatbase.Success)
                {
                    LocationSource.Clear();
                    ObservableCollection<string> source = new ObservableCollection<string>();
                    foreach (var item in locations)
                    {
                        if (item != null)
                        {

                            string itemsource = $"{item.shelfId}.{item.rowId}.{item.cellId}";
                            if (!source.Any(s => s == itemsource))
                            {
                                source.Add(itemsource);
                            }
                        }

                    }
                    LocationSource = source;
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = "Truy xuất thành công !",
                        IsWarning = false,
                    };
                    messageBox.Show();
                }
                else
                {
                    MessageBox messageBox = new MessageBox()
                    {
                        ContentText = responeupdatedatbase.Error.Message,
                        IsWarning = true,
                    };
                    messageBox.Show();
                }
            }
            else
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = "Không có vị trí của mã sản phẩm này !",
                    IsWarning = true,
                };
                messageBox.Show();
            }

        }
        else
        {
            MessageBox messageBox = new MessageBox()
            {
                ContentText = httprequest.Error.Message,
                IsWarning = true,
            };
            messageBox.Show();
        }
    }

    private Canvas UpdatUI(Canvas Slotpanel, int width, int height, int depth, List<EmptyContainer> emptySlot)
    {
        Slotpanel.Children.Clear();
        int halfofdepth = depth / 2;
        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= depth; j++)
            {
                for (int k = 1; k <= width; k++)
                {

                    double marginRight = (Slotpanel.Width - width * 100 + 30 * (width - 1)) / 2 + (k - 1) * 50 - 15 * j + 40;
                    int marginBottom = 10 - j * 20 + (80 + 8 * depth) * i + 200 + 100;
                    if (emptySlot != null)
                    {

                        if (emptySlot.Any(s => s.Width == (width - k + 1) && s.Height == i && s.Depth == j))
                        {
                            CubeGenerate.CreateEmptyBasket(Slotpanel, marginRight, marginBottom);
                        }
                        else
                        {
                            CubeGenerate.CreateBasket(Slotpanel, marginRight, marginBottom);

                        }
                    }
                }
            }
        }



        return Slotpanel;
    }
}
