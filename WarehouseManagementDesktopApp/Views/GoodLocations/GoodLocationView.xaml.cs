namespace WarehouseManagementDesktopApp.Views.GoodLocations
{
    /// <summary>
    /// Interaction logic for GoodLocationView.xaml
    /// </summary>
    public partial class GoodLocationView : UserControl
    {



        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoodLocationViewModelProperty =
            DependencyProperty.RegisterAttached("GoodLocationViewModel", typeof(GoodLocationViewModel), typeof(GoodLocationView), new PropertyMetadata());


        public GoodLocationViewModel GoodLocationViewModel
        {
            get { return (GoodLocationViewModel)GetValue(GoodLocationViewModelProperty); }
            set { SetValue(GoodLocationViewModelProperty, value); }
        }
        public GoodLocationView()
        {
            InitializeComponent();
            GoodLocationViewModel.AddImageEvent += AddImage;
        }

        private void AddImage()
        {
            throw new NotImplementedException();
        }
    }
}
