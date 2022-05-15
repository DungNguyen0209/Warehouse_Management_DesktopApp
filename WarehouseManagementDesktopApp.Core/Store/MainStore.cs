namespace WarehouseManagementDesktopApp.Core.Store;
#pragma warning disable CS8618
public class MainStore : NavigationStore
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

    public event Action MainCurrentViewModelChanged;

    public override void OnCurrentViewModelChanged()
    {
        MainCurrentViewModelChanged?.Invoke();
    }

}
#pragma warning restore
