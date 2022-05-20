using Persistence.SqliteDB.Model;
using Product = Persistence.SqliteDB.Model.Product;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface IProductsDatabaseService
{
     Task<IList<Product>>? LoadSuggestName(string firstname);
     Task<IList<Product>>? LoadAllProduct();
    void Clear();
    void Insert(List<Product> products);
}
