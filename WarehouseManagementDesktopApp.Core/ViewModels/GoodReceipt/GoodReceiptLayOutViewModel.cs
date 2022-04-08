namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodReceiptLayOutViewModel: BaseViewModel
    {
        private readonly GoodReceiptNavigationStore _navigationStore;

        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel { get => _navigationStore.CurrentViewModel; set => _navigationStore.CurrentViewModel = value; } 
        public GoodReceiptLayOutViewModel(GoodReceiptNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.GoodReceiptCurrentViewModelChanged += OnCurrentViewModelChanged;
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
}
