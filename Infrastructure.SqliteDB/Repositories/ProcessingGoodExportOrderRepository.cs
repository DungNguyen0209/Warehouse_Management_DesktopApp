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
        _context.Database.ExecuteSqlRaw("DELETE FROM [processingGoodExportOrders]");
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

    public async void UpdateAsync(ProcessingGoodExportOrder data)
    {
        if (_context.processingGoodExportOrders.Any(s => s.orderId == data.orderId))
        {

            _context.processingGoodExportOrders.Update(data);
        }
        else
        {
            var count = _context.processingGoodExportOrders.Count();
            data.Id = count+1;
            _context.processingGoodExportOrders.Add(data);
        }
    }
}
