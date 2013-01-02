﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LL.Navigation.Common;
using LL.Navigation.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.Navigation.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ArgumentNavigationPage : LL.Navigation.Common.LayoutAwarePage
    {
        public ArgumentNavigationPage()
        {
            this.InitializeComponent();

            var frame = Window.Current.Content as Frame;
            DataContext = new ArgumentNavigationViewModel(frame);
        }

    }
}