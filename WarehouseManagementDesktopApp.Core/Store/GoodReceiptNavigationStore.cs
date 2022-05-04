using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Store
{
    public class GoodReceiptNavigationStore : NavigationStore
    {
    #pragma warning disable CS8618
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

        public event Action GoodReceiptCurrentViewModelChanged;

        public override void OnCurrentViewModelChanged()
        {
            GoodReceiptCurrentViewModelChanged?.Invoke();
        }
#pragma warning restore
    }
}
