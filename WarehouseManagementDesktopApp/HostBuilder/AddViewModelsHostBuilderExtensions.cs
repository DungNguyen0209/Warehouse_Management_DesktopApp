namespace WarehouseManagementDesktopApp.HostBuilder
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddTransient<ChatMessageListDesignModel>();
                services.AddTransient<LocationCardItemViewModel>();
                services.AddTransient<LocationCardItemListViewModel>();
                services.AddTransient<DialogGoodIssueViewModel>();
                services.AddTransient<MessageBoxViewModel>();
                services.AddSingleton<LoginViewModel>((IServiceProvider serviceprovider) =>
                {
                    return new LoginViewModel(serviceprovider.GetRequiredService<IOidcClientService>());
                });
                services.AddSingleton<NotifyViewModel>((IServiceProvider serviceprovider) =>
                {
                    var LoginStore = serviceprovider.GetRequiredService<LoginNavigationStore>();
                    return new NotifyViewModel(LoginStore, CreateLoginNavigationService(serviceprovider, LoginStore),serviceprovider.GetRequiredService<ChatMessageListDesignModel>());
                });
                services.AddSingleton<LoginLayOutViewModel>((IServiceProvider serviceprovider) =>
                {
                    var LoginStore = serviceprovider.GetRequiredService<LoginNavigationStore>();
                    LoginStore.CurrentViewModel = serviceprovider.GetRequiredService<LoginViewModel>();
                    return new LoginLayOutViewModel(LoginStore);

                });
                services.AddSingleton<GoodReceiptOrderViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodReceiptStore = serviceprovider.GetRequiredService<GoodReceiptNavigationStore>();
                    return new GoodReceiptOrderViewModel(goodReceiptStore, CreateGoodReceiptNavigationService(serviceprovider, goodReceiptStore),serviceprovider.GetRequiredService<IExcelExporter>(), serviceprovider.GetRequiredService<ChatMessageListDesignModel>(), serviceprovider.GetRequiredService<IApiService>(), serviceprovider.GetRequiredService<IMapper>());
                });
                services.AddSingleton<GoodExportViewModel>((IServiceProvider serviceprovider) =>
                {
                    return new GoodExportViewModel(serviceprovider.GetRequiredService<DialogGoodIssueViewModel>(),serviceprovider.GetRequiredService<IProcessingGoodExportOrderDatabaseService>(),serviceprovider.GetRequiredService<IExcelExporter>(), serviceprovider.GetRequiredService<IMapper>(),serviceprovider.GetRequiredService<IApiService>());
                });
                services.AddSingleton<GoodLocationViewModel>();
                services.AddSingleton<UpdateGoodLocationViewModel>(
                    (IServiceProvider serviceprovider) =>
                    {
                        return new UpdateGoodLocationViewModel(serviceprovider.GetRequiredService<IApiService>());
                    });
                services.AddSingleton<ProcessingGoodExportViewModel>();
                services.AddSingleton<ReportViewModel>();
                services.AddSingleton<HistoryViewModel>();

                services.AddSingleton<GoodReceiptViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodReceiptStore = serviceprovider.GetRequiredService<GoodReceiptNavigationStore>();
                    return new GoodReceiptViewModel(goodReceiptStore, CreateGoodReceiptOrderNavigationService(serviceprovider, goodReceiptStore),serviceprovider.GetRequiredService<IProductsDatabaseService>()) ;
                });
                services.AddSingleton<GoodReceiptLayOutViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodReceiptLayOutrStore = serviceprovider.GetRequiredService<GoodReceiptNavigationStore>();
                    var goodReceiptLayOutViewModel = new GoodReceiptLayOutViewModel(goodReceiptLayOutrStore);
                    goodReceiptLayOutViewModel.CurrentViewModel = serviceprovider.GetRequiredService<GoodReceiptViewModel>();
                    return goodReceiptLayOutViewModel;
                });

                services.AddSingleton<GoodExportLayOutViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodExportStore = serviceprovider.GetRequiredService<NavigationStore>();
                    goodExportStore.CurrentViewModel = serviceprovider.GetRequiredService<GoodExportViewModel>();
                    return new GoodExportLayOutViewModel(goodExportStore, CreateGoodExportNavigationService(serviceprovider, goodExportStore), CreateProcessGoodExportNavigationService(serviceprovider, goodExportStore));
                });
                services.AddSingleton<GoodLocationLayOutViewModel>((IServiceProvider serviceprovider) =>
                {
                    var goodLocationStore = serviceprovider.GetRequiredService<NavigationStore>();
                    goodLocationStore.CurrentViewModel = serviceprovider.GetRequiredService<GoodLocationViewModel>();
                    return new GoodLocationLayOutViewModel(goodLocationStore,CreateGoodLocationNavigationService(serviceprovider,goodLocationStore),CreateUpdateLocationNavigationService(serviceprovider,goodLocationStore));
                });
                services.AddSingleton<MainViewModel>((IServiceProvider serviceprovider) =>
                {
                    var MainStore = serviceprovider.GetRequiredService<NavigationStore>();
                    MainStore.CurrentViewModel = serviceprovider.GetRequiredService<LoginViewModel>();   
                    return new MainViewModel(MainStore, CreateLoginNavigationService(serviceprovider, MainStore), CreateLayOutGoodRecieptNavigationService(serviceprovider, MainStore), CreateLayOutGoodExportNavigationService(serviceprovider, MainStore), CreateGoodLocationLayOutNavigationService(serviceprovider, MainStore), CreateReportNavigationService(serviceprovider, MainStore), CreateHistoryNavigationService(serviceprovider, MainStore),serviceprovider.GetRequiredService<IApiService>(),serviceprovider.GetRequiredService<IProductsDatabaseService>(),serviceprovider.GetRequiredService<IMapper>(),serviceprovider.GetRequiredService<IStartProgramService>());
                });
            });

            return host;
        }

        private static INavigationService CreateGoodLocationNavigationService(IServiceProvider serviceprovider, NavigationStore store)
        {
            return new NavigationService<GoodLocationViewModel>(
                store,
                () => serviceprovider.GetRequiredService<GoodLocationViewModel>());
        }

        private static INavigationService CreateUpdateLocationNavigationService(IServiceProvider serviceprovider, NavigationStore store)
        {
            return new NavigationService<UpdateGoodLocationViewModel>(
                store,
                () => serviceprovider.GetRequiredService<UpdateGoodLocationViewModel>());
        }

        private static INavigationService CreateLayOutNavigationService(IServiceProvider serviceprovider, NavigationStore store)
        {
            return new NavigationService<LoginLayOutViewModel>(
                store,
                () => serviceprovider.GetRequiredService<LoginLayOutViewModel>());
        }

        private static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider, NavigationStore store)
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
        private static INavigationService CreateGoodLocationLayOutNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodLocationLayOutViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodLocationLayOutViewModel>());
        }
        private static INavigationService CreateLayOutGoodRecieptNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<GoodReceiptLayOutViewModel>(
                store,
                () => serviceProvider.GetRequiredService<GoodReceiptLayOutViewModel>());
        }
        private static INavigationService CreateReportNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<ReportViewModel>(
                store,
                () => serviceProvider.GetRequiredService<ReportViewModel>());
        }
        private static INavigationService CreateHistoryNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<HistoryViewModel>(
                store,
                () => serviceProvider.GetRequiredService<HistoryViewModel>());
        }
        private static INavigationService CreateNotifyNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<NotifyViewModel>(
                store,
                () => serviceProvider.GetRequiredService<NotifyViewModel>());
        }
    }
}
