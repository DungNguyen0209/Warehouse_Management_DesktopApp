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
    public partial class MenuButton : UserControl
    {
        #region Icon and Content
        private string _content = String.Empty;
        public string Content 
        { 
            get { return _content;} 
            set
            {
                if(value != String.Empty)
                {
                _content = value;
                }
            }  
        }
        public PackIconKind IconValue
        {
            get { return (PackIconKind)GetValue(IconValueProperty); }
            set { SetValue(IconValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconValueProperty =
            DependencyProperty.Register("IconValue", typeof(PackIconKind), typeof(MenuButton), new PropertyMetadata(PackIconKind.User));


        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.Register("ContentText", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty));
        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }

        }

        //public static readonly DependencyProperty DataContextCustomProperty =
        //    DependencyProperty.Register("DataContextCustom", typeof(object), typeof(MenuButton), new PropertyMetadata());
        //public object DataContextCustom
        //{
        //    get { return (object)GetValue(DataContextCustomProperty); }
        //    set { SetValue(DataContextCustomProperty, value); }

        //}
        #endregion


        #region Responsive 


        public static readonly RoutedEvent ClickEvent =
           EventManager.RegisterRoutedEvent(nameof(Click), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuButton));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }



        #endregion
        public MenuButton()
        {
            InitializeComponent();
            Content = ContentText;
            //this.DataContext = DataContextCustom;
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
        private void OnClick(object sender, RoutedEventArgs e)
        {
            MainButton.IsEnabled = true;
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }

        private void RaiseCustomRoutedEvent()
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
    }
}
