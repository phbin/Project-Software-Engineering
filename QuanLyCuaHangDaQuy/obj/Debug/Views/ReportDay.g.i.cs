﻿#pragma checksum "..\..\..\Views\ReportDay.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "154DA7837B7BF7ABC4E181AB147A745C6F7405C736A940F92D591A09EFAB9FFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyCuaHangDaQuy;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace QuanLyCuaHangDaQuy.Views {
    
    
    /// <summary>
    /// ReportDay
    /// </summary>
    public partial class ReportDay : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_TotalYear;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_TotalDay;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_TotalMonth;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_BackMonth;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_BackYear;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Views\ReportDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_Title;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyCuaHangDaQuy;component/views/reportday.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ReportDay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tb_TotalYear = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tb_TotalDay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tb_TotalMonth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btn_BackMonth = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Views\ReportDay.xaml"
            this.btn_BackMonth.Click += new System.Windows.RoutedEventHandler(this.btn_Back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_BackYear = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Views\ReportDay.xaml"
            this.btn_BackYear.Click += new System.Windows.RoutedEventHandler(this.btn_BackYear_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tb_Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

