using WarehouseManagementDesktopApp.Core.Domain.Model;

namespace WarehouseManagementDesktopApp.Core.Domain.Communication;

public class LoginResponse
{
    public Token? Token { get; set; }
    public WarehouseEmployee? Employee { get; set; }
}
