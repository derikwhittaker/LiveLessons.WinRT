using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LL.SettingsContract.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsFlyoutPage : Page
    {
        public SettingsFlyoutPage()
        {
            this.InitializeComponent();
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            var parent = Parent as Popup;
            if (parent != null)
            {
                parent.IsOpen = false;
            }

        }
    }
}
