namespace WarehouseManagementDesktopApp.Core.ValueConverter;

/// <summary>
/// A converter that takes in date and converts it to a user friendly time
/// </summary>
public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Get the time passed in
        var time = (DateTimeOffset)value;
        System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

        return time.ToLocalTime().ToString("HH:mm", cul) +","+" Ngày "+ time.ToLocalTime().ToString("dd", cul) + " Tháng "+ time.ToLocalTime().ToString("MM", cul) + " Năm " + time.ToLocalTime().ToString("yyy", cul);



        // Otherwise, return a full date
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
