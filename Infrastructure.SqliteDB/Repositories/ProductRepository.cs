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

    public void DeleteAsync(Product product)
    {
        _context.Remove<Product>(product);
    }

    public  void InsertAsync(Product product)
    {
         _context.Products.Add(product);
        _context.SaveChanges();
    }

    public async Task<List<Product>> LoadAsyncSuggestName(string name)
    {
        var list = await _context.Products.Where(s => _context.Products.Any(c =>s.Name.StartsWith(name))).ToListAsync();
        //var list = await _context.Products.ToListAsync();
        return list;
    }

}
