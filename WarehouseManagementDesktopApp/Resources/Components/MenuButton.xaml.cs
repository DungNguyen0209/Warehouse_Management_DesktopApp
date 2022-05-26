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

namespace WarehouseManagementDesktopApp.Resources.Components
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl,INotifyPropertyChanged
    {
        #region Icon and Content
        private string _content = String.Empty;
        public string Content
        {
            get { return _content; }
            set
            {
                if (value != String.Empty)
                {
                    _content = value;
                }
            }
        }
        public PackIconKind IconValue { get { return (PackIconKind)GetValue(IconValueProperty); } set { SetValue(IconValueProperty, value); } }
        public static readonly DependencyProperty IconValueProperty =
            DependencyProperty.Register("IconValue", typeof(PackIconKind), typeof(MenuButton), new PropertyMetadata(PackIconKind.User, OnRequiredChangeKind));
        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.Register("ContentText", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty, OnRequiredChange));

        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); OnPropertyChanged(); }
        }
        // Using a DependencyProperty as the backing store for IconValue.  This enables animation, styling, binding, etc...
        private bool animation1;
        public bool Animation1 { get => animation1; set { animation1 = value; OnPropertyChanged(); } }
        private bool animation2;
        public bool Animation2 { get => animation2; set { animation2 = value; OnPropertyChanged(); } }
        #endregion


        #region Responsive 
        public static readonly RoutedEvent ClickEvent =
           EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuButton));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            MainButton.IsEnabled = true;
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
        #endregion
        public MenuButton()
        {
            InitializeComponent();
            Content = ContentText;
            Animation1 = true;
            Animation2 = false;
        }

        public void UpdateMinimizedUI()
        {
            Content = ContentText;
            MainButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            ContentText = String.Empty;
  
        }
        public void UpdateNormalUI()
        {

            MainButton.HorizontalContentAlignment = HorizontalAlignment.Left;
            ContentText = Content;

        }
        //tạo animation        

        public static readonly DependencyProperty IsRequiredProperty =
         DependencyProperty.Register("IsRequired", typeof(bool), typeof(MenuButton), new PropertyMetadata(false, OnRequiredAnimation));
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }
        private static void OnRequiredAnimation(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton Btn = d as MenuButton;
            if (e != null)
            {
                if (e.NewValue.ToString() == "True")
                {
                    Btn.Animation1 = false;
                    Btn.Animation2 = true;
                    Btn.BoderBrushBTMenu = new SolidColorBrush(Colors.WhiteSmoke);
                    Btn.ForegroundPackicon = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF083663");
                    Btn.ForegroundText = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF083663");
                    Btn.Selected = new SolidColorBrush(Colors.White);
                    Btn.BackgroundBTMenu = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#E8EAF6");
                }
                else
                {
                    Btn.Animation1 = true;
                    Btn.Animation2 = false;
                    Btn.Selected = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF083663");
                    Btn.ForegroundPackicon = new SolidColorBrush(Colors.LightGray);
                    Btn.ForegroundText = new SolidColorBrush(Colors.LightGray);
                    Btn.BoderBrushBTMenu = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF083663");
                    Btn.BackgroundBTMenu = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#FF083663");
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
         DependencyProperty.Register("BackgroundBTMenu", typeof(SolidColorBrush), typeof(MenuButton), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF083663")));
        public SolidColorBrush Selected
        {
            get { return (SolidColorBrush)GetValue(BackProperty); }
            set { SetValue(BackProperty, value); }
        }
        public static readonly DependencyProperty BackProperty =
         DependencyProperty.Register("Selected", typeof(SolidColorBrush), typeof(MenuButton), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF083663")));
        //Backgroud BTMenu
        public SolidColorBrush BoderBrushBTMenu
        {
            get { return (SolidColorBrush)GetValue(BoderBrushBTMenuProperty); }
            set { SetValue(BoderBrushBTMenuProperty, value); }
        }
        public static readonly DependencyProperty BoderBrushBTMenuProperty =
         DependencyProperty.Register("BoderBrushBTMenu", typeof(SolidColorBrush), typeof(MenuButton), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF083663")));
        //Backgrond packicon
        public SolidColorBrush ForegroundPackicon
        {
            get { return (SolidColorBrush)GetValue(BackroundPackiconProperty); }
            set { SetValue(BackroundPackiconProperty, value); }
        }
        public static readonly DependencyProperty BackroundPackiconProperty =
         DependencyProperty.Register("ForegroundPackicon", typeof(SolidColorBrush), typeof(MenuButton), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));
        //Background Text
        public SolidColorBrush ForegroundText
        {
            get { return (SolidColorBrush)GetValue(BackgroundTextProperty); }
            set { SetValue(BackgroundTextProperty, value); }
        }
        public static readonly DependencyProperty BackgroundTextProperty =
         DependencyProperty.Register("ForegroundText", typeof(SolidColorBrush), typeof(MenuButton), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void OnRequiredChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton Btn = d as MenuButton;
        }
        private static void OnRequiredChangeKind(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton Btn = d as MenuButton;
        }
    }
}
