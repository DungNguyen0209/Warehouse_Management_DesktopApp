using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WarehouseManagementDesktopApp.Resources.Components.Message;
/// <summary>
/// Interaction logic for MessageListItemControl.xaml
/// </summary>
public partial class MessageListItemControl : UserControl
{

    public string Message
    {
        get { return (string)GetValue(MessageProperty); }
        set { SetValue(MessageProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.RegisterAttached("MessageProperty", typeof(int), typeof(MessageListItemControl), new PropertyMetadata("Notify"));

    public DateTimeOffset MessageSentTime
    {
        get { return (DateTimeOffset)GetValue(MessageSentTimeProperty); }
        set { SetValue(MessageSentTimeProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MessageSentTimeProperty =
        DependencyProperty.RegisterAttached("MessageSentTimeProperty", typeof(DateTimeOffset), typeof(MessageListItemControl), new PropertyMetadata(DateTimeOffset.UtcNow));
    public MessageListItemControl()
    {
        InitializeComponent();
    }
}
