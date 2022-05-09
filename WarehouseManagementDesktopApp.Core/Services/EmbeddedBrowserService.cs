using System.Windows.Controls;

namespace WarehouseManagementDesktopApp.Core.Services;

public class EmbeddedBrowserService: IBrowser
{
    private BrowserOptions _options = null;
    private Window _window = new Window();
    public Action<WebView2> BrowserWindow;
    public Window Window { get => _window; set=> _window=value; }
    public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
    {
        _options = options;

        var semaphoreSlim = new SemaphoreSlim(0, 1);
        var browserResult = new BrowserResult()
        {
            ResultType = BrowserResultType.UserCancel
        };

        var signinWindow = new UserControl();
        var webView = new WebView2();
        webView.NavigationStarting += (s, e) =>
        {
            if (IsBrowserNavigatingToRedirectUri(new Uri(e.Uri)))
            {
                e.Cancel = true;

                browserResult = new BrowserResult()
                {
                    ResultType = BrowserResultType.Success,
                    Response = new Uri(e.Uri).AbsoluteUri
                };

                    semaphoreSlim.Release();
            }
        };
        signinWindow.Content = webView;
        // Sua o day
        BrowserWindow?.Invoke(webView);
        // Initialization
        await webView.EnsureCoreWebView2Async(null);

        // Delete existing Cookies so previous logins won't remembered
        webView.CoreWebView2.CookieManager.DeleteAllCookies();
        //await webView.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCache", "{}");

        // Navigate
        webView.CoreWebView2.Navigate(_options.StartUrl);

        await semaphoreSlim.WaitAsync();

        return browserResult;
    }

    private bool IsBrowserNavigatingToRedirectUri(Uri uri)
    {
        return uri.AbsoluteUri.StartsWith(_options.EndUrl);
    }
}
