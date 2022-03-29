using WarehouseManagementDesktopApp.Views.GoodLocations;

namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)     
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));


            });

            return host;
        }
    }
}
