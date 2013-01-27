using LL.VSM.ViewModels;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.VSM.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.VSM.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel();
        }
    }
}
