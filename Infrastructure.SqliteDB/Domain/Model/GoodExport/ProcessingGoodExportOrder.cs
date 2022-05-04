namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class ProcessingGoodExportOrder
{
    public int Id { get; set; }
    public int orderId { get; set; }
    public ICollection<FormulaListGoodIssue>? formulaListGoodIssues { get; set; }
    public ICollection<IssueBasket>? issueBaskets { get; set; }
}
