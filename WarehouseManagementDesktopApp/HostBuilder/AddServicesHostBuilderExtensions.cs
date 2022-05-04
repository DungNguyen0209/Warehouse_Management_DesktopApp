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

            });

            return host;
        }
    }
}
