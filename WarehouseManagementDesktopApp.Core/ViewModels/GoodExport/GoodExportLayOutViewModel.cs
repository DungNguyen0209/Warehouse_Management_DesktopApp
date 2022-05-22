
namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class GoodExportLayOutViewModel : ViewModel.BaseViewModels.BaseViewModel
{
    private readonly NavigationStore _navigationStore;


    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ICommand GoodExportnavigationCommand { get; set; }
    public int SelectButton { get; set; } = 1;
    private bool isButtonGoodReceipt;
    public bool IsButtonGoodReceipt { get => isButtonGoodReceipt; set { isButtonGoodReceipt = value; OnPropertyChanged(); } }
    private bool isButtonGoodProcess;
    public bool IsButtonGoodProcess { get => isButtonGoodProcess; set { isButtonGoodProcess = value; OnPropertyChanged(); } }
    public ICommand ProcessingGoodExportCommand { get; set; }
    public GoodExportLayOutViewModel(NavigationStore navigationStore, INavigationService _GoodExportnavigationService, INavigationService _ProcessingGoodExportnavigationService)
    {
        _navigationStore = navigationStore;
        GoodExportnavigationCommand = new NavigateCommand(_GoodExportnavigationService);
        ProcessingGoodExportCommand = new NavigateCommand(_ProcessingGoodExportnavigationService);
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
        SwitchAnimationButton(SelectButton);

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
                IsButtonGoodReceipt = true;
                IsButtonGoodProcess = false;
                break;
            case 2:
                IsButtonGoodReceipt = false;
                IsButtonGoodProcess = true;
                break;
        }
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
