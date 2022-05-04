
namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProductRepository
{
    public void InsertAsync(Product product);
    public void DeleteAsync(Product product);
    public Task<List<Product>> LoadAsyncSuggestName(string name);
}
