﻿#pragma checksum "..\..\..\Contacts\PublicDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D8F9C5C76052EC2AE07ABBF18F079CBA"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using WpfClient.Teams.Control;


namespace WpfClient.Contacts {
    
    
    /// <summary>
    /// PublicDialog
    /// </summary>
    public partial class PublicDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_Title;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel NoticeStackPanel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputNoticeTBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button input;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrap1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button docButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button videoButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrap2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Contacts\PublicDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button taskButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfClient;component/contacts/publicdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Contacts\PublicDialog.xaml"
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
            this.lb_Title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.NoticeStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.InputNoticeTBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\Contacts\PublicDialog.xaml"
            this.InputNoticeTBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.input = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Contacts\PublicDialog.xaml"
            this.input.Click += new System.Windows.RoutedEventHandler(this.input_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.wrap1 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 6:
            this.docButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Contacts\PublicDialog.xaml"
            this.docButton.Click += new System.Windows.RoutedEventHandler(this.docButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.videoButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Contacts\PublicDialog.xaml"
            this.videoButton.Click += new System.Windows.RoutedEventHandler(this.videoButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.wrap2 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 9:
            this.taskButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Contacts\PublicDialog.xaml"
            this.taskButton.Click += new System.Windows.RoutedEventHandler(this.taskButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
