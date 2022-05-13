using Persistence.SqliteDB.Domain.Interfaces;
using Persistence.SqliteDB.Model;
using Product = Persistence.SqliteDB.Model.Product;
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

    public async void Clear()
    {
        await _productRepository.ClearAll();
        await _unitOfWork.SaveChangeAsync();
    }
    public async void Insert(List<Product> products)
    {
        await  _productRepository.InsertAsync(products);
        await _unitOfWork.SaveChangeAsync();
    }
    public async Task<IList<Product>?> LoadSuggestName (string firstname)
    {
        var list = await _productRepository.LoadAsyncSuggestName(firstname);
        return list;
    }

}
