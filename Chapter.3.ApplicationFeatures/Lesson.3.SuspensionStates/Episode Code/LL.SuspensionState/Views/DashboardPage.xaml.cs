using LL.SuspensionState.ViewModels;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.SuspensionState.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.SuspensionState.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel();
        }

    }
}
