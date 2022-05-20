
namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProductRepository
{
    Task InsertAsync(List<Product> product);
    Task ClearAll();
    Task<List<Product>> LoadAsyncSuggestName(string name);
    Task<List<Product>> LoadAllItem();
}
