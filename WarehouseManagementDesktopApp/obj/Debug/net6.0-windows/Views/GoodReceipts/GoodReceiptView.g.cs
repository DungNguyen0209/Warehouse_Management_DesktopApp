﻿#pragma checksum "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62F8F41670CAC2811908164D493663CCC564728D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WarehouseManagementDesktopApp.Core.ValueConverter.MyApp.Tools;
using WarehouseManagementDesktopApp.Resources.Components;
using WarehouseManagementDesktopApp.Views.GoodReceipts;


namespace WarehouseManagementDesktopApp.Views.GoodReceipts {
    
    
    /// <summary>
    /// GoodReceiptView
    /// </summary>
    public partial class GoodReceiptView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WarehouseManagementDesktopApp.Views.GoodReceipts.GoodReceiptView GoodReceipt;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TargetTypecb;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BasketIdtb;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WarehouseManagementDesktopApp.Resources.Components.AutoCompleteTextBox ProductIdtb;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductNametb;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Productiondaytb;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantitytb;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Unittb;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddQuantitytb;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Savebtn;
        
        #line default
        #line hidden
        
        
        #line 309 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Addbtn;
        
        #line default
        #line hidden
        
        
        #line 325 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Searchbtn;
        
        #line default
        #line hidden
        
        
        #line 335 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Uploadbtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WarehouseManagementDesktopApp;component/views/goodreceipts/goodreceiptview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GoodReceipt = ((WarehouseManagementDesktopApp.Views.GoodReceipts.GoodReceiptView)(target));
            return;
            case 2:
            this.TargetTypecb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 95 "..\..\..\..\..\Views\GoodReceipts\GoodReceiptView.xaml"
            this.TargetTypecb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TargetTypecb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BasketIdtb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ProductIdtb = ((WarehouseManagementDesktopApp.Resources.Components.AutoCompleteTextBox)(target));
            return;
            case 5:
            this.ProductNametb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Productiondaytb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Quantitytb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Unittb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.AddQuantitytb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Savebtn = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.Addbtn = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.Searchbtn = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.Uploadbtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

