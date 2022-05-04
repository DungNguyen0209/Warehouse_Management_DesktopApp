namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel;
public delegate void Notify();
public class IssueBasketForViewModel : BaseViewModel
{
#pragma warning disable CS8618
    private string _actual;
    private bool _isCheck;
    public event Notify ActualChanged;
    public string BasketId { get; set; }
    public string ProductionDate { get; set; }
    public string Quantity { get; set; }
    public string Mass { get; set; }
    public string Actual
    {
        get => _actual; set
        {
            if (_actual != value)
            {
                _actual = value;
                OnPropertyChanged();
                ActualChanged?.Invoke();
            }
        }
    }

    public bool IsChecked
    {
        get => _isCheck;
        set
        {
            if (_isCheck != value)
            {
                _isCheck = value;
                OnPropertyChanged();
                ActualChanged?.Invoke();
            }
        }
            
    }

#pragma warning restore
}

