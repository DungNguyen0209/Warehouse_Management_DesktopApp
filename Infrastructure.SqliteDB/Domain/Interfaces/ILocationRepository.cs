namespace Persistence.SqliteDB.Domain.Interfaces;

public interface ILocationRepository
{
    Task ClearAll();
    Task InsertAsync(List<ContainerLocation> containers);
    Task<ContainerLocation> LoadForIndex(int id);

}
