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

    public async Task ClearAll()
    {
        var items = await _context.Products.ToListAsync();
        _context.Products.RemoveRange(items);
    }

    public async Task  InsertAsync(List<Product> product)
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
