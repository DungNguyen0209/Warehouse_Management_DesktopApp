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

namespace WarehouseManagementDesktopApp.Resources.Components.ButtonCustom;
/// <summary>
/// Interaction logic for CustomButtonMenu.xaml
/// </summary>
public partial class CustomButtonMenu : UserControl
{
    public CustomButtonMenu()
    {
        InitializeComponent();
        Animation1 = true;
        Animation2 = false;
    }
    public string ContentText
    {
        get { return (string)GetValue(LabelTextProperty); }
        set { SetValue(LabelTextProperty, value); OnPropertyChanged(); }
    }

    public static readonly DependencyProperty LabelTextProperty =
        DependencyProperty.Register("ContentText", typeof(string), typeof(CustomButtonMenu), new PropertyMetadata("Content", OnRequiredChange));
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }
    private static void OnRequiredChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {

        CustomButtonMenu Bt = d as CustomButtonMenu;


    }
    //Property packicon
    public PackIconKind NamePackIcon
    {
        get { return (PackIconKind)GetValue(PackIconProperty); }
        set { SetValue(PackIconProperty, value); }
    }
    public static readonly DependencyProperty PackIconProperty =
     DependencyProperty.Register("NamePackIcon", typeof(PackIconKind), typeof(CustomButtonMenu), new PropertyMetadata(PackIconKind.Account, OnRequiredChangeKind));
    private static void OnRequiredChangeKind(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {

        CustomButtonMenu Bt = d as CustomButtonMenu;


    }
    //tạo event click
    //public static readonly RoutedEvent ClickEvent
    //    = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonMenu));

    //public event RoutedEventHandler Click
    //{
    //    add
    //    {
    //        AddHandler(ClickEvent, value);
    //    }
    //    remove
    //    {
    //        RemoveHandler(ClickEvent, value);
    //    }
    //}

    //private void OnClick(object sender, RoutedEventArgs e)
    //{
    //    RoutedEventArgs args = new RoutedEventArgs(ClickEvent);
    //    RaiseEvent(args);

    //}
    public static readonly RoutedEvent ClickEvent =
        EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomButtonMenu));

    public event RoutedEventHandler Click
    {
        add { AddHandler(ClickEvent, value); }
        remove { RemoveHandler(ClickEvent, value); }
    }
    private void OnClick(object sender, RoutedEventArgs e)
    {

        RaiseEvent(new RoutedEventArgs(ClickEvent));
    }

    //tạo animation
    private bool animation1;
    public bool Animation1 { get => animation1; set { animation1 = value; OnPropertyChanged(); } }

    private bool animation2;
    public bool Animation2 { get => animation2; set { animation2 = value; OnPropertyChanged(); } }

    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }


    public static readonly DependencyProperty IsRequiredProperty =
     DependencyProperty.Register("IsRequired", typeof(bool), typeof(CustomButtonMenu), new PropertyMetadata(false, OnRequiredAnimation));
    private static void OnRequiredAnimation(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {

        CustomButtonMenu Bt = d as CustomButtonMenu;
        if (e != null)

        {


            if (e.NewValue.ToString() == "True")
            {
                Bt.BackgroundBTMenu = new SolidColorBrush(Colors.DeepSkyBlue);
                Bt.ForegroundPackicon = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF00294D");
                Bt.ForegroundText = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF00294D");
                Bt.Animation1 = false;
                Bt.Animation2 = true;
                Bt.BoderBrushBTMenu = new SolidColorBrush(Colors.White);
                //7FFFFFFF
                //#FF16D7D7
                //#FF1A0D0D
                //FF00294D
            }
            else
            {
                Bt.BackgroundBTMenu = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF00294D");
                Bt.ForegroundPackicon = new SolidColorBrush(Colors.White);
                Bt.ForegroundText = new SolidColorBrush(Colors.White);
                Bt.BoderBrushBTMenu = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF00294D");
                Bt.Animation1 = true;
                Bt.Animation2 = false;
            }
        }


    }
    //Backgroud BTMenu

    public SolidColorBrush BackgroundBTMenu
    {
        get { return (SolidColorBrush)GetValue(BackgrounducProperty); }
        set { SetValue(BackgrounducProperty, value); }
    }
    public static readonly DependencyProperty BackgrounducProperty =
     DependencyProperty.Register("BackgroundBTMenu", typeof(SolidColorBrush), typeof(CustomButtonMenu), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF00294D")));
    //Backgroud BTMenu

    public SolidColorBrush BoderBrushBTMenu
    {
        get { return (SolidColorBrush)GetValue(BoderBrushBTMenuProperty); }
        set { SetValue(BoderBrushBTMenuProperty, value); }
    }
    public static readonly DependencyProperty BoderBrushBTMenuProperty =
     DependencyProperty.Register("BoderBrushBTMenu", typeof(SolidColorBrush), typeof(CustomButtonMenu), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF00294D")));

    //Backgrond packicon
    public SolidColorBrush ForegroundPackicon
    {
        get { return (SolidColorBrush)GetValue(BackroundPackiconProperty); }
        set { SetValue(BackroundPackiconProperty, value); }
    }
    public static readonly DependencyProperty BackroundPackiconProperty =
     DependencyProperty.Register("ForegroundPackicon", typeof(SolidColorBrush), typeof(CustomButtonMenu), new PropertyMetadata(new SolidColorBrush(Colors.White)));
    //Background Text
    public SolidColorBrush ForegroundText
    {
        get { return (SolidColorBrush)GetValue(BackgroundTextProperty); }
        set { SetValue(BackgroundTextProperty, value); }
    }
    public static readonly DependencyProperty BackgroundTextProperty =
     DependencyProperty.Register("ForegroundText", typeof(SolidColorBrush), typeof(CustomButtonMenu), new PropertyMetadata(new SolidColorBrush(Colors.White)));
}
    //animation

