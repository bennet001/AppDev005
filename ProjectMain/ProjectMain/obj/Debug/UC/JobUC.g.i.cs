﻿#pragma checksum "..\..\..\UC\JobUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F893A0D3A9F4869CF9335C315F6C329"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectMain;
using ProjectMain.Enums;
using ProjectMain.UC;
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


namespace ProjectMain.UC {
    
    
    /// <summary>
    /// JobUC
    /// </summary>
    public partial class JobUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ProjectMain.UC.JobUC JobUCpopup;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid JobDesc;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobIDInput;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobTitleinput;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobDescriptionInput;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JobDescJobEmployee;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AssignedEmployees;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JobDescPriority;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\UC\JobUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddJob;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\UC\JobUC.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ProjectMain;component/uc/jobuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UC\JobUC.xaml"
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
            this.JobUCpopup = ((ProjectMain.UC.JobUC)(target));
            return;
            case 2:
            this.JobDesc = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.JobIDInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.JobTitleinput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.JobDescriptionInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.JobDescJobEmployee = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AssignedEmployees = ((System.Windows.Controls.ListBox)(target));
            
            #line 162 "..\..\..\UC\JobUC.xaml"
            this.AssignedEmployees.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.AssignedEmployees_MouseRightButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.JobDescPriority = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.AddJob = ((System.Windows.Controls.Button)(target));
            
            #line 214 "..\..\..\UC\JobUC.xaml"
            this.AddJob.Click += new System.Windows.RoutedEventHandler(this.AddJob_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AddEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 219 "..\..\..\UC\JobUC.xaml"
            this.AddEmployee.Click += new System.Windows.RoutedEventHandler(this.AddEmployee_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

