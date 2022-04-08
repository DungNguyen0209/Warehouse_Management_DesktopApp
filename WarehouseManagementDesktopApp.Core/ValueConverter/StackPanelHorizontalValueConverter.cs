namespace WarehouseManagementDesktopApp.Core.ValueConverter;

public class StackPanelHorizontalValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return double.TryParse(value as string, out double DoubleValue) && double.TryParse(parameter as string, out double DoubleParameter) && DoubleValue > DoubleParameter;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
