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
using WarehouseManagementDesktopApp.Resources.Components;

namespace WarehouseManagementDesktopApp.Views.GoodLocations;
/// <summary>
/// Interaction logic for UpdateGoodLocationView.xaml
/// </summary>
public partial class UpdateGoodLocationView : UserControl
{
    public UpdateGoodLocationView()
    {
        InitializeComponent();
        var a = BasketSlotpanel.ActualWidth;
        var b = BasketSlotpanel.Height;
        //UpdateGoodLocationViewModel updateGoodLocationViewModel = new UpdateGoodLocationViewModel();
        //this.DataContext = updateGoodLocationViewModel;
        //updateGoodLocationViewModel.AddImageEvent += UpdatUI;


    }

    //private void UpdatUI(object? sender, List<int> data)
    //{
    //    //BasketSlotpanel.Children.Clear();
    //    var row = data[0];
    //    var column = data[1];
    //    var depth = data[2];
    //    int halfofdepth = depth / 2;
    //    for (int j = 1; j <= row; j++)
    //    {

    //        for (int k = 1; k <= column; k++)
    //        {
    //            double marginright = (BasketSlotpanel.ActualWidth - column * 60 + 30 * (column - 1)) / 2 + (k - 1) * 50;
    //            double marginbottom = (BasketSlotpanel.ActualHeight - row * 50) / 2 + (j - 1) * 25;
    //            //CubeGenerate.CreateBasketForUpdateLocation(BasketSlotpanel, marginright, marginbottom);
    //        }
    //    }
    //}
}
