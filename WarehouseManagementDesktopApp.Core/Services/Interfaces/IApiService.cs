using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using WarehouseManagementDesktopApp.Core.Domain.Model;
using WarehouseManagementDesktopApp.Core.Domain.Communication;
using WarehouseManagementDesktopApp.Core.Domain.Model.Api;
using WarehouseManagementDesktopApp.Core.Domain.Model.API.Report;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces
{
    public interface IApiService
    {
        //Task<ServiceResourceResponse<WarehouseEmployee>> LogInAsync (string username, string password);
        Action LoginCompleteAction { get; set; }
        Action LogoutCompleteAction { get; set; }
        Task<ServiceResponse> LogInAsync(string? token, Error error);
        void LogOut();
        Task<ServiceResourceResponse<QueryResult<Product>>> GetAllProduct();
        Task<ServiceResponse> PatchContainerGoodsReceipts(List<ContainerGoodReceipt> resource, string id);
        Task<ServiceResponse> PatchConFirmGoodsReceipts(string id);
        Task<ServiceResourceResponse<Product>> GetProductbyId(string id);
        Task<ServiceResponse> PostNewProduct(NewProduct resource);
        Task<ServiceResourceResponse<Shelf>> GetShelf(string shelfId);
        Task<ServiceResourceResponse<Cell>> GetCell(string shelfId, int rowId, int cellId);
        Task<ServiceResourceResponse<List<WarningStockCard>>> GetUnderStockCards();
        Task<ServiceResourceResponse<List<WarningStockCard>>> GetOverStockCards();
        Task<ServiceResourceResponse<GoodIssueFromServer>> GetGoodsIssueByTime(DateTime date);
        Task<ServiceResourceResponse<QueryResult<Product>>> GetProductById(string productId);
        Task<ServiceResourceResponse<IEnumerable<StorageSlot>>> GetStorageID();

        Task<ServiceResponse> PathSliceItem(string shelfId, int rowId, int cellId, int sliceId, string productId);
        Task<ServiceResourceResponse<List<Container>>> GetContainerByProductId(string Id);
        Task<ServiceResourceResponse<Container>> GetContainerById(string containerId);
        Task<ServiceResponse> PostGoodsReceipts(GoodReceiptEntry resource);
        Task<ServiceResponse> PutBasket(string id, GoodsReceiptEntryPutAPI entry);
        Task<ServiceResponse> PostNewBasket(NewBasket newBasket);

        Task<ServiceResponse> PostGoodsIssue(GoodIssueEntry resource);
        Task<ServiceResponse> PatchGoodsIssueEntryContainer(List<IssueEntryContainer> resource, string goodsIssueId);
        Task<ServiceResourceResponse<GoodsIssueById>> GetGoodsIssueById(string goodsIssueId);
        Task<ServiceResponse> PatchConFirmGoodsIssue(string id, List<string> containerId);


        Task<ServiceResourceResponse<List<Stockcardentries>>> GetAllStockCard(DateTime? startTime, DateTime? stopTime, string product);
        Task<ServiceResourceResponse<GoodReceiptReport>> GetGoodsReceipt(DateTime startTime, DateTime stopTime);
        Task<ServiceResourceResponse<GoodReceiptReport>> GetUnfinishedGoodsReceipt(DateTime startTime, DateTime stopTime);
        Task<ServiceResourceResponse<GoodExportReport>> GetGoodsIssue(DateTime startTime, DateTime stopTime);

        Task<ServiceResourceResponse<List<BasketInconsistency>>> GetUnfixedInconsistencies();
        Task<ServiceResourceResponse<QueryResult<BasketInconsistency>>> GetListOfUnconsistencies(DateTime startTime, DateTime stopTime);
    }
}
