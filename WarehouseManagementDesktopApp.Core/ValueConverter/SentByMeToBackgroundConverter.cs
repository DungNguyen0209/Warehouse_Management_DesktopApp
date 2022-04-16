namespace WarehouseManagementDesktopApp.Core.ValueConverter;

/// <summary>
/// A converter that takes in a boolean if a message was sent by me, and returns the
/// correct background color
/// </summary>
public class SentByMeToBackgroundConverter : BaseValueConverter<SentByMeToBackgroundConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? Application.Current.FindResource("NotifyPanelColorBrush") : Application.Current.FindResource("WordGreenBrush");
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
