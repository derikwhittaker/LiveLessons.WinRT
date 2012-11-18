using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.SecondaryTiles.DataModel;
using LL.SecondaryTiles.ViewModels;
using Metro.LL.Common.Models;

namespace LL.SecondaryTiles.DataModel
{
    public class DashboardSampleData : DashboardViewModel
    {
        public DashboardSampleData() : base()
        {

        }

        public DashboardItemModel SelectedItem
        {
            get { return Items[0]; }
        }
    }
}
