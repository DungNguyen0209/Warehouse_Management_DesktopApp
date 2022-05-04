using Persistence.SqliteDB.Domain.Interfaces;
using Persistence.SqliteDB.Model;
using WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

namespace WarehouseManagementDesktopApp.Core.Services;

public class ProductsDatabaseService: IProductsDatabaseService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsDatabaseService(IProductRepository productRepository,IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IList<Product>?> LoadSuggestName (string firstname)
    {
        var list = await _productRepository.LoadAsyncSuggestName(firstname);
        return list;
    }

}
