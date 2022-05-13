namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.History;

public class Stockcardentries
{
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
    public int beforeQuantity { get; set; }
    public int inputQuantity { get; set; }
    public int outputQuantity { get; set; }
    public int afterQuantity { get; set; }
    public string note { get; set; }
}
