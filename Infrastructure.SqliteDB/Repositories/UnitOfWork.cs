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
        _context.Entry(_context).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        //await _context.SaveChangesAsync();
    }
    //private bool disposed = false;

    //protected virtual void Dispose(bool disposing)
    //{
    //    if (!this.disposed)
    //    {
    //        if (disposing)
    //        {
    //            _context.Dispose();
    //        }
    //    }
    //    this.disposed = true;
    //}
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
