using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class WideImagePeekViewModel : SubpageBaseViewModel
    {
        public WideImagePeekViewModel()
        {
            this.ImagePath = "Images/LiveTileImage_310x150.png";            
        }

        protected override void CreateTile()
        {
        }
    }
}