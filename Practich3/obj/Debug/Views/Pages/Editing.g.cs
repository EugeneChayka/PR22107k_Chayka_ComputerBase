﻿#pragma checksum "..\..\..\..\Views\Pages\Editing.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "20BFFB4D23DD383ED5B7DFDF45EA5E28735DF75FFA0F3F49C308A5588A3AF2C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Practich3.Views.Pages;
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


namespace Practich3.Views.Pages {
    
    
    /// <summary>
    /// Editing
    /// </summary>
    public partial class Editing : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSurname;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPatronymic;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLogin;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPhone;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPost;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\Pages\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
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
            System.Uri resourceLocater = new System.Uri("/Practich3;component/views/pages/editing.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\Editing.xaml"
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
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\..\Views\Pages\Editing.xaml"
            this.tbName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\Views\Pages\Editing.xaml"
            this.tbSurname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbSurname_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbPatronymic = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\Views\Pages\Editing.xaml"
            this.tbPatronymic.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbPatronymic_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\..\Views\Pages\Editing.xaml"
            this.tbPhone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbPhone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Views\Pages\Editing.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Views\Pages\Editing.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.btnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbPost = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Views\Pages\Editing.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

