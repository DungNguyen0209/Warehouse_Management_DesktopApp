namespace Persistence.SqliteDB.Repositories;
public class ProcessingGoodExportOrderRepository : IProcessingGoodExportOrderRepository
{
    private readonly ApplicationDbContext _context;

    public ProcessingGoodExportOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync()
    {
        var items = await _context.processingGoodExportOrders.ToListAsync();
        _context.processingGoodExportOrders.RemoveRange(items);
    }

    //public async void InsertAsync(ProcessingGoodExportOrder data)
    //{
    //    await _context.processingGoodExportOrders.AddAsync(data);
    //}

    public async Task<List<ProcessingGoodExportOrder>> LoadAsync()
    {
        var data = await _context.processingGoodExportOrders.Include(s => s.formulaListGoodIssues).ThenInclude(p => p.Baskets).ToListAsync();
        return data;
    }

    public async Task<List<IssueBasket>> LoadBaseket(int id)
    {
        var baskets = await _context.issueBaskets.Where(s => s.FormulaListGoodIssueId == id).ToListAsync();
        return baskets;
    }

    public async Task UpdateAsync(ProcessingGoodExportOrder data)
    {
        //foreach(var)
        //_context.issueBasketLists.Attach(data.issueBasketLists);

        if (_context.processingGoodExportOrders.Any(s => s.orderId == data.orderId))
        {

            _context.processingGoodExportOrders.Update(data);
        }
        else
        {
            var count = _context.processingGoodExportOrders.Count();
            data.Id = count + 1;
            _context.processingGoodExportOrders.Add(data);
        }
    }
}
