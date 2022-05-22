namespace WarehouseManagementDesktopApp.Core.Store;
#pragma warning disable CS8618
public class MainStore : NavigationStore
{
    private BaseViewModel _currentViewModel;
    private int _selectButton;
    public override BaseViewModel CurrentViewModel
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

    public event Action MainCurrentViewModelChanged;
    public int SelectButton
    {
        get => _selectButton;
        set
        {
            _selectButton = value;
            OnCurrentButtonChanged();
        }
    }
    public override void OnCurrentViewModelChanged()
    {
        MainCurrentViewModelChanged?.Invoke();
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
            case WarehouseManagementDesktopApp.Core.ViewModels.LoginViewModel:
                this.SelectButton = 1;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.NotifyViewModel:
                this.SelectButton = 1;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.GoodReceiptLayOutViewModel:
                this.SelectButton = 2;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.GoodExportLayOutViewModel:
                this.SelectButton = 3;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.GoodLocationLayOutViewModel:
                this.SelectButton = 4;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.ReportViewModel:
                this.SelectButton = 5;
                break;
            case WarehouseManagementDesktopApp.Core.ViewModels.HistoryViewModel:
                this.SelectButton = 6;
                break;
        }
    }
}
#pragma warning restore
