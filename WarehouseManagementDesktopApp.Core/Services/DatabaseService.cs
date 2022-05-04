using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarehouseManagementDesktopApp.Core.Services.Interfaces;


//namespace WarehouseManagementDesktopApp.Core.Services
//{
//    public class DatabaseService : IDatabaseService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IGoodsReceiptEntryRepository _goodsReceiptEntryRepository;
//        private readonly IGoodsIssueEntryBasketRepository _goodsIssueEntryBasketRepository;
//        private readonly IGoodsIssueEntryRepository _goodsIssueEntryRepository;

//        public DatabaseService(IUnitOfWork unitOfWork, IGoodsReceiptEntryRepository goodsReceiptEntryRepository, IGoodsIssueEntryBasketRepository goodsIssueEntryBasketRepository, IGoodsIssueEntryRepository goodsIssueEntryRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _goodsReceiptEntryRepository = goodsReceiptEntryRepository;
//            _goodsIssueEntryBasketRepository = goodsIssueEntryBasketRepository;
//            _goodsIssueEntryRepository = goodsIssueEntryRepository;
//        }

//        public async Task<ServiceResponse> InsertGoodsReceiptEntry(GoodsReceiptEntryResource entry)
//        {
//            try
//            {
//                _goodsReceiptEntryRepository.Insert(entry);
//                await _unitOfWork.SaveChangeAsync();

//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Add",
//                    Message = "Bị trùng mã rổ, vui lòng kiểm tra lại"
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> DeleteGoodsReceiptEntry(GoodsReceiptEntryResource entry)
//        {
//            try
//            {
//                var result = await _goodsReceiptEntryRepository.FindGoodsReceiptEntryById(entry.BasketId);
//                _goodsReceiptEntryRepository.Delete(result);
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Delete",
//                    Message = "Không thể xóa mã rổ này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> UpdateGoodsReceiptEntry(GoodsReceiptEntryResource entry)
//        {
//            try
//            {
//                await _goodsReceiptEntryRepository.Update(entry);
//                await _unitOfWork.SaveChangeAsync();

//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Update",
//                    Message = "Không thể chỉnh sửa mã rổ này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> ClearGoodsReceiptEntry()
//        {
//            try
//            {
//                _goodsReceiptEntryRepository.Clear();
//                await _unitOfWork.SaveChangeAsync();

//                return ServiceResponse.Successful();
//            }
//            catch 
//            { 
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Clear",
//                    Message = "Không thể xóa được bảng này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }


//        public async Task<ServiceResourceResponse<GoodsReceiptEntryResource>> FindGoodsReceiptEntryByBasketId(string id)
//        {
//            try
//            {
//                var resultFindGoodsReceiptEntryById = await _goodsReceiptEntryRepository.FindGoodsReceiptEntryById(id);
//                return new ServiceResourceResponse<GoodsReceiptEntryResource>(resultFindGoodsReceiptEntryById);
//            }
//            catch 
//            {
//                var error = new Error
//                {
//                    ErrorCode = "Database.FindGoodsReceiptEntryById",
//                    Message = "Không tìm được mã đơn này."
//                };
//                return new ServiceResourceResponse<GoodsReceiptEntryResource>(error);
//            }
//        }
//        public async Task<ServiceResourceResponse<IEnumerable<GoodsReceiptEntryResource>>> LoadGoodsReceiptEntry()
//        {
//            try
//            {
//                var resultLoadGoodsReceiptEntry = await _goodsReceiptEntryRepository.Load();
//                return new ServiceResourceResponse<IEnumerable<GoodsReceiptEntryResource>>(resultLoadGoodsReceiptEntry);
//            }
//            catch 
//            {
//                var error = new Error
//                {
//                    ErrorCode = "Database.LoadGoodsReceipt",
//                    Message = "Không truy xuất được database."
//                };
//                return new ServiceResourceResponse<IEnumerable<GoodsReceiptEntryResource>>(error);
//            }
//        }

//        public async Task<IEnumerable<GoodsIssueEntry>> LoadGoodsIssueEntry()
//        {
//            return await _goodsIssueEntryRepository.Load();
//        }
//        public async Task<ServiceResourceResponse<GoodsIssueEntry>> FindGoodsIssueEntryByProductId(string productId, string goodsIssueId)
//        {
//            try
//            {
//                var resultFindGoodsReceiptEntryById = await _goodsIssueEntryRepository.FindGoodsIssueEntryByProductId(productId, goodsIssueId);
//                return new ServiceResourceResponse<GoodsIssueEntry>(resultFindGoodsReceiptEntryById);
//            }
//            catch
//            {
//                var error = new Error
//                {
//                    ErrorCode = "Database.FindGoodsIssueEntryById",
//                    Message = "Không tìm được mã sản phẩm này trong database."
//                };
//                return new ServiceResourceResponse<GoodsIssueEntry>(error);
//            }
//        }
//        public async Task<ServiceResponse> UpdateGoodsIssueEntry (GoodsIssueEntry entry)
//        {
//            try
//            {
//                await _goodsIssueEntryRepository.Update(entry);
//                await _unitOfWork.SaveChangeAsync();

//                return ServiceResponse.Successful();
//            }
//            catch
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Update",
//                    Message = "Không thể chỉnh sửa mã hàng này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }

//        public async Task<IEnumerable<GoodsIssueEntryBasket>> LoadGoodsIssueEntryBasket()
//        {
//            return await _goodsIssueEntryBasketRepository.Load();
//        }
//        public async Task<ServiceResponse> InsertGoodsIssueEntry(GoodsIssueEntry entry)
//        {
//            try
//            {
//                _goodsIssueEntryRepository.Insert(entry);
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch (Exception ex)
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.InsertGoodsIssueEntry",
//                    Message = "Vị trí này đã được lưu trong database."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }    
//        public async Task<ServiceResponse> InsertGoodsIssueEntryBasket(GoodsIssueEntryBasket entry)
//        {
//            try
//            {
//                _goodsIssueEntryBasketRepository.Insert(entry);
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Add",
//                    Message = "Vị trí này đã được lưu trên Database, vui lòng kiểm tra lại."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> UpdateGoodsIssueEntryBasket(GoodsIssueEntryBasket entry)
//        {
//            try
//            {
//                await _goodsIssueEntryBasketRepository.Update(entry);
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Update",
//                    Message = "Không thể chỉnh sửa vị trí này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> ClearGoodsIssue()
//        {
//            try
//            {
//                _goodsIssueEntryRepository.Clear();
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch 
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Clear",
//                    Message = "Không thể xóa được bảng này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//        public async Task<ServiceResponse> ClearGoodsIssueEntries()
//        {
//            try
//            {
//                _goodsIssueEntryBasketRepository.Clear();
//                await _unitOfWork.SaveChangeAsync();
//                return ServiceResponse.Successful();
//            }
//            catch
//            {
//                _unitOfWork.DetachChange();
//                var error = new Error
//                {
//                    ErrorCode = "Database.Clear",
//                    Message = "Không thể xóa được bảng này."
//                };
//                return ServiceResponse.Failed(error);
//            }
//        }
//    }
//}
