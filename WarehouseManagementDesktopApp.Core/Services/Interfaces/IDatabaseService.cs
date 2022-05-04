using WarehouseManagementDesktopApp.Core.Domain.Communication;
using WarehouseManagementDesktopApp.Core.Domain.Model;
using WarehouseManagementDesktopApp.Core.Domain.Model.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces
{
    public interface IDatabaseService
    {
        Task<ServiceResponse> InsertGoodsReceiptEntry(GoodsReceiptEntryResource entry);
        Task<ServiceResponse> DeleteGoodsReceiptEntry(GoodsReceiptEntryResource entry);
        Task<ServiceResponse> UpdateGoodsReceiptEntry(GoodsReceiptEntryResource entry);
        Task<ServiceResponse> ClearGoodsReceiptEntry();

        Task<ServiceResourceResponse<GoodsReceiptEntryResource>> FindGoodsReceiptEntryByBasketId(string id);
        Task<ServiceResourceResponse<IEnumerable<GoodsReceiptEntryResource>>> LoadGoodsReceiptEntry();


        Task<IEnumerable<GoodsIssueEntry>> LoadGoodsIssueEntry();
        Task<IEnumerable<GoodsIssueEntryBasket>> LoadGoodsIssueEntryBasket();
        Task<ServiceResourceResponse<GoodsIssueEntry>> FindGoodsIssueEntryByProductId(string productId, string goodsIssueId);
        Task<ServiceResponse> UpdateGoodsIssueEntry(GoodsIssueEntry entry);

        Task<ServiceResponse> InsertGoodsIssueEntry(GoodsIssueEntry entry);
        Task<ServiceResponse> InsertGoodsIssueEntryBasket(GoodsIssueEntryBasket entry);
        Task<ServiceResponse> UpdateGoodsIssueEntryBasket(GoodsIssueEntryBasket entry);
        Task<ServiceResponse> ClearGoodsIssue();
        Task<ServiceResponse> ClearGoodsIssueEntries();
    }
}
