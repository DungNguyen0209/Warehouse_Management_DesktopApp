using Persistence.SqliteDB.Domain.Model.GoodExport;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface IProcessingGoodExportOrderDatabaseService
{
    public void Update(ProcessingGoodExportOrder processingGoodExportOrder);
    public Task<List<ProcessingGoodExportOrder>> GetAll();
    public void Delete();
    Task<List<IssueBasket>> LoadBasket(int FormulaListGoodIssueId);
}
