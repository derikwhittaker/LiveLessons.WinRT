using LL.ShareTarget.ViewModels;

namespace LL.ShareTarget.DataModel
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
