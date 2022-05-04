namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class ProcessingGoodExportOrder
{
    public int Id { get; set; }
    public string? orderId { get; set; }
    public ICollection<FormulaListGoodIssue>? formulaListGoodIssues { get; set; }
    public ICollection<IssueBasketList>? issueBasketLists { get; set; }
}
