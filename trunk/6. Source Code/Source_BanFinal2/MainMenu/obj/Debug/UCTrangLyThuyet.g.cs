﻿#pragma checksum "..\..\UCTrangLyThuyet.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "79A2372DF7213DEFE04361FB8DFF218B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ColorSwatch {
    
    
    /// <summary>
    /// UCTrangLyThuyet
    /// </summary>
    public partial class UCTrangLyThuyet : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\UCTrangLyThuyet.xaml"
        internal System.Windows.Controls.DocumentViewer xpsViewer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ColorSwatch;component/uctranglythuyet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCTrangLyThuyet.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 1 "..\..\UCTrangLyThuyet.xaml"
            ((ColorSwatch.UCTrangLyThuyet)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UCTrangLyThuyet_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.xpsViewer = ((System.Windows.Controls.DocumentViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
