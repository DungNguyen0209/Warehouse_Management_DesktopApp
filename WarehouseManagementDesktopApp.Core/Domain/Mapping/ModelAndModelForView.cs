

namespace WarehouseManagementDesktopApp.Core.Domain.Mapping;

public class ModelAndModelForView : Profile
{
    public ModelAndModelForView()
    {
        CreateMap<FormulaListInGoodIssueForViewModel, FormulaListGoodIssue>()
            .ReverseMap();
        CreateMap<IssueBasketForViewModel, IssueBasket>()
           .ReverseMap();
        CreateMap<FormulaListInGoodIssueForViewModel, GoodReceiptOrderForViewModel>()
            .ReverseMap()
            .ForMember(dest => dest.PlannedQuantity, expression => expression.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.PlannedMass, expression => expression.MapFrom(src => src.Mass))
            .ForMember(dest => dest.PlannedQuantity, expression => expression.MapFrom(src => src.Quantity));
        CreateMap<ProductEntry, FormulaListInGoodIssueForViewModel>()
            .ReverseMap()
            .ForMember(dest => dest.itemId, expression => expression.MapFrom(src => src.ProductId));
    }
}
