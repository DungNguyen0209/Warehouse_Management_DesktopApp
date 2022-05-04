namespace Persistence.SqliteDB.Domain.Model.GoodExport;

public class IssueBasketList
{
    public int Id { get; set; }
    public ICollection<IssueBasket>? Baskets { get; set; }
}
