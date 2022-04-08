namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class MainViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand LoggingCommand { get; set; }

        public ICommand GoodReceiptCommand { get; set; }
        public ICommand GoodExportCommand { get; set; }
        public ICommand GoodlocationCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public MainViewModel(NavigationStore navigationStore, INavigationService _LogingnavigationService, INavigationService _GoodReceiptnavigationService,INavigationService _GoodExportnavigationService ,INavigationService _GoodLocationnavigationService, INavigationService _ReportnavigationService, INavigationService _HistorynavigationService)
        {
            _navigationStore = navigationStore;
            LoggingCommand = new NavigateCommand(_LogingnavigationService);
            GoodReceiptCommand = new NavigateCommand(_GoodReceiptnavigationService);
            GoodExportCommand = new NavigateCommand(_GoodExportnavigationService);
            GoodlocationCommand = new NavigateCommand(_GoodLocationnavigationService);
            ReportCommand = new NavigateCommand(_ReportnavigationService);
            HistoryCommand = new NavigateCommand(_HistorynavigationService);
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
