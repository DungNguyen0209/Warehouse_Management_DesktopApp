
namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                //Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite("Data Source=SqLite.db");
                services.AddDbContext<ApplicationDbContext>();
                //services.AddSingleton<ApplicationDBContextFactory>(new ApplicationDBContextFactory());
                services.AddScoped<IProductRepository, ProductRepository>(serviceproviders =>
                {
                    return new ProductRepository(serviceproviders.GetRequiredService<ApplicationDbContext>());
                });
                services.AddScoped<IProcessingGoodExportOrderRepository, ProcessingGoodExportOrderRepository>(serviceproviders =>
                 {
                     return new ProcessingGoodExportOrderRepository(serviceproviders.GetRequiredService<ApplicationDbContext>());
                 });
                services.AddScoped<ILocationRepository, LocationRepository>(serviceproviders =>
                {
                    return new LocationRepository(serviceproviders.GetRequiredService<ApplicationDbContext>());
                });
                services.AddScoped<IUnitOfWork, UnitOfWork>((serviceproviders =>
                {
                    return new UnitOfWork(serviceproviders.GetRequiredService<ApplicationDbContext>());
                }));
            });

            return host;
        }
    }
}
