﻿#pragma checksum "..\..\New.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "430993B1864182ABB7D47C9DEBF17AA39E576186874B83B4CA9F6711958991F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sorozatok;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Sorozatok {
    
    
    /// <summary>
    /// New
    /// </summary>
    public partial class New : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox akt_evad;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox akt_resz;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label n;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label s;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label e;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border p;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\New.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox type;
        
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
            System.Uri resourceLocater = new System.Uri("/Sorozatok;component/new.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\New.xaml"
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
            this.name1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\New.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.name_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.akt_evad = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\New.xaml"
            this.akt_evad.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.aktevad_TextChanged);
            
            #line default
            #line hidden
            
            #line 17 "..\..\New.xaml"
            this.akt_evad.KeyDown += new System.Windows.Input.KeyEventHandler(this.akt_evad_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.akt_resz = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\New.xaml"
            this.akt_resz.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.aktresz_TextChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\New.xaml"
            this.akt_resz.KeyDown += new System.Windows.Input.KeyEventHandler(this.akt_resz_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.n = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.s = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.e = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.img1 = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\New.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.p = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.type = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\New.xaml"
            this.type.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.type_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

