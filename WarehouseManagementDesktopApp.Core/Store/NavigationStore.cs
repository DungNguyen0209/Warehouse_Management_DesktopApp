namespace WarehouseManagementDesktopApp.Core.Domain.Stores
{
    public class NavigationStore
    {
        private ViewModel.BaseViewModels.BaseViewModel _currentViewModel;
        public virtual ViewModel.BaseViewModels.BaseViewModel CurrentViewModel
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
}
