namespace WarehouseManagementDesktopApp.Views.GoodReceipts
{
    /// <summary>
    /// Interaction logic for GoodReceiptView.xaml
    /// </summary>
    public partial class GoodReceiptView : UserControl
    {
        public GoodReceiptView()
        {
            InitializeComponent();   
        }

        private void TargetTypecb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TargetTypecb.SelectedIndex)
            {
                case 0:
                    AddQuantitytb.IsReadOnly = false;
                    Quantitytb.IsEnabled = false;
                    break;
                case 1:
                    AddQuantitytb.IsReadOnly = false;
                    Quantitytb.IsEnabled = false;
                    break;
                case 2:
                    AddQuantitytb.Text = null;
                    Quantitytb.IsEnabled = true;
                    break;
            }
        }

    }
}
