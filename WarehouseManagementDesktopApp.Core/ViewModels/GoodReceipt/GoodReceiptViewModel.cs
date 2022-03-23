
namespace WarehouseManagementDesktopApp.Core.ViewModels
{
    public class GoodReceiptViewModel: ViewModel.BaseViewModels.BaseViewModel
    {
        public ObservableCollection<GoodReceiptView> ProductItemsSource { get; set; }
        public GoodReceiptViewModel()
        {
            ProductItemsSource = new ObservableCollection<GoodReceiptView>();
            var item = new GoodReceiptView() { Id = "1", Name = "Minh Dũng nè", Quantity = 1, Unit = "cái" };
            ProductItemsSource.Add(item);
        }

    }
}
