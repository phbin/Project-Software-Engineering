﻿#pragma checksum "..\..\..\Resources\CustomMessageBoxWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "317FACA369ACC6D84B8ED0A42F8FF24C3EBCA6E625B86BBB36E71C40E8B79F2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GemstonesBusinessManagementSystem.Views;
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


namespace GemstonesBusinessManagementSystem.Views {
    
    
    internal partial class CustomMessageBoxWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_MessageBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Message;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Cancel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Cancel;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_No;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_No;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Yes;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Yes;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_OK;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Ok;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyCuaHangDaQuy;component/resources/custommessageboxwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
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
            this.Image_MessageBox = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.TextBlock_Message = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Button_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
            this.Button_Cancel.Click += new System.Windows.RoutedEventHandler(this.Button_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Label_Cancel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Button_No = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
            this.Button_No.Click += new System.Windows.RoutedEventHandler(this.Button_No_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Label_No = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Button_Yes = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
            this.Button_Yes.Click += new System.Windows.RoutedEventHandler(this.Button_Yes_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Label_Yes = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Button_OK = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\Resources\CustomMessageBoxWindow.xaml"
            this.Button_OK.Click += new System.Windows.RoutedEventHandler(this.Button_OK_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Label_Ok = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

