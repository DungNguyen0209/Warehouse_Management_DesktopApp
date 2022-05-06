namespace WarehouseManagementDesktopApp.Core.ValueConverter;

public class SpaceToBackGroundConverter : IValueConverter
{


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? Application.Current.FindResource("WordGreenBrush") : Application.Current.FindResource("WordRedBrush");

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
