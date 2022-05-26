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
        private string _username = "UserName";
        private string _role = "Role";
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        public string Role { get => _role; set { _role = value; OnPropertyChanged(); } }
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
        public int SelectButton { get; set; }
        private bool isButtonLogin;
        public bool IsButtonLogin { get => isButtonLogin; set { isButtonLogin = value; OnPropertyChanged(); } }
        private bool isButtonGoodReceipt;
        public bool IsButtonGoodReceipt { get => isButtonGoodReceipt; set { isButtonGoodReceipt = value; OnPropertyChanged(); } }
        private bool isButtonGoodIssue;
        public bool IsButtonGoodIssue { get => isButtonGoodIssue; set { isButtonGoodIssue = value; OnPropertyChanged(); } }
        private bool isButtonGoodLocation;
        public bool IsButtonGoodLocation { get => isButtonGoodLocation; set { isButtonGoodLocation = value; OnPropertyChanged(); } }
        private bool isButtonReport;
        public bool IsButtonReport { get => isButtonReport; set { isButtonReport = value; OnPropertyChanged(); } }
        private bool isButtonHistory;
        public bool IsButtonHistory { get => isButtonHistory; set { isButtonHistory = value; OnPropertyChanged(); } }
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
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
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
            Username = "nhmdung";
            Role = "Trưởng Kho";
            MessageBox messageBox = new MessageBox()
            {
                IsWarning = false,
                ContentText = "Đăng nhập thành công"
            };
            messageBox.Show();
        }
        private void _navigationStore_CurrentButtonChanged()
        {
            SelectButton = _navigationStore.SelectButton;
            SwitchAnimationButton(SelectButton);
        }

        public void SwitchAnimationButton(int selectButton)
        {
            //     CustomMessageBoxWindow cx = new CustomMessageBoxWindow("Đây là Messag Thông số cài đại là Cảnh báo","kkkk", MessageBoxButton.YesNo, MessageBoxImage.Error);
            //cx.ShowDialog();
            switch (selectButton)
            {
                case 1:
                    IsButtonLogin = true;
                    IsButtonGoodReceipt = false;
                    IsButtonGoodIssue = false;
                    IsButtonGoodLocation = false;
                    IsButtonReport = false;
                    IsButtonHistory = false;
                    break;
                case 2:
                    IsButtonLogin = false;
                    IsButtonGoodReceipt = true;
                    IsButtonGoodIssue = false;
                    IsButtonGoodLocation = false;
                    IsButtonReport = false;
                    IsButtonHistory = false;
                    break;
                case 3:
                    IsButtonLogin = false;
                    IsButtonGoodReceipt = false;
                    IsButtonGoodIssue = true;
                    IsButtonGoodLocation = false;
                    IsButtonReport = false;
                    IsButtonHistory = false;
                    break;
                case 4:
                    IsButtonLogin = false;
                    IsButtonGoodReceipt = false;
                    IsButtonGoodIssue = false;
                    IsButtonGoodLocation = true;
                    IsButtonReport = false;
                    IsButtonHistory = false;
                    break;
                case 5:
                    IsButtonLogin = false;
                    IsButtonGoodReceipt = false;
                    IsButtonGoodIssue = false;
                    IsButtonGoodLocation = false;
                    IsButtonReport = false;
                    IsButtonHistory = true;
                    break;
                case 6:
                    IsButtonLogin = false;
                    IsButtonGoodReceipt = false;
                    IsButtonGoodIssue = false;
                    IsButtonGoodLocation = false;
                    IsButtonReport = true;
                    IsButtonHistory = false;
                    break;
            }
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
