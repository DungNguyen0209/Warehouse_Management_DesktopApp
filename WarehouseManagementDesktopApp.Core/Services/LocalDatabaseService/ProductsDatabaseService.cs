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

    public void Clear()
    {
        _productRepository.ClearAll();
    }
    public async void Insert(List<Product> products)
    {
        await Task.Run(()=> _productRepository.InsertAsync(products));
         await _unitOfWork.SaveChangeAsync();
    }
    public async Task<IList<Product>?> LoadSuggestName (string firstname)
    {
        var list = await _productRepository.LoadAsyncSuggestName(firstname);
        return list;
    }

}
