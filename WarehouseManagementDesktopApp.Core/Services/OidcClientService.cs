using IdentityModel.OidcClient;

namespace WarehouseManagementDesktopApp.Core.Services;

public class OidcClientService: IOidcClientService
{
    private readonly IApiService _apiService;
    private Error _error = new Error();
    private OidcClient OidcClient { get; set; }
    private OidcClientOptions OidcConfigure { get; set; }
    public Error Error { get=>_error; set=>_error=value; }
    public Window Window { get; set; }
    public Action<WebView2> BrowserPage { get; set; }
    private readonly EmbeddedBrowserService _embeddedBrowserService;
    public OidcClientService( IApiService apiService, EmbeddedBrowserService embeddedBrowserService)
    {
        _apiService = apiService;
         _embeddedBrowserService = embeddedBrowserService;
        embeddedBrowserService.BrowserWindow += InvokeBrowserPage;

         OidcConfigure = new OidcClientOptions()
        {
            Authority = "https://authenticationserver20220111094343.azurewebsites.net",
            ClientId = "native-client",
            Scope = "openid native-client-scope profile",
            RedirectUri = "https://authenticationserver20220111094343.azurewebsites.net/account/login",
            Browser = embeddedBrowserService,
            Policy = new Policy
            {
                RequireIdentityTokenSignature = false
            }
        };
        this.Window = embeddedBrowserService.Window;
    }

    private void InvokeBrowserPage(WebView2 webView)
    {
        BrowserPage?.Invoke(webView);
    }

    public async void LoginAsync()
    {
        OidcClient = new OidcClient(OidcConfigure);
        LoginResult loginResult = new LoginResult();
        try
        {
            loginResult = await OidcClient.LoginAsync();
        }
        catch (Exception exception)
        {
            Error.Message = $"Unexpected Error: {exception.Message}";
            return;
        }
        if (loginResult.IsError)
        {
            Error.Message = loginResult.Error;
        }
        else
        {
            Error = new Error();
            _apiService.LogInAsync(loginResult.AccessToken, Error);
        }
    }
}
