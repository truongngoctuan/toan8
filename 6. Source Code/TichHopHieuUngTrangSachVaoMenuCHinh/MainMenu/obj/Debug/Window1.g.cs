﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C6A9D6CE467B682C797752FA7A7DCD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ColorSwatch;
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
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\Window1.xaml"
        internal ColorSwatch.Window1 Color_Swatch;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid root;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid header;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Window1.xaml"
        internal System.Windows.Shapes.Rectangle menuBar;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Window1.xaml"
        internal System.Windows.Controls.StackPanel stackMenu;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Window1.xaml"
        internal System.Windows.Controls.Grid splashGrid;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Window1.xaml"
        internal System.Windows.Controls.Image splash;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Window1.xaml"
        internal ColorSwatch.Room roomControl;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Window1.xaml"
        internal System.Windows.Controls.Image image1;
        
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
            System.Uri resourceLocater = new System.Uri("/ColorSwatch;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Color_Swatch = ((ColorSwatch.Window1)(target));
            return;
            case 2:
            this.root = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.header = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.menuBar = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.stackMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 91 "..\..\Window1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnExit);
            
            #line default
            #line hidden
            return;
            case 7:
            this.splashGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.splash = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.roomControl = ((ColorSwatch.Room)(target));
            return;
            case 10:
            this.image1 = ((System.Windows.Controls.Image)(target));
            
            #line 120 "..\..\Window1.xaml"
            this.image1.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.image1_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
