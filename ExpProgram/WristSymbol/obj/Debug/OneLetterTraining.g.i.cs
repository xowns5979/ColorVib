﻿#pragma checksum "..\..\OneLetterTraining.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5C1999DE7CEA24006FDF4C90DCAE064496AE3B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
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
using WristSymbol;


namespace WristSymbol {
    
    
    /// <summary>
    /// OneLetterTraining
    /// </summary>
    public partial class OneLetterTraining : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label title;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboboxM;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboboxTT;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line l1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label letter1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label answer1;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPlay;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEnter;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label trialLabel;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label clearLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label clockLabel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\OneLetterTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label debugLabel1;
        
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
            System.Uri resourceLocater = new System.Uri("/WristSymbol;component/onelettertraining.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OneLetterTraining.xaml"
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
            
            #line 14 "..\..\OneLetterTraining.xaml"
            ((WristSymbol.OneLetterTraining)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDownHandler);
            
            #line default
            #line hidden
            
            #line 15 "..\..\OneLetterTraining.xaml"
            ((WristSymbol.OneLetterTraining)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.title = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ComboboxM = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\OneLetterTraining.xaml"
            this.ComboboxM.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboboxM_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboboxTT = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\OneLetterTraining.xaml"
            this.ComboboxTT.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboboxTT_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.l1 = ((System.Windows.Shapes.Line)(target));
            return;
            case 6:
            this.letter1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.answer1 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.ButtonPlay = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\OneLetterTraining.xaml"
            this.ButtonPlay.Click += new System.Windows.RoutedEventHandler(this.ButtonPlay_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonEnter = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\OneLetterTraining.xaml"
            this.ButtonEnter.Click += new System.Windows.RoutedEventHandler(this.ButtonEnter_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.trialLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.clearLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.clockLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.debugLabel1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

