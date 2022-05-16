global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Windows;
global using System.Threading.Tasks;
global using Newtonsoft.Json;
global using System.Net;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Threading;
global using WarehouseManagementDesktopApp.Core.ViewModel.BaseViewModels;
global using WarehouseManagementDesktopApp.Core.Domain.Stores;
global using WarehouseManagementDesktopApp.Core.Service.Interfaces;
global using WarehouseManagementDesktopApp.Core.ViewModel.Commands;
global using System.Collections.ObjectModel;
global using WarehouseManagementDesktopApp.Core.Store;
global using WarehouseManagementDesktopApp.Core.ValueConverter;
global using WarehouseManagementDesktopApp.Core.Services.Interfaces;
global using WarehouseManagementDesktopApp.Core.Domain.Communication;
global using WarehouseManagementDesktopApp.Core.Domain.ViewModel;
global using Microsoft.Win32;
global using OfficeOpenXml;
global using OfficeOpenXml.Drawing;
global using Syncfusion.XlsIO;
global using System.IO;
global using EPPlus;
global using WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;
global using MaterialDesignThemes.Wpf;
global using  AutoMapper;
global using WarehouseManagementDesktopApp.Core.Domain.Mapping;
global using IdentityModel.OidcClient.Browser;
global using Microsoft.Web.WebView2.Wpf;
global using Persistence.SqliteDB.Domain.Model.GoodExport;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodIssue;
global using WarehouseManagementDesktopApp.Core.Domain.Model;
global using WarehouseManagementDesktopApp.Core.Domain.Model.Api;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.Item;
global using WarehouseManagementDesktopApp.Core.Domain.Model.Resource;
global using Container = WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers.Container;
global using MessageBox = WarehouseManagementDesktopApp.Core.ComponentUI.MessageBox;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.History;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.Report;
global using WarehouseManagementDesktopApp.Core.Domain.View;
global using WarehouseManagementDesktopApp.Core.Domain.View.Report;
global using Persistence.SqliteDB.Domain.Model;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.StockCard;
global using WarehouseManagementDesktopApp.Core.Domain.View.History;
global using WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodReceipt;
global using WarehouseManagementDesktopApp.Core.ViewModels;
#region Command
global using System.ComponentModel;
global using System.Runtime.CompilerServices;
global using System.Windows.Input;
#endregion

#region Converter
global using System.Globalization;
global using System.Windows.Data;
global using System.Windows.Markup;

#endregion
#region Domain
#endregion
#region Persistance
global using Persistence.SqliteDB.Domain.Interfaces;
#endregion
