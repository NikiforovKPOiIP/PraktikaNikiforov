﻿#pragma checksum "..\..\..\AllPage\PageOperationPriemka.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B851111F52CBA3A6399A4107D0058E10B112C6271553F8BC2F7A16068B51A4F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Diplom_Storage.AllPage;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Diplom_Storage.AllPage {
    
    
    /// <summary>
    /// PageOperation
    /// </summary>
    public partial class PageOperation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\AllPage\PageOperationPriemka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SearchBar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AllPage\PageOperationPriemka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\AllPage\PageOperationPriemka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OperTabl;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AllPage\PageOperationPriemka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Priem;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AllPage\PageOperationPriemka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clear;
        
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
            System.Uri resourceLocater = new System.Uri("/Diplom_Storage;component/allpage/pageoperationpriemka.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AllPage\PageOperationPriemka.xaml"
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
            
            #line 9 "..\..\..\AllPage\PageOperationPriemka.xaml"
            ((Diplom_Storage.AllPage.PageOperation)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchBar = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\AllPage\PageOperationPriemka.xaml"
            this.searchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OperTabl = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\AllPage\PageOperationPriemka.xaml"
            this.OperTabl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OperTabl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Priem = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\AllPage\PageOperationPriemka.xaml"
            this.Priem.Click += new System.Windows.RoutedEventHandler(this.Priem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Clear = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\AllPage\PageOperationPriemka.xaml"
            this.Clear.Click += new System.Windows.RoutedEventHandler(this.Clear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

