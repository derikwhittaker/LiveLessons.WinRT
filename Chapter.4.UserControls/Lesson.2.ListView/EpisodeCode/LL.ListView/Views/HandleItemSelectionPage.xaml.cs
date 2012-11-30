﻿using LL.ListView.ViewModels;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.ListView.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HandleItemSelectionPage : LL.ListView.Common.LayoutAwarePage
    {
        public HandleItemSelectionPage()
        {
            this.InitializeComponent();

            DataContext = new HandleItemSelectionViewModel();
        }

        
    }
}
