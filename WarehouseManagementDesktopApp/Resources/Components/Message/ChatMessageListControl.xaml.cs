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
/// Interaction logic for ChatMessageListControl.xaml
/// </summary>
public partial class ChatMessageListControl : UserControl
{
 
    public ChatMessageListControl()
    {
        InitializeComponent();
    }
    //public ObservableCollection<MessageListItemControl> MessageList
    //{
    //    get { return (ObservableCollection<MessageListItemControl>)GetValue(MessageListProperty); }
    //    set { SetValue(MessageListProperty, value); }
    //}

    //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    //public static readonly DependencyProperty MessageListProperty =
    //    DependencyProperty.RegisterAttached("MessageListProperty", typeof(ObservableCollection<MessageListItemControl>), typeof(ChatMessageListControl), new PropertyMetadata(new ObservableCollection<MessageListItemControl>{
    //            new MessageListItemControl
    //            {
    //                Message = "I'm about to wipe the old server. We need to update the old server to Windows 2016",
    //                MessageSentTime = DateTimeOffset.UtcNow,
    //            },
    //            new MessageListItemControl
    //            {
    //                Message = "Let me know when you manage to spin up the new 2016 server",
    //                MessageSentTime = DateTimeOffset.UtcNow,
    //            },
    //            new MessageListItemControl
    //            {
    //                Message = "The new server is up. Go to 192.168.1.1.\r\nUsername is admin, password is P8ssw0rd!",
    //                MessageSentTime = DateTimeOffset.UtcNow,
    //            },
    //        }));
}
