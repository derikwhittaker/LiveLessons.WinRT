using LL.Gyrometer.ViewModels;
using Windows.UI.Xaml;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.Gyrometer.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.Gyrometer.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardViewModel();

            this.Loaded += (sender, args) =>
                {
                    var width = EllipseCanvas.ActualWidth;
                    var height = EllipseCanvas.ActualHeight;
                    ((DashboardViewModel) DataContext).SetupDefaultLocation(width, height);
                };
        }
    }
}
