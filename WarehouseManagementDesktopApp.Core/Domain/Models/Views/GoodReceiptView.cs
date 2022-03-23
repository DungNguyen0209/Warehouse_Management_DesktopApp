namespace WarehouseManagementDesktopApp.Core.Domain.Models.Views
{
    public class GoodReceiptView
    {
        [DisplayName("Mã Sản Phầm")]
        public string Id { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        public string Name { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Đơn Vị")]
        public string Unit { get; set; }
    }
}
