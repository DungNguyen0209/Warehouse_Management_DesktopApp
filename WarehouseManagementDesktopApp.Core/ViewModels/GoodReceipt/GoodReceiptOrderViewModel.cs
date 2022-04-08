namespace WarehouseManagementDesktopApp.Core.ViewModels
{

    public class GoodReceiptOrderViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;


        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NavigateGoodReceiptView { get; set; }
        public GoodReceiptOrderViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService)
        {
            _navigationStore = navigationStore;
            NavigateGoodReceiptView = new NavigateCommand(_GoodReceiptOrdernavigationService);

        }

    }
}
