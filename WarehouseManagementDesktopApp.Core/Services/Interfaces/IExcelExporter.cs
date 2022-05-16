namespace WarehouseManagementDesktopApp.Core.Services.Interfaces;

public interface IExcelExporter
{
    string FilePath { get; set; }

    ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> ReadReceipt();
    Task<ServiceResponse> ExportGoodIssue(RangeObservableCollection<ContainerIssueEntry> ContainerEntry);
}
