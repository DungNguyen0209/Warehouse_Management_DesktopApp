namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class MainViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand LoggingCommand { get; set; }

        public ICommand GoodReceiptCommand { get; set; }
        public ICommand GoodlocationCommand { get; set; }
        public MainViewModel(NavigationStore navigationStore, INavigationService _LogingnavigationService, INavigationService _GoodReceiptnavigationService, INavigationService _GoodLocationnavigationService)
        {
            _navigationStore = navigationStore;
            CurrentViewModel = new LoginViewModel();
            LoggingCommand = new NavigateCommand(_LogingnavigationService);
            GoodReceiptCommand = new NavigateCommand(_GoodReceiptnavigationService);
            GoodlocationCommand = new NavigateCommand(_GoodLocationnavigationService);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
