﻿#pragma checksum "..\..\..\Views\Staff_InfoCustomer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6B5573E68EEB7A03E008F2150A9DAAA8CE2B1BA7E101DE13040CC577F6E865B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyCuaHangDaQuy.ViewModels;
using QuanLyCuaHangDaQuy.Views;
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
    /// Staff_InfoCustomer
    /// </summary>
    public partial class Staff_InfoCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FullName;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Email;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Birthday;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock IDPersonal;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Phonenumber;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\Views\Staff_InfoCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Point;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyCuaHangDaQuy;component/views/staff_infocustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Staff_InfoCustomer.xaml"
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
            
            #line 44 "..\..\..\Views\Staff_InfoCustomer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FullName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Email = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Birthday = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.IDPersonal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Phonenumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Point = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
