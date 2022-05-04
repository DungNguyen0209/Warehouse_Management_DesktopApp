namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class IssueBasketList
{
#pragma warning disable CS8618
    public int Id { get; set; }
    public ICollection<IssueBasket>? Baskets { get; set; }
    public int ProcessingGoodExportOrderId { get; set; }
    public ProcessingGoodExportOrder ProcessingGoodExportOrder { get; set; }
#pragma warning restore
}
