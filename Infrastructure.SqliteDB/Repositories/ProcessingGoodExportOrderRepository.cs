namespace Persistence.SqliteDB.Repositories;
public class ProcessingGoodExportOrderRepository : IProcessingGoodExportOrderRepository
{
    private readonly ApplicationDbContext _context;

    public ProcessingGoodExportOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void DeleteAsync()
    {
        _context.processingGoodExportOrders.FromSqlRaw<ProcessingGoodExportOrder>("TRUNCATE TABLE [processingGoodExportOrders]");
    }

    //public async void InsertAsync(ProcessingGoodExportOrder data)
    //{
    //    await _context.processingGoodExportOrders.AddAsync(data);
    //}

    public async Task<List<ProcessingGoodExportOrder>> LoadAsync()
    {
       var data = await _context.processingGoodExportOrders.ToListAsync();
        return data;
    }

    public void UpdateAsync(ProcessingGoodExportOrder data)
    {
        _context.Update<ProcessingGoodExportOrder>(data);
    }
}
