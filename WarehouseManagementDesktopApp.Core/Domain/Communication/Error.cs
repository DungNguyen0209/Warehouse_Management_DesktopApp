namespace WarehouseManagementDesktopApp.Core.Domain.Communication;

public class Error
{
    public string ErrorCode { get; set; }
    public string Message { get; set; }

    public Error()
    {
    }

    public Error(string errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }
}
