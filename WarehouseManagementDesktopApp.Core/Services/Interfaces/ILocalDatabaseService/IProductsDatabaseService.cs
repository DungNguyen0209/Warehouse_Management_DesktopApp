using Persistence.SqliteDB.Model;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface IProductsDatabaseService
{
    public Task<IList<Product>>? LoadSuggestName(string firstname);
}
