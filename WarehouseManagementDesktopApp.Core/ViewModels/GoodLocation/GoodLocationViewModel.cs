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
        private string _id;
        private string _name;
        private string _testdepth;
        public string Id { get => _id; set { _id = value;OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value;OnPropertyChanged(); } }

        public string Testdepth { get => _testdepth; set {_testdepth=value; OnPropertyChanged(); } }
        public List<BasketSlot> emptylist { get; set; }
        public GoodLocationViewModel()
        {
            SearchCommand = new RelayCommand(() => TextAddImage());
            BasketSlot EmptySlot = new BasketSlot()
            {
                Height = 1,
                Width = 4,
                Depth = 3
            };
            emptylist = new List<BasketSlot>();
            emptylist.Add(EmptySlot);
        }
        // Test create basket
        public Action<int,int,int, List<BasketSlot>> AddImageEvent;
        private void TextAddImage()
        {
            AddImageEvent?.Invoke(Convert.ToInt32(_id),Convert.ToInt32(_name), Convert.ToInt32(_testdepth), emptylist) ;
        }
    }
}
