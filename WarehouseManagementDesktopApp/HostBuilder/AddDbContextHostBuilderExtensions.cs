namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
               // services.AddSingleton<ApplicationDbContext>(new ApplicationDbContext());
            });

            return host;
        }
    }
}
