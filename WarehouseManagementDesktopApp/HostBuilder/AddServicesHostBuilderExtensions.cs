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
                services.AddSingleton<WebBrowserContainer>();
                services.AddSingleton<IGoodSlotService, GoodSlotService>();
                services.AddSingleton<IExcelExporter, ExcelExporterService>();
                services.AddSingleton<IApiService, ApiService>();
                services.AddSingleton<IProductsDatabaseService, ProductsDatabaseService>((services =>
                {
                    return new ProductsDatabaseService(services.GetRequiredService<IProductRepository>(), services.GetRequiredService<IUnitOfWork>());
                }));
                services.AddSingleton<IProcessingGoodExportOrderDatabaseService, ProcessingGoodExportOrderDatabaseService>((services =>
                {
                    return new ProcessingGoodExportOrderDatabaseService(services.GetRequiredService<IProcessingGoodExportOrderRepository>(), services.GetRequiredService<IUnitOfWork>());
                }));
                services.AddSingleton<ILocationDatabaseService, LocationDatabaseService>((services =>
                {
                    return new LocationDatabaseService( services.GetRequiredService<IUnitOfWork>(), services.GetRequiredService<ILocationRepository>(), services.GetRequiredService<IMapper>()) ;
                }));
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AllowNullCollections = true;
                    mc.AddProfiles(new Profile[] { new ModelAndModelForView(), new LogicModelandDatabasModel()});
                });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
                services.AddSingleton<EmbeddedBrowserService>();
                services.AddSingleton<IOidcClientService, OidcClientService>((services =>
                {
                    return new OidcClientService(services.GetRequiredService<IApiService>(),services.GetRequiredService<EmbeddedBrowserService>());
                }));
                services.AddSingleton<IStartProgramService, StartProgramService>((services =>
                {
                    return new StartProgramService(services.GetRequiredService<IApiService>(), services.GetRequiredService<IProductsDatabaseService>(), services.GetRequiredService<IMapper>(), services.GetRequiredService<WebBrowserContainer>(), services.GetRequiredService<IOidcClientService>());
                }));
            });

            return host;
        }
    }
}
