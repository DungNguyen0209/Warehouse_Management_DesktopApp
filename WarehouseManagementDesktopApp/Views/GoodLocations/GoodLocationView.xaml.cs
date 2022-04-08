

namespace WarehouseManagementDesktopApp.Views.GoodLocations
{
    /// <summary>
    /// Interaction logic for GoodLocationView.xaml
    /// </summary>
    public partial class GoodLocationView : UserControl
    {

        public GoodLocationView()
        {
            InitializeComponent();
            var goodLocationViewModel = new GoodLocationViewModel();
            DataContext = goodLocationViewModel;
            goodLocationViewModel.AddImageEvent += UpdatUI;
        }

        private void UpdatUI(int width, int height, int depth, List<BasketSlot> emptySlot)
        {
            Slotpanel.Children.Clear();
            int halfofdepth = depth / 2;
            //for (int k = 0; k < height; k++)
            //{
            //    // slotpanel width = "847.04" , height="724"
            //    for (int i = 0; i < width; i++)
            //    {
            //        for (int j = 0; j < depth; j++)
            //        {
            //            var marginright = (700 - 45*width)/2 +i*45 +j*15;
            //            var marginBottom = 80 + + j * 20 + k * 50;
            //            if ((k + 1) == emptySlot[0].Height && (i + 1) == emptySlot[0].Width && (j + 1) == emptySlot[0].Depth)
            //            {
            //                //CubeGenerate.CreateBasket(Slotpanel, marginright, 80 + i * 19 + j * 20 + k * 100);
            //                return;
            //            }
            //            else
            //            {

            //                CubeGenerate.CreateBasket(Slotpanel, marginright, marginBottom);
            //            }
            //            if (j == (halfofdepth + 1) && i == width - 1)
            //            {
            //                TextBlock nameoflevel = new TextBlock();
            //                nameoflevel.FontSize = 25;
            //                nameoflevel.FontFamily = new FontFamily("arial"); ;
            //                Slotpanel.Children.Add(nameoflevel);
            //                Canvas.SetLeft(nameoflevel, marginright + 150);
            //                Canvas.SetTop(nameoflevel, 100 + i * 20 + j * 20 + k * 100);
            //                nameoflevel.Text = "hàng " + (height - k);
            //            }

            //        }

            //    }
            //}

            for(int i = 1;i <= height; i++)
            {
                for (int j = 1; j <= depth; j++)
                {
                    for (int k = 1; k <= width; k++)
                    {
                        int marginRight = (700 - width * 45) / 2 + k * 45-15*j;
                        int marginBottom = 10 - j * 20 +(80+8*depth)*i;
                        if (k== 3 && i== height && j== depth)
                        {
                            CubeGenerate.CreateEmptyBasket(Slotpanel, marginRight, marginBottom);
                        }
                        else
                        {
                        CubeGenerate.CreateBasket(Slotpanel, marginRight, marginBottom);

                        }    
                    }
                }
            }    

            //for (int k = 1; k <= width; k++)
            //{
            //    int marginRight = (700 - width * 45) / 2 + k * 45;
            //    int marginBottom = 300 ;
            //    CubeGenerate.CreateBasket(Slotpanel, marginRight, marginBottom);
            //}
            //int y = 50;
            //CubeGenerate.CreateBasket(Slotpanel, 100, 200);
            //CubeGenerate.CreateBasket(Slotpanel, 100 + 45, 200);
            //CubeGenerate.CreateBasket(Slotpanel, 100 + 45 * 2, 200);
            //CubeGenerate.CreateBasket(Slotpanel, 85, 180);
            //CubeGenerate.CreateBasket(Slotpanel, 85 + 45, 180);
            //CubeGenerate.CreateBasket(Slotpanel, 85 + 2 * 45, 180);

            //CubeGenerate.CreateBasket(Slotpanel, 100, 200 + y);
            //CubeGenerate.CreateBasket(Slotpanel, 100 + 45, 200 + y);
            //CubeGenerate.CreateBasket(Slotpanel, 100 + 45 * 2, 200 + y);
            //CubeGenerate.CreateBasket(Slotpanel, 85, 180 + y);
            //CubeGenerate.CreateBasket(Slotpanel, 85 + 45, 180 + y);
            //CubeGenerate.CreateBasket(Slotpanel, 85 + 2 * 45, 180 + y);

        }
    }
}
