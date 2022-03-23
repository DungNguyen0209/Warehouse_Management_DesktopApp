using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodLocationViewModel: BaseViewModel
    {
        public ICommand SearchCommand { get; set; }
        public GoodLocationViewModel()
        {
            SearchCommand = new RelayCommand(() => TextAddImage());
        }
        public Action AddImageEvent;
        private void TextAddImage()
        {
            AddImageEvent?.Invoke();
        }
    }
}
