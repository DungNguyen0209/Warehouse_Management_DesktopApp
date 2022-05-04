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

    private ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> ConvertReceiptFile ()
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
    public ServiceResourceResponse<List<GoodReceiptOrderForViewModel>> ReadReceipt()
    {
        ReadExcelFile();
        return ConvertReceiptFile();
    }

    //private ServiceResponse EditExcelReliability(ReliabilityTestingMachine testingMachine)
    //{
    //    try
    //    {
    //        worksheet.Cells["F5"].Value = testingMachine.ProductId;
    //        worksheet.Cells["C8"].Style.Numberformat.Format = "dd-MM-yyyy";
    //        worksheet.Cells["C8"].Value = testingMachine.StartTime;
    //        worksheet.Cells["K8"].Style.Numberformat.Format = "dd-MM-yyyy";
    //        worksheet.Cells["K8"].Value = testingMachine.StopTime;
    //        worksheet.Cells["K9"].Value = testingMachine.Note;
    //        switch (testingMachine.Target.ToLower())
    //        {
    //            case "dinhky":
    //                worksheet.Cells["P9"].Value = Convert.ToString(1);
    //                break;
    //            case "batthuong":
    //                worksheet.Cells["P9"].Value = Convert.ToString(2);
    //                break;
    //            case "spmoi":
    //                worksheet.Cells["P9"].Value = Convert.ToString(3);
    //                break;
    //            case "khac":

    //                worksheet.Cells["P9"].Value = Convert.ToString(4);
    //                break;
    //        }
    //        int i = 0;
    //        foreach (var sheet in testingMachine.Testsheet)
    //        {
    //            worksheet.Cells["B" + Convert.ToString(15 + i)].Value = sheet.TimeSmoothClosingLid;
    //            worksheet.Cells["C" + Convert.ToString(15 + i)].Value = sheet.StatusLidNotFall;
    //            worksheet.Cells["D" + Convert.ToString(15 + i)].Value = sheet.StatusLidNotLeak;
    //            worksheet.Cells["E" + Convert.ToString(15 + i)].Value = sheet.StatusLidResult;
    //            worksheet.Cells["F" + Convert.ToString(15 + i)].Value = sheet.TimeSmoothClosingPlinth;
    //            worksheet.Cells["G" + Convert.ToString(15 + i)].Value = sheet.StatusPlinthNotFall;
    //            worksheet.Cells["H" + Convert.ToString(15 + i)].Value = sheet.StatusPlinthNotLeak;
    //            worksheet.Cells["I" + Convert.ToString(15 + i)].Value = sheet.StatusPlinthResult;
    //            worksheet.Cells["J" + Convert.ToString(15 + i)].Value = sheet.TotalMistake;
    //            worksheet.Cells["K" + Convert.ToString(15 + i)].Value = sheet.Note;
    //            worksheet.Cells["N" + Convert.ToString(15 + i)].Value = sheet.StaffCheck;
    //            i++;
    //        }

    //        return ServiceResponse.Successful();
    //    }
    //    catch (Exception ex)
    //    {
    //        Domain.Error error = new Domain.Error
    //        {
    //            ErrorCode = "EditExcel",
    //            Message = ex.ToString()
    //        };
    //        return ServiceResponse.Failed(error);
    //    }
    //}

    //private async Task<ServiceResponse> ExportExcelFile()
    //{
    //    string filePath = "";
    //    // tạo SaveFileDialog để lưu file excel
    //    Microsoft.Win32.SaveFileDialog dialog = new SaveFileDialog();

    //    // chỉ lọc ra các file có định dạng Excel
    //    dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
    //    // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
    //    if (dialog.ShowDialog() == true)
    //    {
    //        filePath = dialog.FileName;
    //        var file = new FileInfo(filePath);
    //        try
    //        {
    //            using (package)
    //            {
    //                //Lưu file lại
    //                await package.SaveAsAsync(file);
    //            }
    //            return ServiceResponse.Successful();
    //        }
    //        catch (Exception ex)
    //        {
    //            Error error = new Error
    //            {
    //                ErrorCode = "ExportExcel",
    //                Message = ex.ToString()
    //            };
    //            return ServiceResponse.Failed(error);
    //        }
    //    }
    //    else
    //    {
    //        // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
    //        if (string.IsNullOrEmpty(filePath))
    //        {
    //            MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
    //            Error error = new Error
    //            {
    //                ErrorCode = "ExportExcel",
    //                Message = "Đường dẫn không hợp lệ"
    //            };
    //            return ServiceResponse.Failed(error);
    //        }
    //        else
    //        {
    //            Error error = new Error
    //            {
    //                ErrorCode = "ExportExcel",
    //                Message = "Lỗi Lưu file"
    //            };
    //            return ServiceResponse.Failed(error);
    //        }
    //    }

    //}
    //public async Task<ServiceResponse> ExportCurlingForce(string path, ReportCurlingForce report)
    //{
    //    var step1 = ReadExcelFile(path);
    //    var step2 = EditExcelCurlingForce(report);
    //    var step3 = await ExportExcelFile();
    //    if (step1.Success != true)
    //    {
    //        return step1;
    //    }
    //    else
    //    {
    //        if (step2.Success != true)
    //        {
    //            return step2;
    //        }
    //        else
    //        {
    //            if (step3.Success != true)
    //            {
    //                return step3;
    //            }
    //            else
    //            {
    //                return ServiceResponse.Successful();
    //            }
    //        }
    //    }
    //}
}
