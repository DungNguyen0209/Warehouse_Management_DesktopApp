using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;

namespace WarehouseManagementDesktopApp.Core.Services.LocalDatabaseService;

public class LocationDatabaseService : ILocationDatabaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public LocationDatabaseService(IUnitOfWork unitOfWork, ILocationRepository locationRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse> AddItemLocation(List<Location> container)
    {
        try
        {
            List<ContainerLocation> containerLocations = new List<ContainerLocation>();
            int i = 1;
            foreach (var item in container)
            {
                if (item != null)
                {

                    ContainerLocation location = new ContainerLocation();
                    location = _mapper.Map<ContainerLocation>(item);
                    if (!containerLocations.Any(s => s.shelfId == location.shelfId && s.rowId == location.rowId && s.cellId == location.cellId))
                    {
                        location.Id = i++;
                        containerLocations.Add(location);
                    }
                }
            }
            await _locationRepository.InsertAsync(containerLocations);
            await _unitOfWork.SaveChangeAsync();
            return ServiceResponse.Successful();
        }
        catch (Exception ex)
        {
            _unitOfWork.DetachChange();
            Error error = new Error() { Message = "Lỗi cập nhật Database" };
            return ServiceResponse.Failed(error);
        }
    }

    public async Task<ServiceResponse> Delete()
    {
        try
        {
            await _locationRepository.ClearAll();
            await _unitOfWork.SaveChangeAsync();
            return ServiceResponse.Successful();
        }
        catch
        {
            Error error = new Error() { Message = "Lỗi cập nhật Database" };
            return ServiceResponse.Failed(error);
        }
    }
    public async Task<ServiceResourceResponse<ContainerLocation>> LoadDatabase(int Id)
    {
        ServiceResourceResponse<ContainerLocation> result;
        try
        {
            var location = await _locationRepository.LoadForIndex(Id);
            result = new ServiceResourceResponse<ContainerLocation>(location);
            return result;
        }
        catch
        {
            var error = new Error("Api.Product.Get", "Vui lòng truy xuất lại tên Sản phẩm");
            result = new ServiceResourceResponse<ContainerLocation>(error);
            return result;
        }
    }
}
