using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LocationCardItemViewModel:BaseViewModel
{
    public static LocationCardItemViewModel Instance => new LocationCardItemViewModel();
    private bool _emptySpace;
    private string _productId = string.Empty;
    private string _productName = string.Empty;
    private string _collumn = string.Empty;
    public string Collumn { get { return _collumn; } set { _collumn = value; OnPropertyChanged(); } }

    public string ProductId { get { return _productId; } set { _productId = value;OnPropertyChanged(); } }
    public string ProductName { get { return _productName; } set { _productName = value; OnPropertyChanged(); } }
    public int Id { get; set; }

    public bool IsEmptySpace
    {
        get; set ;  
    }
    public ICommand RaiseCommand { get; set; }
    public Action<int> Click;
    public LocationCardItemViewModel()
    {
        IsEmptySpace = true;
        RaiseCommand = new RelayCommand(() => IRaiseEvent());
    }

    private void IRaiseEvent()
    {
      if(!IsEmptySpace)
        {
            Click?.Invoke(Id);
        }
    }
}
