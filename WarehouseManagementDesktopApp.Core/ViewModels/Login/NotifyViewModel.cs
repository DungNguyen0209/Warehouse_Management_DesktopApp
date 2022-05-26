namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class NotifyViewModel: BaseViewModel
{
    private readonly MainStore _navigationStore;
    private readonly IApiService _apiService;
    private readonly IOidcClientService _clientService;
    private bool isRequired = false;
    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    ObservableCollection<string> WarningStockCards { get; set; } = new ObservableCollection<string>();
    private ChatMessageListDesignModel _chatMessageListDesignModel = new ChatMessageListDesignModel();
    public ChatMessageListDesignModel ChatMessageList { get=>_chatMessageListDesignModel; set { _chatMessageListDesignModel = value;OnPropertyChanged(); } }
    public ICommand LoginViewnavigationCommand { get; set; }
    public bool IsRequired { get => isRequired; set { isRequired = false;OnPropertyChanged(); } }
    public NotifyViewModel(MainStore navigationStore, IApiService apiService, IOidcClientService clientService)
    {
        _navigationStore = navigationStore;
        _apiService = apiService;
        _clientService = clientService;
        LoginViewnavigationCommand = new RelayCommand(() => LogOut());
        LoadWarningItem();
    }

    private void LogOut()
    {
        IsRequired = false;
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
        var loginvm = new LoginViewModel(_clientService,_navigationStore,_apiService);
        _navigationStore.CurrentViewModel = loginvm;
        _apiService.LogOut();

        }

    }
    public async void LoadWarningItem()
    {
        var understock = await _apiService.GetUnderStockCards();
        if (understock.Success && understock.Resource!=null&& understock.Resource.Count()>0)
        {
            foreach (var item in understock.Resource)
            {
                if(item.item != null)
                {               
                WarningStockCards.Add("Sản phẩm " + item.item.itemId + "-" + item.item.name + " dưới định mức ");
                }
            }
        }
        var overstock = await _apiService.GetOverStockCards();
        if (understock.Success && understock.Resource != null && understock.Resource.Count() > 1)
        {
            foreach (var item in overstock.Resource)
            {
                if (item.item != null )
                {
                    WarningStockCards.Add("Sản phẩm " + item.item.itemId + "-" + item.item.name + " trên  định mức ");
                }
            }
        }
        var messageList = new ChatMessageListDesignModel();
        foreach (var item in WarningStockCards)
        {
            ChatMessageListItemDesignModel messageitem = new ChatMessageListItemDesignModel
            {
                Message = item,
                ProfilePictureRGB = "3099c5",
                SentByMe = true,
            };
            messageList.Items.Add(messageitem);
        }
        ChatMessageList = messageList;
    }
}

