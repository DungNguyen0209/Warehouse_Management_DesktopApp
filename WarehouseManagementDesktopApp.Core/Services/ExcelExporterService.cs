namespace WarehouseManagementDesktopApp.Core.Services;
#pragma warning disable CS8618
public class ExcelExporterService : IExcelExporter
{

    private ExcelPackage package;
    private ExcelWorksheet worksheet;
    public string FilePath { get; set; }

    public ExcelExporterService()
    {
    }
    private ServiceResponse ReadExcelFile(string path)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        try
        {
            // mở file excel
            package = new ExcelPackage(new FileInfo(path));

            // lấy ra sheet đầu tiên để thao tác
            worksheet = package.Workbook.Worksheets[0];
            return ServiceResponse.Successful();
        }
        catch (Exception ex)
        {
            Error error = new Error
            {
                ErrorCode = "ReadExcel",
                Message = ex.ToString()
            };
            return ServiceResponse.Failed(error);
        }

    }
    private ServiceResponse ReadExcelFile()
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        try
        {
            var filePath = string.Empty;

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.DefaultExt = "xlsx";
            choofdlog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                filePath = choofdlog.FileName;
                FilePath = Path.GetFileName(filePath);
            }
            else
                filePath = string.Empty;
            // mở file excel
            package = new ExcelPackage(new FileInfo(filePath));

            // lấy ra sheet đầu tiên để thao tác
            worksheet = package.Workbook.Worksheets[0];
            return ServiceResponse.Successful();
        }
        catch (Exception ex)
        {
            Error error = new Error
            {
                ErrorCode = "ReadExcel Error",
                Message = ex.ToString()
            };
            return ServiceResponse.Failed(error);
        }

    }

    private ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> ConvertReceiptFile()
    {
        List<GoodReceiptOrderForViewModel> data = new List<GoodReceiptOrderForViewModel>();
        int i = 11;
        bool stopFlag = true;
        while (stopFlag)
        {
            GoodReceiptOrderForViewModel goodReceiptOrderViewModel = new GoodReceiptOrderForViewModel()
            {
                Id = Convert.ToString(worksheet.Cells["B" + Convert.ToString(i)].Value),
                ProductId = Convert.ToString(worksheet.Cells["C" + Convert.ToString(i)].Value),
                ProductName = Convert.ToString(worksheet.Cells["D" + Convert.ToString(i)].Value),
                Mass = Convert.ToString(worksheet.Cells["E" + Convert.ToString(i)].Value),
                Quantity = Convert.ToString(worksheet.Cells["F" + Convert.ToString(i)].Value),
                Infomartion = Convert.ToString(worksheet.Cells["G" + Convert.ToString(i)].Value),
            };
            if (String.IsNullOrEmpty(goodReceiptOrderViewModel.Id))
            {
                stopFlag = false;
                break;

            }
            data.Add(goodReceiptOrderViewModel);
            i++;
        }
        return new ServiceResourceResponse<List<GoodReceiptOrderForViewModel>>(data);
    }
    private async Task<ServiceResponse> EditIssueExcel(RangeObservableCollection<ContainerIssueEntry> ContainerEntry)
    {
        //package = new ExcelPackage(new FileInfo("Template_XK.xlsx"));
        //// lấy ra sheet đầu tiên để thao tác
        //worksheet = package.Workbook.Worksheets[0];
        ReadExcelFile("Template_XK.xlsx");
        try
        {
            int i = 1;
            foreach (var sheet in ContainerEntry)
            {
                worksheet.Cells["A" + Convert.ToString(10 + i)].Value = i;
                worksheet.Cells["B" + Convert.ToString(10 + i)].Value = sheet.containerId;
                worksheet.Cells["C" + Convert.ToString(10 + i)].Value = sheet.itemId;
                worksheet.Cells["D" + Convert.ToString(10 + i)].Value = sheet.name;
                if (sheet.Unit == "Kg")
                {

                    worksheet.Cells["E" + Convert.ToString(10 + i)].Value = sheet.Quantity;
                }
                else
                {
                    worksheet.Cells["F" + Convert.ToString(10 + i)].Value = sheet.Quantity;
                }
                worksheet.Cells["H" + Convert.ToString(10 + i)].Value = sheet.Cell;
                worksheet.Cells["I" + Convert.ToString(10 + i)].Value = sheet.Location;
                i++;
            }



            return ServiceResponse.Successful();
        }
        catch (Exception ex)
        {
            Error error = new Error
            {
                ErrorCode = "EditExcel",
                Message = ex.ToString()
            };
            return ServiceResponse.Failed(error);
        }
    }
    private async Task<ServiceResponse> ExportExcelFile()
    {
        string filePath = "";
        // tạo SaveFileDialog để lưu file excel
        SaveFileDialog dialog = new SaveFileDialog();

        // chỉ lọc ra các file có định dạng Excel
        dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
        // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
        if (dialog.ShowDialog() == true)
        {
            filePath = dialog.FileName;
            var file = new FileInfo(filePath);
            try
            {
                using (package)
                {
                    //Lưu file lại
                    await package.SaveAsAsync(file);
                }
                return ServiceResponse.Successful();
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    ErrorCode = "ExportExcel",
                    Message = ex.ToString()
                };
                return ServiceResponse.Failed(error);
            }
        }
        else
        {
            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox messageBox = new MessageBox()
                {
                    ContentText = "Đường dẫn báo cáo không hợp lệ",
                    IsWarning = true,
                };
                messageBox.Show();
                Error error = new Error
                {
                    ErrorCode = "ExportExcel",
                    Message = "Đường dẫn không hợp lệ"
                };
                return ServiceResponse.Failed(error);
            }
            else
            {
                Error error = new Error
                {
                    ErrorCode = "ExportExcel",
                    Message = "Lỗi Lưu file"
                };
                return ServiceResponse.Failed(error);
            }
        }

    }

    public ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> ReadReceipt()
    {
        ReadExcelFile();
        if (!String.IsNullOrEmpty(FilePath))
        {
            return ConvertReceiptFile();
        }
        else
        { return null;}
    }

    public async Task<ServiceResponse> ExportGoodIssue(RangeObservableCollection<ContainerIssueEntry> ContainerEntry)
    {
        var step2 = await EditIssueExcel(ContainerEntry);
        var step3 = await ExportExcelFile();

        if (step2.Success != true)
        {
            return step2;
        }
        else
        {
            if (step3.Success != true)
            {
                return step3;
            }
            else
            {
                return ServiceResponse.Successful();
            }
        }

    }
}
