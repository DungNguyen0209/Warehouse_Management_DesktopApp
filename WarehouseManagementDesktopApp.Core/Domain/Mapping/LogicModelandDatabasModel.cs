namespace WarehouseManagementDesktopApp.Core.Domain.Mapping;

public class LogicModelandDatabasModel : Profile
{
    public LogicModelandDatabasModel()
    {
        CreateMap<Persistence.SqliteDB.Model.Product, WarehouseManagementDesktopApp.Core.Domain.Model.Product>()
            .ReverseMap()
            .ForMember(dest => dest.IdProduct, expression => expression.MapFrom(src => src.itemId))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.name));
    }
}
