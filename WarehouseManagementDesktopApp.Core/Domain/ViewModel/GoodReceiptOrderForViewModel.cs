
namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel;

#pragma warning disable CS8618
public class GoodReceiptOrderForViewModel
{
    [DisplayName("STT")]
    public string? Id { get; set; }

    [DisplayName("Mã SP")]
    public string? ProductId { get; set; }

    [DisplayName("Tên SP")]
    public string? ProductName { get; set; }

    [DisplayName("Ngày SX")]

    public string? Quantity { get; set; }

    [DisplayName("Khối lượng")]
    public string? Mass { get; set; }
    [DisplayName("Đơn vị")]
    public string? Unit { get; set; }

    [DisplayName("Thông tin sản xuất")]
    public string? Infomartion { get; set; }


}
#pragma warning restore
