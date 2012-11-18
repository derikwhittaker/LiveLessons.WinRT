using LL.LiveTiles.Common;
using LL.LiveTiles.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace LL.LiveTiles.Views
{
    public sealed partial class SquareBlockWithHeaderPage : LayoutAwarePage
    {
        public SquareBlockWithHeaderPage()
        {
            this.InitializeComponent();

            DataContext = new SquareBlockWithHeaderViewModel();
        }
    }
}
