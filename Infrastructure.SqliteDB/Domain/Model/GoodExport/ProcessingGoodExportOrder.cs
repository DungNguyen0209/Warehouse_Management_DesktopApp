namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class ProcessingGoodExportOrder
{
    public int Id { get; set; }
    public string? orderId { get; set; }
    public IList<FormulaListGoodIssue>? formulaListGoodIssues { get; set; }
}
