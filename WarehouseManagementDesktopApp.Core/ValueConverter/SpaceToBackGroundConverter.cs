namespace WarehouseManagementDesktopApp.Core.ValueConverter;

public class SpaceToBackGroundConverter : IValueConverter
{


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        return (bool)value ? Application.Current.FindResource("WordRedBrush") : Application.Current.FindResource("WordGreenBrush");

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
