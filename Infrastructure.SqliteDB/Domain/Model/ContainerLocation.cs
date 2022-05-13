namespace Persistence.SqliteDB.Domain.Model;

public class ContainerLocation
{
    public int Id { get; set; }
    public string shelfId { get; set; }
    public int rowId { get; set; }
    public int cellId { get; set; }
}
