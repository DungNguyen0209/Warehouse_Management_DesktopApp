namespace Persistence.SqliteDB.Domain.Model.GoodExport;
public class IssueBasket 
{
#pragma warning disable CS8618
    public int Id { get; set; }
    public string BasketId { get; set; }
    public string ProductionDate { get; set; }
    public string Quantity { get; set; }
    public string Mass { get; set; }
    public string? Actual { get; set; }

    public bool? IsChecked { get; set; }
    public int FormulaListGoodIssueId { get; set; }
    public FormulaListGoodIssue FormulaListGoodIssue { get; set; }
#pragma warning restore
}

