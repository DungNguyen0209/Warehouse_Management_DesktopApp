namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProcessingGoodExportOrderRepository
{
    //public void InsertAsync(ProcessingGoodExportOrder data);
    public void DeleteAsync();
    public Task<List<ProcessingGoodExportOrder>> LoadAsync();
    public  void UpdateAsync(ProcessingGoodExportOrder data);
}
