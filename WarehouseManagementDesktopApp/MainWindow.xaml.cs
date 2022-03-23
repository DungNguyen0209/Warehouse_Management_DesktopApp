namespace WarehouseManagementDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Object DataContext)
        {
            InitializeComponent();
            this.DataContext = DataContext; 
            this.StateChanged += new EventHandler(MainWindow_StateChanged);
        }
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState == WindowState.Minimized)
            {
                return;
            }    
            if (this.WindowState == WindowState.Normal)
            {
                this.Width = SystemParameters.PrimaryScreenWidth * 0.7;
                this.Height = SystemParameters.PrimaryScreenHeight * 0.7;
                Loginbtn.UpdateMinimizedUI();
                Settingbtn.UpdateMinimizedUI();
                Supervisorbtn.UpdateMinimizedUI();
                Reporttn.UpdateMinimizedUI();
                Historybtn.UpdateMinimizedUI();
                Alertbtn.UpdateMinimizedUI();
                Helpbtn.UpdateMinimizedUI();
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                Loginbtn.UpdateNormalUI();
                Settingbtn.UpdateNormalUI();
                Supervisorbtn.UpdateNormalUI();
                Historybtn.UpdateNormalUI();    
                Alertbtn.UpdateNormalUI();
                Reporttn.UpdateNormalUI();
                Helpbtn.UpdateNormalUI();
            }
        }
    }
}
