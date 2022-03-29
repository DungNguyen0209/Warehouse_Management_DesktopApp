#region Root
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using System;
global using System.Collections.Generic;
global using System.Configuration;
global using System.Data;
global using System.Linq;
global using System.Threading.Tasks;
global using System.Windows;
global using WarehouseManagementDesktopApp.HostBuilder;
global using WarehouseManagementDesktopApp.Core.ViewModels;
#endregion

#region View
global using System.Windows.Controls;
global using System.Windows.Data;
global using System.Windows.Documents;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.Windows.Media.Imaging;
global using System.Windows.Navigation;
global using System.Windows.Shapes;
global using WarehouseManagementDesktopApp.Core.Domain.Models.Views;
global using WarehouseManagementDesktopApp.Core.ViewModel.BaseViewModels;
global using WarehouseManagementDesktopApp.Core.Services.Interfaces;
global using WarehouseManagementDesktopApp.Core.Services;
global using System.Windows.Media.Media3D;
global using FontAwesome.WPF;
global using System.Reflection.Metadata;
global using WarehouseManagementDesktopApp.Core.Domain.Models.Resources;
global using WarehouseManagementDesktopApp.Resources.Components;
#endregion

#region HostBuilder
global using WarehouseManagementDesktopApp.Core.Service;
global using WarehouseManagementDesktopApp.Core.Service.Interfaces;
global using WarehouseManagementDesktopApp.Core.ViewModel;
global using System.Text;
global using WarehouseManagementDesktopApp.Core.ValueConverter;
global using WarehouseManagementDesktopApp.Core.Domain.Stores;
global using Microsoft.Extensions.Configuration;
#endregion