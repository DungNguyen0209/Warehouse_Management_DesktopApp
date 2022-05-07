
namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProductRepository
{
    public void InsertAsync(List<Product> product);
    public void ClearAll();
    public Task<List<Product>> LoadAsyncSuggestName(string name);
}
