﻿#pragma checksum "..\..\..\..\Scripts\View\CodeTree.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D9CDF646C5B309492DEF3F2405149EB82F33BC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CodeReader;
using CodeReader.Scripts.Converters;
using CodeReader.Scripts.Model;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
using Notifications.Wpf.Controls;
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


namespace CodeReader.Scripts.View {
    
    
    /// <summary>
    /// CodeTree
    /// </summary>
    public partial class CodeTree : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CodeReader.Scripts.View.CodeTree CodeTreeControl;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Notifications.Wpf.Controls.NotificationArea NotificationsArea;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition controlRow;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition firstColumn;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Scripts\View\CodeTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView codeTree;
        
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
            System.Uri resourceLocater = new System.Uri("/CodeReader;component/scripts/view/codetree.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Scripts\View\CodeTree.xaml"
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
            this.CodeTreeControl = ((CodeReader.Scripts.View.CodeTree)(target));
            return;
            case 2:
            
            #line 19 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddChildMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RenameMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 43 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 54 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.NotificationsArea = ((Notifications.Wpf.Controls.NotificationArea)(target));
            return;
            case 9:
            this.controlRow = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 10:
            
            #line 80 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.Grid)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Grid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.firstColumn = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 12:
            
            #line 92 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddParent_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 99 "..\..\..\..\Scripts\View\CodeTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddChild_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.codeTree = ((System.Windows.Controls.TreeView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 15:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseRightButtonDownEvent;
            
            #line 135 "..\..\..\..\Scripts\View\CodeTree.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.TreeViewItem_PreviewMouseRightButtonDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.TreeViewItem.SelectedEvent;
            
            #line 136 "..\..\..\..\Scripts\View\CodeTree.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.TreeViewItem_Selected);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseLeftButtonDownEvent;
            
            #line 137 "..\..\..\..\Scripts\View\CodeTree.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.TreeItemPreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

