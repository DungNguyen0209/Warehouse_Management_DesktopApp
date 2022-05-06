namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class LocationCardItemListViewModel : BaseViewModel
{
    public static LocationCardItemListViewModel Instance => new LocationCardItemListViewModel();
    public LocationCardItemListViewModel()
    {
        Items = new ObservableCollection<LocationCardItemViewModel>
        {
            new LocationCardItemViewModel()
            {
                ProductId = "111",
                Collumn = "Cot 1",
                ProductName = " Hang 1",
                Id = 0,
                IsEmptySpace = false

            },
            new LocationCardItemViewModel()
            {
                ProductId = "222",
                ProductName = " Hang 2",
                Collumn = "Cot 1",
                Id = 1,
                IsEmptySpace = false

            },
            new LocationCardItemViewModel()
            {
                ProductId = "333",
                ProductName = " Hang 3",
                Collumn = "Cot 1",
                Id = 2,
                IsEmptySpace = true

            },
            new LocationCardItemViewModel()
            {
                ProductId = "444",
                ProductName = " Hang 4",
                Collumn = "Cot 1",
                Id = 3,
                IsEmptySpace = true

            },
            new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Collumn = "Cot 1",
                Id = 4,
                IsEmptySpace = false

            },
             new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Collumn = "Cot 1",
                Id = 5,
                IsEmptySpace = false

            },
              new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Collumn = "Cot 1",
                Id = 6,
                IsEmptySpace = false

            },
               new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Collumn = "Cot 1",
                Id = 7,
                IsEmptySpace = false

            },
                new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Id = 8,
                IsEmptySpace = false

            },
                 new LocationCardItemViewModel()
            {
                ProductId = "555",
                ProductName = " Hang 5",
                Collumn = "Cot 1",
                Id = 9,
                IsEmptySpace = false

            },
        };
    }
    private ObservableCollection<LocationCardItemViewModel> _items = new ObservableCollection<LocationCardItemViewModel>();
    public ObservableCollection<LocationCardItemViewModel> Items
    {
        get => _items;
        set {
            _items = value;
            OnPropertyChanged();
            SubcriseEvent();
        
        }
    
    }
    public Action<int> ClickItem;
    private void SubcriseEvent()
    {
        foreach(var item in _items)
        {
            item.Click += EventInvoke;
        }
    }
    public void EventInvoke(int id)
    {
        ClickItem?.Invoke(id);
    }
}
