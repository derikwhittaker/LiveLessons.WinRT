using LL.ShareTarget.ViewModels;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LL.ShareTarget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SharePage : Page
    {
        private ShareOperation _shareOperation;
        public SharePage()
        {
            InitializeComponent();
            DataContext = new ShareViewModel();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _shareOperation = (ShareOperation)e.Parameter;

            ((ShareViewModel) DataContext).ActiveSync(_shareOperation);
        }
    }
}
