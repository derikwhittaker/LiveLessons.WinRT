using LL.Inclinometer.ViewModels;
using Windows.UI.Xaml;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.Inclinometer.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.Inclinometer.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();
            
            DataContext = new DashboardViewModel(Window.Current.Dispatcher);

            // need to do this simply to allow us to center the ellipse
            Loaded += (sender, args) =>
                {
                    var width = EllipseCanvas.ActualWidth;
                    var height = EllipseCanvas.ActualHeight;
                    ((DashboardViewModel)DataContext).SetupDefaultLocation(width, height);
                };
        }
    }
}
