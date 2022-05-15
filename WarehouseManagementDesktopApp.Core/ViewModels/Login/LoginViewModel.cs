using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WarehouseManagementDesktopApp.Core.Services;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LoginViewModel : ViewModel.BaseViewModels.BaseViewModel
{

    private readonly MainStore _navigationStore;
    private readonly IApiService _apiService;
    private ContentControl _contentControl = new ContentControl();
    public ICommand NotifyViewnavigationCommand { get; set; }
    private readonly IOidcClientService _clientService;
    public ContentControl Content { get => _contentControl; set { _contentControl = value; OnPropertyChanged(); } }
    //public Window BrowserWindow { get=>_window; set { _window = value;OnPropertyChanged(); } }
    public LoginViewModel(IOidcClientService clientService, MainStore navigationStore, IApiService apiService)
    {
        var _clientService = clientService;
        if (_clientService == null)
        {
            MessageBox messageBox = new MessageBox()
            {
                ContentText = "Vui lòng chuyển tab để đăng xuất !",
                IsWarning = false
            };
            messageBox.Show();
        }
        else
        {
            _clientService.BrowserPage += BrowserWindow;
            _clientService.LoginSuccess += NavigateNotify;
            _clientService.LoginAsync();
        }
            _navigationStore = navigationStore;
            _apiService = apiService;
    }

    private void NavigateNotify()
    {
        var notifyvm = new NotifyViewModel(_navigationStore, _apiService, _clientService);
        _navigationStore.CurrentViewModel = notifyvm;
    }

    private void BrowserWindow(WebView2 webView)
    {
        Content.Content = webView;
    }
}
