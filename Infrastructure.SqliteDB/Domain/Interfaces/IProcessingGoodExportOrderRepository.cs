namespace Persistence.SqliteDB.Domain.Interfaces;

public interface IProcessingGoodExportOrderRepository
{
    //public void InsertAsync(ProcessingGoodExportOrder data);
      Task DeleteAsync();
     Task<List<ProcessingGoodExportOrder>> LoadAsync();
      Task UpdateAsync(ProcessingGoodExportOrder data);
    Task<List<IssueBasket>> LoadBaseket(int id);
}
