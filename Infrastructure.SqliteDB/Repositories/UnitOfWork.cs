using Microsoft.EntityFrameworkCore;
using Persistence.SqliteDB.Context;
using Persistence.SqliteDB.Domain.Interfaces;

namespace Persistence.SqliteDB.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void DetachChange()
    {
        var changedEntriesCopy = _context.ChangeTracker.Entries()
            .Where(e => e.State == (EntityState)EntityState.Added ||
                        e.State == (EntityState)EntityState.Modified ||
                        e.State == (EntityState)EntityState.Deleted ||
                        e.State == (EntityState)EntityState.Unchanged)
            .ToList();

        foreach (var entry in changedEntriesCopy)
            entry.State = (EntityState)EntityState.Detached;

    }

    //public void Dispose()
    //{
    //    Dispose(true);
    //    GC.SuppressFinalize(this);
    //}
}
