namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LoginLayOutViewModel : BaseViewModel
{
    private readonly LoginNavigationStore _navigationStore;
    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel { get => _navigationStore.CurrentViewModel; set => _navigationStore.CurrentViewModel = value; }

    public LoginLayOutViewModel(LoginNavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.LoginCurrentViewModelChanged += OnCurrentViewModelChanged;
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
