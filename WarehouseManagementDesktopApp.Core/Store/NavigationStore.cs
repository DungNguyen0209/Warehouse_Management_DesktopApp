namespace WarehouseManagementDesktopApp.Core.Domain.Stores;
#pragma warning disable CS8618
public class NavigationStore
{
    private BaseViewModel _currentViewModel;
    public virtual BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action CurrentViewModelChanged;

    public virtual void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
#pragma warning restore
