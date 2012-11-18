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
            var applicationTile = TileContentFactory.CreateTileWideImage();
            var smallApplicationTile = TileContentFactory.CreateTileSquareImage();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.Image.Src = this.ImagePath;
            smallApplicationTile.Image.Src = this.SmallImagePath;

            applicationTile.SquareContent = smallApplicationTile;

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }
    }
}
