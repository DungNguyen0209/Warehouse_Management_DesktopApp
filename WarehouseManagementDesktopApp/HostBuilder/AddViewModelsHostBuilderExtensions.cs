using WarehouseManagementDesktopApp.Core.ViewModel.BaseViewModels;

namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<GoodReceiptViewModel>();
                services.AddSingleton<GoodReceiptOrderViewModel>();
                services.AddSingleton<GoodExportViewModel>();
                services.AddSingleton<GoodLocationViewModel>();
                services.AddSingleton<ProcessingGoodExportViewModel>();

                services.AddSingleton<GoodReceiptOrderViewModel>();

                services.AddSingleton<GoodExportLayOutViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodExportStore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new GoodExportLayOutViewModel(goodExportStore, CreateGoodExportNavigationService(serviceprovider, goodExportStore), CreateProcessGoodExportNavigationService(serviceprovider, goodExportStore));
                });
                services.AddSingleton<MainViewModel>((IServiceProvider serviceprovider) =>
                {
                    var MainStore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new MainViewModel(MainStore, CreateLoginNavigationService(serviceprovider, MainStore), CreateGoodReceiptOrderNavigationService(serviceprovider, MainStore), CreateGoodLocationNavigationService(serviceprovider, MainStore));
                });
            });

            return host;
        }
        private static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider,NavigationStore store)
        {
            return new NavigationService<LoginViewModel>(
                store,
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }
        private static INavigationService CreateGoodReceiptNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodReceiptViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodReceiptViewModel>());
        }
        private static INavigationService CreateGoodReceiptOrderNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodReceiptOrderViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodReceiptOrderViewModel>());
        }
        private static INavigationService CreateLayOutGoodExportNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodExportLayOutViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodExportLayOutViewModel>());
        }
        private static INavigationService CreateGoodExportNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodExportViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodExportViewModel>());
        }
        private static INavigationService CreateProcessGoodExportNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<ProcessingGoodExportViewModel>(
                store,
                () => serviceProvider.GetRequiredService<ProcessingGoodExportViewModel>());
        }
        private static INavigationService CreateGoodLocationNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodLocationViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodLocationViewModel>());
        }
    }
}
