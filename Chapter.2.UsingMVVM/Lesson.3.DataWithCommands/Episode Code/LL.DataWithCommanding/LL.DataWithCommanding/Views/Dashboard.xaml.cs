using LL.DataWithCommanding.Data;
using System;
using System.Collections.Generic;
using LL.DataWithCommanding.ViewModels;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace LL.DataWithCommanding.Views
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for the
    /// currently selected item.
    /// </summary>
    public sealed partial class Dashboard : LL.DataWithCommanding.Common.LayoutAwarePage
    {
        public Dashboard()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel();
        }


    }
}
