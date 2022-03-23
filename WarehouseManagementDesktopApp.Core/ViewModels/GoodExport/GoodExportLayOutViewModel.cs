using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodExportLayOutViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;


        public ViewModel.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand GoodExportnavigationCommand { get; set; }

        public ICommand ProcessingGoodExportCommand { get; set; }
        public GoodExportLayOutViewModel(NavigationStore navigationStore, INavigationService _GoodExportnavigationService, INavigationService _ProcessingGoodExportnavigationService)
        {
            _navigationStore = navigationStore;
            GoodExportnavigationCommand = new NavigateCommand(_GoodExportnavigationService);
            ProcessingGoodExportCommand = new NavigateCommand(_ProcessingGoodExportnavigationService);
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
}
