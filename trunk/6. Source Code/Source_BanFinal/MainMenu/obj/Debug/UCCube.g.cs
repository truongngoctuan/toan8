﻿#pragma checksum "..\..\UCCube.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "203A8626A3AACF5ABA22299FEF5353ED"
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
    /// UCCube
    /// </summary>
    public partial class UCCube : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\UCCube.xaml"
        internal System.Windows.Controls.Viewport3D myViewport3D;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\UCCube.xaml"
        internal System.Windows.Media.Media3D.ScaleTransform3D myScale;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\UCCube.xaml"
        internal System.Windows.Media.Media3D.AxisAngleRotation3D myRotate;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\UCCube.xaml"
        internal System.Windows.Media.Media3D.AxisAngleRotation3D myRotate2;
        
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
            System.Uri resourceLocater = new System.Uri("/HocTotToan8;component/uccube.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCCube.xaml"
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
            this.myViewport3D = ((System.Windows.Controls.Viewport3D)(target));
            return;
            case 2:
            this.myScale = ((System.Windows.Media.Media3D.ScaleTransform3D)(target));
            return;
            case 3:
            this.myRotate = ((System.Windows.Media.Media3D.AxisAngleRotation3D)(target));
            return;
            case 4:
            this.myRotate2 = ((System.Windows.Media.Media3D.AxisAngleRotation3D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
