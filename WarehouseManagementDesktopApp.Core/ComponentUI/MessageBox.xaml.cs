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
using System.Windows.Shapes;
using WarehouseManagementDesktopApp.Core.ViewModels;

namespace WarehouseManagementDesktopApp.Core.ComponentUI;
/// <summary>
/// Interaction logic for MessageBox.xaml
/// </summary>
public partial class MessageBox : Window
{
    public static readonly DependencyProperty ContentTextProperty =
           DependencyProperty.Register("ContentText", typeof(string), typeof(MessageBox), new PropertyMetadata(string.Empty));
    public string ContentText
    {
        get { return (string)GetValue(ContentTextProperty); }
        set { SetValue(ContentTextProperty, value); }

    }
    //public static readonly DependencyProperty IconProperty =
    //       DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(MessageBox), new PropertyMetadata(PackIconKind.CheckboxesBlankCircleOutline));
    //public PackIconKind Icon
    //{
    //    get { return (PackIconKind)GetValue(IconProperty); }
    //    set { SetValue(IconProperty, value); }
    //}
    public static readonly DependencyProperty IsWarningProperty =
       DependencyProperty.Register("IsWarning", typeof(bool), typeof(MessageBox), new PropertyMetadata(true));
    public bool IsWarning
    {
        get { return (bool)GetValue(IsWarningProperty); }
        set { SetValue(IsWarningProperty, value); }
    }

    public MessageBox()
    {
        InitializeComponent();
        ControlBarViewModel controlBarViewModel = new ControlBarViewModel();
        ControlBarElement.DataContext = controlBarViewModel;
        controlBarViewModel.Close += root.Close;


    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        root.Close();
    }

    private void root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        root.DragMove();
    }
}
