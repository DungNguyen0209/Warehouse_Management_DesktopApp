namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class NotifyViewModel: BaseViewModel
{
    private readonly LoginNavigationStore _navigationStore;

    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ChatMessageListDesignModel ChatMessageList { get; set; }  
    public ICommand LoginViewnavigationCommand { get; set; }
    public NotifyViewModel(LoginNavigationStore navigationStore, INavigationService _LoginNavigate,ChatMessageListDesignModel chatMessageListDesignModel)
    {
        _navigationStore = navigationStore;
        ChatMessageList = chatMessageListDesignModel;
        LoginViewnavigationCommand = new RelayCommand(()=> testc());
    }

    private void testc()
    {
        ChatMessageList.PendingMessageText = "Dũng đẹp trai SSSSSDDDDDDDDĐ";
        ChatMessageList.Send();
    }
}

