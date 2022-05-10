using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using WarehouseManagementDesktopApp.Core.Domain.Model;
using WarehouseManagementDesktopApp.Core.Domain.Communication;
using WarehouseManagementDesktopApp.Core.Domain.Model.Api;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces
{
    public interface IApiService
    {
        //Task<ServiceResourceResponse<WarehouseEmployee>> LogInAsync (string username, string password);
        Action LoginCompleteAction { get; set; }
        Task<ServiceResponse> LogInAsync(string? token, Error error);
        void LogOut();
        Task<ServiceResourceResponse<QueryResult<Product>>> GetAllProduct();
        Task<ServiceResponse> PostNewProduct(NewProduct resource);
        Task<ServiceResourceResponse<Shelf>> GetShelf(string shelfId);
        Task<ServiceResourceResponse<QueryResult<Product>>> GetProductById(string productId);
        Task<ServiceResourceResponse<IEnumerable<StorageSlot>>> GetStorageID();

        Task<ServiceResponse> PathSliceItem(string shelfId, int rowId, int cellId, int sliceId, string productId);
        Task<ServiceResourceResponse<Basket>> GetBasketById(string basketId);
        Task<ServiceResponse> PostGoodsReceipts(GoodReceiptEntry resource);
        Task<ServiceResponse> PutBasket(string id, GoodsReceiptEntryPutAPI entry);
        Task<ServiceResponse> PostNewBasket(NewBasket newBasket);


        Task<ServiceResponse> PostGoodsIssue(GoodIssueEntry resource);
        Task<ServiceResponse> PatchGoodsIssueEntryBasket(List<PatchGoodsIssueEntryBasket> resource, string goodsIssueId);
        Task<ServiceResourceResponse<GoodsIssueById>> GetGoodsIssueById(string goodsIssueId);


        Task<ServiceResourceResponse<QueryStockCard<StockCardEntry>>> GetAllStockCard(DateTime? startTime, string product);
        Task<ServiceResourceResponse<QueryResult<HistoryEntries>>> GetGoodsReceipt(DateTime startTime, DateTime stopTime);
        Task<ServiceResourceResponse<QueryResult<HistoryGoodsIssue>>> GetGoodsIssue(DateTime startTime, DateTime stopTime);

        Task<ServiceResourceResponse<List<BasketInconsistency>>> GetUnfixedInconsistencies();
        Task<ServiceResourceResponse<QueryResult<BasketInconsistency>>> GetListOfUnconsistencies(DateTime startTime, DateTime stopTime);
    }
}
