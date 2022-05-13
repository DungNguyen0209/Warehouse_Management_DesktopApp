using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WarehouseManagementDesktopApp.Core.ComponentUI;

namespace WarehouseManagementDesktopApp.Core.Service.ComponentUIServices
{
    public class CubeGenerate 
    {
        private static MeshGeometry3D MCube()
        {
            MeshGeometry3D cube = new MeshGeometry3D();
            Point3DCollection corners = new
                                   Point3DCollection();
            //corners.Add(new Point3D(0.5, 0.5, 0.5));
            //corners.Add(new Point3D(-0.5, 0.5, 0.5));
            //corners.Add(new Point3D(-0.5, -0.5, 0.5));
            //corners.Add(new Point3D(0.5, -0.5, 0.5));
            //corners.Add(new Point3D(0.5, 0.5, -0.5));
            //corners.Add(new Point3D(-0.5, 0.5, -0.5));
            //corners.Add(new Point3D(-0.5, -0.5, -0.5));
            //corners.Add(new Point3D(0.5, -0.5, -0.5));
            corners.Add(new Point3D(-0.5 ,-0.5 ,-0.5));
            corners.Add(new Point3D(0.5, -0.5,-0.5));
            corners.Add(new Point3D(-0.5, 0.5, -0.5));
            corners.Add(new Point3D(0.5 ,0.5 ,-0.5));
            corners.Add(new Point3D(-0.5 ,-0.5 ,0.5));
            corners.Add(new Point3D(0.5 ,-0.5 ,0.5));
            corners.Add(new Point3D(-0.5 ,0.5 ,0.5));
            corners.Add(new Point3D(0.5, 0.5 ,0.5));
            cube.Positions = corners;

            //Int32[] indices ={
            //                   //front
            //                     4,7,6,
            //                     4,6,5,
            //                  //back
            //                     0,1,2,
            //                     0,2,3,
            //                  //Right
            //                     4,0,3,
            //                     4,3,7,
            //                  //Left
            //                     1,5,6,
            //                     1,6,2,
            //                  //Top
            //                     1,0,4,
            //                     1,4,5,
            //                  //Bottom
            //                     2,6,7,
            //                     2,7,3
            //                  };
            Int32[] indices ={
                                2,3,1,  
                                2, 1, 0,  
                                7, 1, 3,  
                                7, 5, 1, 
                                6, 5, 7,  
                                6, 4, 5,  
                                6, 2, 0,  
                                2, 0, 4,  
                                2, 7, 3,  
                                2, 6, 7,  
                                0, 1, 5,  
                                0, 5, 4
                              };

            Int32Collection Triangles =
                                  new Int32Collection();
            foreach (Int32 index in indices)
            {
                Triangles.Add(index);
            }
            cube.TriangleIndices = Triangles;
            return cube;
        }

