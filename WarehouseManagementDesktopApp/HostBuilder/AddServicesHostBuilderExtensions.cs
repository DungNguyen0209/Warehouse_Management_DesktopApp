
namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddTransient<NavigationStore>();
                //services.AddTransient<ISignalRService, SignalRService>();

            });

            return host;
        }
    }
}
