using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.SqliteDB.Context;

//public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//{
//    public ApplicationDbContext CreateDbContext(string[] args = null)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

//        optionsBuilder.UseSqlite("Data Source=SqLite.db", x => x.MigrationsAssembly("WarehouseManagementDesktopApp"));

//        return new ApplicationDbContext(optionsBuilder.Options);
//    }
//}
