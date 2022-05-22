namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class GoodLocationLayOutViewModel:BaseViewModel
{
     private readonly NavigationStore _navigationStore;


    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ICommand GooLocationnavigationCommand { get; set; }
    public int SelectButton { get; set; } = 1;
    private bool isButtonGoodLocation;
    public bool IsButtonGoodLocation { get => isButtonGoodLocation; set { isButtonGoodLocation = value; OnPropertyChanged(); } }
    private bool isButtonUpdateGoodLocation;
    public bool IsButtonUpdateGoodLocation { get => isButtonUpdateGoodLocation; set { isButtonUpdateGoodLocation = value; OnPropertyChanged(); } }
    public ICommand UpdateGoodLocationnavigationCommand { get; set; }
    public GoodLocationLayOutViewModel(NavigationStore navigationStore, INavigationService _GoodLocationnavigationService , INavigationService _UpdateGoodLocationnavigationService)
    {
        _navigationStore = navigationStore;
        GooLocationnavigationCommand = new NavigateCommand(_GoodLocationnavigationService);
        UpdateGoodLocationnavigationCommand = new NavigateCommand(_UpdateGoodLocationnavigationService);
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
                IsButtonGoodLocation = true;
                IsButtonUpdateGoodLocation = false;
                break;
            case 2:
                IsButtonGoodLocation = false;
                IsButtonUpdateGoodLocation = true;
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
