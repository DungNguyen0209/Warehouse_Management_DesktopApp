using MaterialDesignThemes.Wpf;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class MainViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private IMapper _mapper;
        private readonly IApiService _apiService;
        private readonly IProductsDatabaseService _productsDatabaseService;
        private readonly IStartProgramService _startProgramService;
        private bool _isDialogOpen = false;
        private bool _isLoged ;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(); } }
        public bool IsLoged { get => _isLoged; set { _isLoged = value; OnPropertyChanged(); } }
        public ICommand LoggingCommand { get; set; }
        public ICommand GoodReceiptCommand { get; set; }
        public ICommand GoodExportCommand { get; set; }
        public ICommand GoodlocationCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public MessageBoxViewModel MessageBox { get; set; }
        public MainViewModel(NavigationStore navigationStore, INavigationService _LogingnavigationService, INavigationService _GoodReceiptnavigationService, INavigationService _GoodExportnavigationService, INavigationService _GoodLocationnavigationService, INavigationService _ReportnavigationService, INavigationService _HistorynavigationService, IApiService apiService, IProductsDatabaseService productsDatabaseService, IMapper mapper, IStartProgramService startProgramService)
        {
            _apiService = apiService;
            _productsDatabaseService = productsDatabaseService;
            _navigationStore = navigationStore;
            _mapper = mapper;
            _startProgramService = startProgramService;
            MessageBox = new MessageBoxViewModel()
            {
                ContentText = "You are Confirm",
                Icon = PackIconKind.User,
            };
            //MessageBox.Cancel += Close;
            MessageBox.Confirm += Close;
            LoggingCommand = new NavigateCommand(_LogingnavigationService);
            GoodReceiptCommand = new NavigateCommand(_GoodReceiptnavigationService);
            GoodExportCommand = new NavigateCommand(_GoodExportnavigationService);
            GoodlocationCommand = new NavigateCommand(_GoodLocationnavigationService);
            ReportCommand = new NavigateCommand(_ReportnavigationService);
            HistoryCommand = new NavigateCommand(_HistorynavigationService);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _startProgramService.FinishLogin += FinishLoging;
        }

        private void FinishLoging()
        {
            IsLoged = true;
            MessageBox messageBox = new MessageBox()
            {
                IsWarning = false,
                ContentText = "Đăng nhập thành công"
            };
            messageBox.Show();
        }

        private void Close()
        {
            IsDialogOpen = false;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            //IsDialogOpen=true;
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
