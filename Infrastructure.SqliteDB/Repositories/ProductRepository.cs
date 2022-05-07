using Persistence.SqliteDB.Context;
using Persistence.SqliteDB.Domain.Interfaces;

namespace Persistence.SqliteDB.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void ClearAll()
    {
        _context.Products.FromSqlRaw("DELETE FROM [Products]");
    }

    public async void InsertAsync(List<Product> product)
    {
        await _context.Products.AddRangeAsync(product);
    }

    public async Task<List<Product>> LoadAsyncSuggestName(string name)
    {
        var list = await _context.Products.Where(s => _context.Products.Any(c =>s.Name.StartsWith(name))).ToListAsync();
        //var list = await _context.Products.ToListAsync();
        return list;
    }

}
