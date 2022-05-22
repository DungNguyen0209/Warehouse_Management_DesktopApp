namespace WarehouseManagementDesktopApp.Core.Domain.Stores;
#pragma warning disable CS8618
public class NavigationStore
{
    private BaseViewModel _currentViewModel;
    private int _selectButton;
    public virtual BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            SelectViewModel();
            OnCurrentViewModelChanged();
        }
    }
    public int SelectButton
    {
        get => _selectButton;
        set
        {
            _selectButton = value;
            OnCurrentButtonChanged();
        }
    }
    public event Action CurrentViewModelChanged;

    public virtual void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
    public event Action CurrentButtonChanged;

    private void OnCurrentButtonChanged()
    {
        CurrentButtonChanged?.Invoke();
    }
    public void SelectViewModel()
    {
        switch (CurrentViewModel)
        {
            case WarehouseManagementDesktopApp.Core.ViewModels.GoodExportViewModel:
                this.SelectButton = 1;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.ProcessingGoodExportViewModel:
                this.SelectButton = 2;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.GoodLocationViewModel:
                this.SelectButton = 1;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.UpdateGoodLocationViewModel:
                this.SelectButton = 2;
                break;
        }
    }
}
#pragma warning restore
