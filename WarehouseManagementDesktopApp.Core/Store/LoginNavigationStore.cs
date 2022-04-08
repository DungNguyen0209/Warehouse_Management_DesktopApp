namespace WarehouseManagementDesktopApp.Core.Store
{
    public class LoginNavigationStore:NavigationStore
    {
        private ViewModel.BaseViewModels.BaseViewModel _currentViewModel;
        public override ViewModel.BaseViewModels.BaseViewModel CurrentViewModel
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
}