        public static void Create3dBox(Canvas canvas, double setLeft,double setTop)
        {
            GeometryModel3D Cube1 =
                                 new GeometryModel3D();
            MeshGeometry3D cubeMesh = MCube();
            Cube1.Geometry = cubeMesh;
            Brush br = new SolidColorBrush(Colors.Yellow);
            br.Opacity = 1;
            Cube1.Material = new DiffuseMaterial(
                      br);

            DirectionalLight dirlight1 =
                                new DirectionalLight();
            dirlight1.Color = Colors.White;
            //dirlight1.Direction =
            //                  new Vector3D(-1, 1, -1);
            PointLight ambientLight1 = new PointLight();
            ambientLight1.Color = Colors.White;

            PerspectiveCamera Camera1 =
                               new PerspectiveCamera();
            Camera1.FarPlaneDistance = 20;
            Camera1.NearPlaneDistance = 1;
            Camera1.FieldOfView = 45;
            Camera1.Position = new Point3D(2, 2, 3);
            Camera1.LookDirection =
                              new Vector3D(-2, -2, -3);
            Camera1.UpDirection =
                                 new Vector3D(0, 1, 0);

            Model3DGroup modelGroup =
                                    new Model3DGroup();
            modelGroup.Children.Add(Cube1);
            modelGroup.Children.Add(dirlight1);
            modelGroup.Children.Add(ambientLight1);
            ModelVisual3D modelsVisual =
                                   new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            Viewport3D myViewport = new Viewport3D();
            myViewport.Camera = Camera1;
            myViewport.Children.Add(modelsVisual);
            //myViewport.Children.Add(new ModelVisual3D() { Content = new AmbientLight(Colors.White) });
            myViewport.Height = 100;
            myViewport.Width = 100;


            // set location of box
            Canvas.SetTop(myViewport, setTop);
            Canvas.SetLeft(myViewport, setLeft);
            canvas.Children.Add(myViewport);

            #region 3D rotation 
            //AxisAngleRotation3D axis =
            //   new AxisAngleRotation3D(
            //     new Vector3D(0, 1, 0), 0);
            //RotateTransform3D Rotate =
            //             new RotateTransform3D(axis);
            //Cube1.Transform = Rotate;
            //DoubleAnimation RotAngle =
            //                   new DoubleAnimation();
            //RotAngle.From = 0;
            //RotAngle.To = 360;
            //RotAngle.Duration = new Duration(
            //             TimeSpan.FromSeconds(20.0));
            //RotAngle.RepeatBehavior =
            //                 RepeatBehavior.Forever;
            //NameScope.SetNameScope(Canvas1,
            //                       new NameScope());
            //Canvas1.RegisterName("cubeaxis", axis);
            //Storyboard.SetTargetName(RotAngle,
            //                           "cubeaxis");
            //Storyboard.SetTargetProperty(RotAngle,
            // new PropertyPath(
            //    AxisAngleRotation3D.AngleProperty));
            //Storyboard RotCube = new Storyboard();
            //RotCube.Children.Add(RotAngle);
            //RotCube.Begin(Canvas1);
            #endregion
        }
        public static void CreateEmpty3dBox(Canvas canvas, double setLeft,double setTop)
        {
            GeometryModel3D Cube1 =
                                 new GeometryModel3D();
            MeshGeometry3D cubeMesh = MCube();
            Cube1.Geometry = cubeMesh;
            Brush br = new SolidColorBrush(Colors.Red);
            br.Opacity = 1;
            Cube1.Material = new DiffuseMaterial(
                      br);

            //DirectionalLight dirlight1 =
            //                    new DirectionalLight();
            //dirlight1.Color = Colors.White;
            //dirlight1.Direction =
            //                  new Vector3D(0, 1, -1);

            PerspectiveCamera Camera1 =
                               new PerspectiveCamera();
            Camera1.FarPlaneDistance = 20;
            Camera1.NearPlaneDistance = 1;
            Camera1.FieldOfView = 45;
            Camera1.Position = new Point3D(2, 2, 3);
            Camera1.LookDirection =
                              new Vector3D(-2, -2, -3);
            Camera1.UpDirection =
                                 new Vector3D(0, 1, 0);

            Model3DGroup modelGroup =
                                    new Model3DGroup();
            modelGroup.Children.Add(Cube1);
            //modelGroup.Children.Add(dirlight1);
            ModelVisual3D modelsVisual =
                                   new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            Viewport3D myViewport = new Viewport3D();
            myViewport.Camera = Camera1;
            myViewport.Children.Add(modelsVisual);
            myViewport.Children.Add(new ModelVisual3D() { Content = new AmbientLight(Colors.White) });
            myViewport.Height = 100;
            myViewport.Width = 100;


            // set location of box
            Canvas.SetTop(myViewport, setTop);
            Canvas.SetLeft(myViewport, setLeft);
            canvas.Children.Add(myViewport);

            #region 3D rotation 
            //AxisAngleRotation3D axis =
            //   new AxisAngleRotation3D(
            //     new Vector3D(0, 1, 0), 0);
            //RotateTransform3D Rotate =
            //             new RotateTransform3D(axis);
            //Cube1.Transform = Rotate;
            //DoubleAnimation RotAngle =
            //                   new DoubleAnimation();
            //RotAngle.From = 0;
            //RotAngle.To = 360;
            //RotAngle.Duration = new Duration(
            //             TimeSpan.FromSeconds(20.0));
            //RotAngle.RepeatBehavior =
            //                 RepeatBehavior.Forever;
            //NameScope.SetNameScope(Canvas1,
            //                       new NameScope());
            //Canvas1.RegisterName("cubeaxis", axis);
            //Storyboard.SetTargetName(RotAngle,
            //                           "cubeaxis");
            //Storyboard.SetTargetProperty(RotAngle,
            // new PropertyPath(
            //    AxisAngleRotation3D.AngleProperty));
            //Storyboard RotCube = new Storyboard();
            //RotCube.Children.Add(RotAngle);
            //RotCube.Begin(Canvas1);
            #endregion
        }
        public static void CreateBasket(Canvas canvas, double setRight, double setBottom)
        {
            Cabinet cube = new Cabinet();
            cube.Height = 100;
            cube.Width = 100;
            Canvas.SetBottom(cube, setBottom);
            Canvas.SetRight(cube, setRight);
            canvas.Children.Add(cube);
        }
        public static void CreateBasketForUpdateLocation(Canvas canvas, double setRight, double setBottom)
        {
            Cabinet cube = new Cabinet();
            cube.Height = 60;
            cube.Width = 60;
            Canvas.SetBottom(cube, setBottom);
            Canvas.SetRight(cube, setRight);
            canvas.Children.Add(cube);
        }
        public static void CreateEmptyBasket(Canvas canvas, double setRight, double setBottom)
        {
            EmptyCabinet cube = new EmptyCabinet();
            cube.Height = 100;
            cube.Width = 100;
            Canvas.SetBottom(cube, setBottom);
            Canvas.SetRight(cube, setRight);
            canvas.Children.Add(cube);

        }

    }
}
