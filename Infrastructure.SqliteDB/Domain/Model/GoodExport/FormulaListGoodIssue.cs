namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class FormulaListGoodIssue
{
#pragma warning disable CS8618
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string PlannedMass { get; set; }
    public string PlannedQuantity { get; set; }
    public string? Actual { get; set; }
    public int ProcessingGoodExportOrderId { get; set; }
    public ProcessingGoodExportOrder ProcessingGoodExportOrder { get; set; }
#pragma warning restore
}
