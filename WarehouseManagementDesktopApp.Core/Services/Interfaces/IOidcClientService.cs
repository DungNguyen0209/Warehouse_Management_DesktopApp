namespace WarehouseManagementDesktopApp.Core.Services.Interfaces;

public interface IOidcClientService
{
    void LoginAsync();
    public Window Window { get; set; }
    public Action<WebView2> BrowserPage { get; set; }
}
