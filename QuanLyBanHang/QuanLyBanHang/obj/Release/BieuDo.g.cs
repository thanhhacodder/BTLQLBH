﻿#pragma checksum "..\..\BieuDo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E8D2774E2598F9D7374D33298D4FF2069F00EB481347906BCD15D1E60A4F589F"
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
using QuanLyBanHang;
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


namespace QuanLyBanHang {
    
    
    /// <summary>
    /// BieuDo
    /// </summary>
    public partial class BieuDo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 113 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker NgayTruoc;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker NgaySau;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThongke;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart CartesianChart;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker NgayTruocMonth;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker NgaySauMonth;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThongkeMonth;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\BieuDo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart SeriesCollectionMonth;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyBanHang;component/bieudo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BieuDo.xaml"
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
            this.NgayTruoc = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.NgaySau = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.btnThongke = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\BieuDo.xaml"
            this.btnThongke.Click += new System.Windows.RoutedEventHandler(this.BtnThongke_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CartesianChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 5:
            this.NgayTruocMonth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.NgaySauMonth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btnThongkeMonth = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\BieuDo.xaml"
            this.btnThongkeMonth.Click += new System.Windows.RoutedEventHandler(this.BtnThongkeMonth_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SeriesCollectionMonth = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

