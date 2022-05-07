using Persistence.SqliteDB.Model;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface IProductsDatabaseService
{
     Task<IList<Product>>? LoadSuggestName(string firstname);
     void Clear();
    void Insert(List<Product> products);
}
