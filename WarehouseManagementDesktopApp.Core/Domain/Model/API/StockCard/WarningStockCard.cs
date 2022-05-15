namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.StockCard;

public class WarningStockCard
{
    public Product item { get; set; }
    private DateTime _date = new DateTime();
    public DateTime date
    {
        get => _date;
        set
        {
            if (value != null)
            {
                string datestring = value.ToString("yyyy-MM-dd");
                value = Convert.ToDateTime(datestring);
                _date = value;
            }
        }
    }
    public double beforeQuantity { get; set; }
    public double inputQuantity { get; set; }
    public double outputQuantity { get; set; }
    public double afterQuantity { get; set; }
    public string note { get; set; }
}
