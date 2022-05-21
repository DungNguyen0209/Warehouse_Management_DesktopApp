using MaterialDesignThemes.Wpf;
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
/// Interaction logic for MessageBox.xaml
/// </summary>
public partial class MessageBox : UserControl
{
    public MessageBox()
    {
        InitializeComponent();
    }

    //public PackIconKind Icon
    //{
    //    get { return (PackIconKind)GetValue(IconProperty); }
    //    set { SetValue(IconProperty, value); }
    //}

    //// Using a DependencyProperty as the backing store for IconValue.  This enables animation, styling, binding, etc...
    //public static readonly DependencyProperty IconProperty =
    //    DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(MenuButton), new PropertyMetadata(PackIconKind.User));


    //public static readonly DependencyProperty ContentProperty =
    //    DependencyProperty.Register("Content", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty));
    //public string Content
    //{
    //    get { return (string)GetValue(ContentProperty); }
    //    set { SetValue(ContentProperty, value); }

    //}
}
