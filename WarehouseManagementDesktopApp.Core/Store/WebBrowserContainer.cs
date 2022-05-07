using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Store;

public class WebBrowserContainer
{
    private Window _window = new Window();
    public  Window View
    {
        get => _window;
        set
        {
            _window = value;
            OnViewChanged();
        }
    }

    public Action<Window> CurrentViewModelChanged;

    public virtual void OnViewChanged()
    {
        CurrentViewModelChanged?.Invoke(View);
    }
}
