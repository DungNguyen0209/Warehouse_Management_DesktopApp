using MaterialDesignThemes.Wpf;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class MainViewModel : ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly MainStore _navigationStore;
        private IMapper _mapper;
        private readonly IApiService _apiService;
        private readonly IProductsDatabaseService _productsDatabaseService;
        private readonly IStartProgramService _startProgramService;
        private readonly INavigationService _loginnavigateService;
        private readonly INavigationService _notifynavigateService;
        private bool _isDialogOpen = false;
        private bool _isLoged;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(); } }
        public bool IsLoged
        {

            get => _isLoged;
            set
            {
                _isLoged = value; OnPropertyChanged();
                if (!_isLoged)
                {
                    LoggingCommand = new NavigateCommand(_loginnavigateService);
                }
                else
                {
                    LoggingCommand = new NavigateCommand(_notifynavigateService);
                };
            }
        }
        public ICommand LoggingCommand { get; set; }
        public ICommand GoodReceiptCommand { get; set; }
        public ICommand GoodExportCommand { get; set; }
        public ICommand GoodlocationCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public MessageBoxViewModel MessageBox { get; set; }
        public MainViewModel(MainStore navigationStore, INavigationService _LogingnavigationService, INavigationService notifynavigationService, INavigationService _GoodReceiptnavigationService, INavigationService _GoodExportnavigationService, INavigationService _GoodLocationnavigationService, INavigationService _ReportnavigationService, INavigationService _HistorynavigationService, IApiService apiService, IProductsDatabaseService productsDatabaseService, IMapper mapper, IStartProgramService startProgramService)
        {
            _apiService = apiService;
            _productsDatabaseService = productsDatabaseService;
            _navigationStore = navigationStore;
            _mapper = mapper;
            _loginnavigateService = _LogingnavigationService;
            _notifynavigateService = notifynavigationService;
            _startProgramService = startProgramService;
            MessageBox = new MessageBoxViewModel()
            {
                ContentText = "You are Confirm",
                Icon = PackIconKind.User,
            };
            //MessageBox.Cancel += Close;
            MessageBox.Confirm += Close;
            GoodReceiptCommand = new NavigateCommand(_GoodReceiptnavigationService);
            GoodExportCommand = new NavigateCommand(_GoodExportnavigationService);
            GoodlocationCommand = new NavigateCommand(_GoodLocationnavigationService);
            ReportCommand = new NavigateCommand(_ReportnavigationService);
            HistoryCommand = new NavigateCommand(_HistorynavigationService);
            _navigationStore.MainCurrentViewModelChanged += OnCurrentViewModelChanged;
            _startProgramService.FinishLogin += FinishLoging;
            _apiService.LogoutCompleteAction += SignOut;
        }

        private void SignOut()
        {
            IsLoged = false;
            MessageBox messageBox = new MessageBox()
            {
                IsWarning = false,
                ContentText = "Đăng xuất thành công"
            };
            messageBox.Show();
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
