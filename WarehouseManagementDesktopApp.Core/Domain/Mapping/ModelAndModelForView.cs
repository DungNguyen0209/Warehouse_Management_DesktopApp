using Persistence.SqliteDB.Domain.Model.GoodExport;

namespace WarehouseManagementDesktopApp.Core.Domain.Mapping;

public class ModelAndModelForView : Profile
{
    public ModelAndModelForView()
    {
        CreateMap<FormulaListInGoodIssueForViewModel, FormulaListGoodIssue>()
            .ReverseMap();
        CreateMap<IssueBasketForViewModel, IssueBasket>()
           .ReverseMap();
    }
}
