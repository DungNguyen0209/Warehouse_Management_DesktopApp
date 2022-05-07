namespace WarehouseManagementDesktopApp.Core.Services;

public class StartProgramService:IStartProgramService
{
    private readonly IApiService _apiService;
    private readonly IProductsDatabaseService _productsDatabaseService;
    private readonly IMapper _mapper;
    private readonly IOidcClientService _idcClientService;
    private readonly WebBrowserContainer _webBrowserContainer;

    public StartProgramService(IApiService apiService, IProductsDatabaseService roductsDatabaseService, IMapper mapper, WebBrowserContainer webBrowserContainer,IOidcClientService oidcClientService)
    {
        _idcClientService = oidcClientService;
        _webBrowserContainer = webBrowserContainer;
        _apiService = apiService;
        _productsDatabaseService = roductsDatabaseService;
        _mapper = mapper;
    }
    public async void LoadLoginView()
    {
        _webBrowserContainer.View = _idcClientService.Window;
        await Task.Delay(10);
        await Task.Run(()=>_idcClientService.LoginAsync());
    }
    public async void LoadProgram()
    {
        await Task.Run(() => LoadProduct());
    }
    private async void LoadProduct()
    {
        var data = await _apiService.GetAllProduct();
        var fullproduct = data.Resource.Items;
        List<Persistence.SqliteDB.Model.Product> products = new List<Persistence.SqliteDB.Model.Product>();
        foreach (var item in fullproduct)
        {
            var itemdata = _mapper.Map<Persistence.SqliteDB.Model.Product>(item);

            products.Add(itemdata);
        }
        _productsDatabaseService.Clear();
        await Task.Run(() => _productsDatabaseService.Insert(products));
    }
}
