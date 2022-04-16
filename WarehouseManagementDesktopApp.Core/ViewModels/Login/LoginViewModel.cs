namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LoginViewModel : ViewModel.BaseViewModels.BaseViewModel
{
    private readonly LoginNavigationStore _navigationStore;


    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ICommand NotifyViewnavigationCommand { get; set; }
    public LoginViewModel(LoginNavigationStore navigationStore, INavigationService _NotifyNavigate)
    {
        _navigationStore = navigationStore;
        NotifyViewnavigationCommand = new NavigateCommand(_NotifyNavigate);
    }


}
