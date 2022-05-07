using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WarehouseManagementDesktopApp.Core.Services;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LoginViewModel : ViewModel.BaseViewModels.BaseViewModel
{
    private readonly LoginNavigationStore _navigationStore;
    private ContentControl _contentControl = new ContentControl();
    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ICommand NotifyViewnavigationCommand { get; set; }
    private readonly IOidcClientService _clientService;
    public ContentControl Content { get=> _contentControl; set { _contentControl = value;OnPropertyChanged(); } }
    //public Window BrowserWindow { get=>_window; set { _window = value;OnPropertyChanged(); } }
    public LoginViewModel(IOidcClientService clientService)
    {
        var _clientService = clientService;
        _clientService.BrowserPage += BrowserWindow;
        _clientService.LoginAsync();
    }

    private void BrowserWindow(WebView2 webView)
    {
        Content.Content = webView;
    }
}
