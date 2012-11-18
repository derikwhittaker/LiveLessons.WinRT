using LL.LiveTiles.Common;
using LL.LiveTiles.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace LL.LiveTiles.Views
{
    public sealed partial class WideImageCollectionPage : LayoutAwarePage
    {
        public WideImageCollectionPage()
        {
            this.InitializeComponent();

            DataContext = new WideImageCollectionViewModel();
        }
    }
}
