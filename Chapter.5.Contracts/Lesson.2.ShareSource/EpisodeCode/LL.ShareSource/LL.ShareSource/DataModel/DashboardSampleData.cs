using LL.ShareSource.ViewModels;

namespace LL.ShareSource.DataModel
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
