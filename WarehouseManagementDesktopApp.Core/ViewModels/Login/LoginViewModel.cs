namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class LoginViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;


        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NotifyViewnavigationCommand { get; set; }
        public LoginViewModel(NavigationStore navigationStore, INavigationService _NotifyNavigate)
        {
            _navigationStore = navigationStore;
            NotifyViewnavigationCommand = new NavigateCommand(_NotifyNavigate);
        }


    }
}
