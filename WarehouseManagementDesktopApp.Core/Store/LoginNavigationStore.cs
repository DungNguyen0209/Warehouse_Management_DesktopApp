namespace WarehouseManagementDesktopApp.Core.Store;
#pragma warning disable CS8618
public class LoginNavigationStore : NavigationStore
{
    private BaseViewModel _currentViewModel;
    public override BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action LoginCurrentViewModelChanged;

    public override void OnCurrentViewModelChanged()
    {
        LoginCurrentViewModelChanged?.Invoke();
    }

}
#pragma warning restore
