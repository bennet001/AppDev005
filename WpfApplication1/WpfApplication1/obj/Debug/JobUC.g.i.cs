﻿#pragma checksum "..\..\JobUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8676589565F27B7AC78BC25B511C9EE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
using WpfApplication1;


namespace WpfApplication1 {
    
    
    /// <summary>
    /// JobUC
    /// </summary>
    public partial class JobUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid JobDesc;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobDescJobTitle;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobDescJobDescription;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JobDescJobEmployee;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label JobDescSupervisor;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JobDescPriority;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddJob;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/jobuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\JobUC.xaml"
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
            this.JobDesc = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 2:
            this.JobDescJobTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.JobDescJobDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.JobDescJobEmployee = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.JobDescSupervisor = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.JobDescPriority = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AddJob = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\JobUC.xaml"
            this.AddJob.Click += new System.Windows.RoutedEventHandler(this.AddJob_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\JobUC.xaml"
            this.AddEmployee.Click += new System.Windows.RoutedEventHandler(this.AddEmployee_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

