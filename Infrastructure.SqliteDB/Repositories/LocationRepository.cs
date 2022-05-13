namespace Persistence.SqliteDB.Repositories;

public class LocationRepository: ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task ClearAll()
    {
        var item = await _context.containerLocations.ToListAsync();
         _context.containerLocations.RemoveRange(item);
    }

    public async Task  InsertAsync(List<ContainerLocation> containers)
    {
        await _context.containerLocations.AddRangeAsync(containers);
    }
    public async Task<ContainerLocation> LoadForIndex(int id)
    {
        var result = await _context.containerLocations.Where(s => s.Id == id).FirstOrDefaultAsync();
        return result;
    }
}
