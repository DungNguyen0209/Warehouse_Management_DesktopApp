using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class ControlBarViewModel: BaseViewModel
{

    public static ControlBarViewModel Instance => new ControlBarViewModel();
    public ICommand CloseWindowCommand { get; set; }
    private string _tag;
    public string Tag { get=> _tag; set { _tag = value;OnPropertyChanged(); } }
    public Action Close;

    public ControlBarViewModel()
    {
        CloseWindowCommand = new RelayCommand(async () => CloseWindow());
        Tag = "Thông Báo";
    }

    private void CloseWindow()
    {
        Close?.Invoke();
    }
}
