namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class GoodLocationLayOutViewModel:BaseViewModel
{
     private readonly NavigationStore _navigationStore;


    public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    public ICommand GooLocationnavigationCommand { get; set; }

    public ICommand UpdateGoodLocationnavigationCommand { get; set; }
    public GoodLocationLayOutViewModel(NavigationStore navigationStore, INavigationService _GoodLocationnavigationService , INavigationService _UpdateGoodLocationnavigationService)
    {
        _navigationStore = navigationStore;
        GooLocationnavigationCommand = new NavigateCommand(_GoodLocationnavigationService);
        UpdateGoodLocationnavigationCommand = new NavigateCommand(_UpdateGoodLocationnavigationService);
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

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
