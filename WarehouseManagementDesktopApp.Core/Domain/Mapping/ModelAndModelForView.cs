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
            .ForMember(dest => dest.note, expression => expression.MapFrom(src => src.Infomartion));
        CreateMap<ProductEntry, FormulaListInGoodIssueForViewModel>()
            .ReverseMap()
            .ForMember(dest => dest.itemId, expression => expression.MapFrom(src => src.ProductId));
        CreateMap<WarningStock, WarningStockCard>()
           .ReverseMap()
           .ForMember(dest => dest.itemId, expression => expression.MapFrom(src => Convert.ToString(src.item.itemId)))
           .ForMember(dest => dest.name, expression => expression.MapFrom(src => Convert.ToString(src.item.name)))
           .ForMember(dest => dest.minimumStockLevel, expression => expression.MapFrom(src => Convert.ToString(src.item.minimumStockLevel)))
           .ForMember(dest => dest.maximumStockLevel, expression => expression.MapFrom(src => Convert.ToString(src.item.maximumStockLevel)))
           .ForMember(dest => dest.afterQuantity, expression => expression.MapFrom(src => Convert.ToString(src.outputQuantity)));







    }
}
