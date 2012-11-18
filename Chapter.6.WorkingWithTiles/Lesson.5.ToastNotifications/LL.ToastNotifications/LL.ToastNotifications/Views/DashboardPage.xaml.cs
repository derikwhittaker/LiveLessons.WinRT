using LL.ToastNotifications.ViewModels;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.ToastNotifications.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.ToastNotifications.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel();
        }

    }
}
