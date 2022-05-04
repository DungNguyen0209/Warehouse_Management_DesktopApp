using AutoMapper;
using Persistence.SqliteDB.Domain.Interfaces;
using Persistence.SqliteDB.Repositories;

namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddTransient<NavigationStore>();
                services.AddSingleton<GoodReceiptNavigationStore>();
                services.AddSingleton<LoginNavigationStore>();
                services.AddSingleton<IGoodSlotService, GoodSlotService>();
                services.AddSingleton<IExcelExporter, ExcelExporterService>();
                services.AddSingleton<IProductsDatabaseService, ProductsDatabaseService>((services =>
                {
                    return new ProductsDatabaseService(services.GetRequiredService<IProductRepository>(), services.GetRequiredService<IUnitOfWork>());
                }));
                services.AddSingleton<IProcessingGoodExportOrderDatabaseService, ProcessingGoodExportOrderDatabaseService>((services =>
                {
                    return new ProcessingGoodExportOrderDatabaseService(services.GetRequiredService<IProcessingGoodExportOrderRepository>(), services.GetRequiredService<IUnitOfWork>());
                }));
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AllowNullCollections = true;
                    mc.AddProfile(new ModelAndModelForView());
                });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
            });

            return host;
        }
    }
}
