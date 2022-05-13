
namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProductRepository
{
     Task InsertAsync(List<Product> product);
     Task  ClearAll();
    public Task<List<Product>> LoadAsyncSuggestName(string name);
}
