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
        UpdateGoodLocationViewModel updateGoodLocationViewModel = new UpdateGoodLocationViewModel();
        this.DataContext = updateGoodLocationViewModel;
        updateGoodLocationViewModel.AddImageEvent += UpdatUI;


    }

    private void UpdatUI(int row, int column, int depth)
    {
        BasketSlotpanel.Children.Clear();
        int halfofdepth = depth / 2;
        //for (int k = 0; k < height; k++)
        //{
        //    // slotpanel width = "847.04" , height="724"
        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < depth; j++)
        //        {
        //            var marginright = (700 - 45*width)/2 +i*45 +j*15;
        //            var marginbottom = 80 + + j * 20 + k * 50;
        //            if ((k + 1) == emptyslot[0].height && (i + 1) == emptyslot[0].width && (j + 1) == emptyslot[0].depth)
        //            {
        //                //cubegenerate.createbasket(slotpanel, marginright, 80 + i * 19 + j * 20 + k * 100);
        //                return;
        //            }
        //            else
        //            {

        //                cubegenerate.createbasket(slotpanel, marginright, marginbottom);
        //            }
        //            if (j == (halfofdepth + 1) && i == width - 1)
        //            {
        //                textblock nameoflevel = new textblock();
        //                nameoflevel.fontsize = 25;
        //                nameoflevel.fontfamily = new fontfamily("arial"); ;
        //                slotpanel.children.add(nameoflevel);
        //                canvas.setleft(nameoflevel, marginright + 150);
        //                canvas.settop(nameoflevel, 100 + i * 20 + j * 20 + k * 100);
        //                nameoflevel.text = "hàng " + (height - k);
        //            }

        //        }

        //    }
        //}
        for (int j = 1; j <= row; j++)
        {

            for (int k = 1; k <= column; k++)
            {
                double marginright = (BasketSlotpanel.ActualWidth - column * 60 + 30 * (column - 1)) / 2 + (k - 1) * 50;
                double marginbottom = (BasketSlotpanel.ActualHeight - row * 50)/2 + (j - 1)*25;
                CubeGenerate.CreateBasketForUpdateLocation(BasketSlotpanel, marginright, marginbottom);
            }
        }
    }
}
