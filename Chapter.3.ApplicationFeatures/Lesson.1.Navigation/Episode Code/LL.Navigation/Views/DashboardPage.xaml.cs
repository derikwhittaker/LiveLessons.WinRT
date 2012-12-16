using LL.Navigation.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.Navigation.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.Navigation.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();

            var frame = Window.Current.Content as Frame;
            DataContext = new DashboardViewModel(frame);
        }

    }
}
