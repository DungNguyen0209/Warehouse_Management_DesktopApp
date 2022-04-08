
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodReceiptViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand NavigateGoodReceiptOrderView { get; set; }
        public GoodReceiptViewModel(GoodReceiptNavigationStore navigationStore, INavigationService _GoodReceiptOrdernavigationService)
        {
            _navigationStore = navigationStore;
            NavigateGoodReceiptOrderView = new NavigateCommand(_GoodReceiptOrdernavigationService);
        }

    }
}
