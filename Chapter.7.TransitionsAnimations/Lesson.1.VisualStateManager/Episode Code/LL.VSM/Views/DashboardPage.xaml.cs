using LL.VSM.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

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

        private void ToggleEnableClick(object sender, RoutedEventArgs e)
        {
            MyToggleSwitch.IsEnabled = !MyToggleSwitch.IsEnabled;
            MyCustomControl.IsEnabled = !MyCustomControl.IsEnabled;
        }
    }
}
