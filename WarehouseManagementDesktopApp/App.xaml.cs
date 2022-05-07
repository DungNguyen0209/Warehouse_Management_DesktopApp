

using Persistence.SqliteDB;
using System.Globalization;
using System.Threading;

namespace WarehouseManagementDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                        .AddDbContext()
                        .AddServices()
                        .AddViewModels()
                        .AddViews();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow window = _host.Services.GetRequiredService<MainWindow>();
            var loginbrowser = _host.Services.GetRequiredService<LoginViewModel>();
            var startupservice = _host.Services.GetRequiredService<IStartProgramService>();
            window.Show();
           // startupservice.LoadLoginView();
            //Thread thread = new Thread(startupservice.LoadProgram);
            //thread.Start();


            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
