using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class SquareBlockWithImageOnlyViewModel : SubpageBaseViewModel
    {
        public SquareBlockWithImageOnlyViewModel()
        {
            this.ImagePath = "Images/LiveTileImage_150x150.png";
        }

        protected override void CreateTile()
        {
            var applicationTile = TileContentFactory.CreateTileSquareImage();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.Image.Src = this.ImagePath;

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }

    }
}