using Persistence.SqliteDB.Domain.Model.GoodExport;

namespace WarehouseManagementDesktopApp.Core.Services.LocalDatabaseService;

public class ProcessingGoodExportOrderDatabaseService : IProcessingGoodExportOrderDatabaseService
{
    private readonly IProcessingGoodExportOrderRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ProcessingGoodExportOrderDatabaseService(IProcessingGoodExportOrderRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async void Delete()
    {
        await _repository.DeleteAsync();
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<List<ProcessingGoodExportOrder>> GetAll()
    {
        var data = await _repository.LoadAsync();
        return data;
    }

    public async void Update(ProcessingGoodExportOrder processingGoodExportOrder)
    {
        await Task.Run(() => _repository.UpdateAsync(processingGoodExportOrder));
        try
        {

            await _unitOfWork.SaveChangeAsync();
        }
        catch
        {
            _unitOfWork.DetachChange();
        }

    }
}
