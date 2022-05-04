using Persistence.SqliteDB.Model;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface IProductsDatabaseService
{
    IList<Product> LoadSuggestName(string firstname);
}
