using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class WideImageWithSmallImageViewModel : SubpageBaseViewModel
    {
        public WideImageWithSmallImageViewModel()
        {
            this.ImagePath = "Images/LiveTileImage_310x150.png";
            this.SmallImagePath = "Images/LiveTileImage_150x150.png";
        }

        protected override void CreateTile()
        {
        }
    }
}
