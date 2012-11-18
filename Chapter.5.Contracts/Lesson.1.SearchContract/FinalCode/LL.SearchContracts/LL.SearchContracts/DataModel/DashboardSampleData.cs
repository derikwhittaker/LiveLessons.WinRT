using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.SearchContracts.ViewModels;
using Metro.LL.Common.Models;

namespace LL.SearchContracts.DataModel
{
    public class DashboardSampleData : DashboardViewModel
    {
        public DashboardSampleData() : base()
        {

        }

        public SearchItemModel SelectedItem
        {
            get { return Items[0]; }
        }
    }
}
