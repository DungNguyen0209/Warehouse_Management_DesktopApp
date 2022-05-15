namespace WarehouseManagementDesktopApp.Core.Services.Interfaces;

public interface IOidcClientService
{
    void LoginAsync();
    Window Window { get; set; }
    Action<WebView2> BrowserPage { get; set; }
    Action LoginSuccess { get; set; }
}
