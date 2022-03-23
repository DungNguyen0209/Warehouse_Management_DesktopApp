namespace WarehouseManagementDesktopApp.Core.Domain.Stores
{
    public class NavigationStore
    {
        private ViewModel.BaseViewModels.BaseViewModel _currentViewModel;
        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel
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

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
