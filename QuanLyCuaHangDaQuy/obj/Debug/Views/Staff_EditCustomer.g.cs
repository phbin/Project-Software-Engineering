﻿#pragma checksum "..\..\..\Views\Staff_EditCustomer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F394A9F26C57F2E93AB9B7D22A846292C9957E2CD104BE02736651DDF504C7DB"
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
using System.Windows.Interactivity;
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
    /// Staff_EditCustomer
    /// </summary>
    public partial class Staff_EditCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuanLyCuaHangDaQuy.Views.Staff_EditCustomer Staff_EditCustomer1;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullName;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Birthday;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDPersonal;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phonenumber;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Point;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\..\Views\Staff_EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ID;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyCuaHangDaQuy;component/views/staff_editcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Staff_EditCustomer.xaml"
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
            this.Staff_EditCustomer1 = ((QuanLyCuaHangDaQuy.Views.Staff_EditCustomer)(target));
            return;
            case 2:
            
            #line 61 "..\..\..\Views\Staff_EditCustomer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Birthday = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.IDPersonal = ((System.Windows.Controls.TextBox)(target));
            
            #line 168 "..\..\..\Views\Staff_EditCustomer.xaml"
            this.IDPersonal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Point_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Phonenumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 190 "..\..\..\Views\Staff_EditCustomer.xaml"
            this.Phonenumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Phonenumber_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Point = ((System.Windows.Controls.TextBox)(target));
            
            #line 209 "..\..\..\Views\Staff_EditCustomer.xaml"
            this.Point.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Point_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ID = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

