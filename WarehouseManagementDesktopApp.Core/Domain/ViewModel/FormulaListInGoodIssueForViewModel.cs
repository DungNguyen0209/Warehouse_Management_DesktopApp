namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel;

public class FormulaListInGoodIssueForViewModel : BaseViewModel
{
#pragma warning disable CS8618
    private bool _isfinished = false;
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string PlannedMass { get; set; }
    public string PlannedQuantity { get; set; }
    public string Actual { get; set; }
    public string note { get; set; } = "";
    public bool IsFinished
    {
        get => _isfinished;
        set
        {
            _isfinished = value;
            OnPropertyChanged();
        }
    }
#pragma warning restore
}
