﻿#pragma checksum "..\..\..\Views\use_Chat.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E4F76E20FB20D8BEEB28921B2CEE4D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Shell;
using _1312658.Views;


namespace _1312658.Views {
    
    
    /// <summary>
    /// use_Chat
    /// </summary>
    public partial class use_Chat : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Chat;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Your_Name;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Chane;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_KhungChat;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox txt_Chat;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Input_Chat;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\use_Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Send;
        
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
            System.Uri resourceLocater = new System.Uri("/1312658;component/views/use_chat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\use_Chat.xaml"
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
            this.Grid_Chat = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txt_Your_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btn_Chane = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Views\use_Chat.xaml"
            this.btn_Chane.Click += new System.Windows.RoutedEventHandler(this.btn_Chane_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbl_KhungChat = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txt_Chat = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.txt_Input_Chat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btn_Send = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Views\use_Chat.xaml"
            this.btn_Send.Click += new System.Windows.RoutedEventHandler(this.btn_Send_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

