﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LL.Inclinometer.ViewModels;
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

namespace LL.Inclinometer.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.Inclinometer.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel(Window.Current.Dispatcher);

            this.Loaded += (sender, args) =>
                {
                    var width = EllipseCanvas.ActualWidth;
                    var height = EllipseCanvas.ActualHeight;
                    ((DashboardViewModel)DataContext).SetupDefaultLocation(width, height);
                };
        }
    }
}
