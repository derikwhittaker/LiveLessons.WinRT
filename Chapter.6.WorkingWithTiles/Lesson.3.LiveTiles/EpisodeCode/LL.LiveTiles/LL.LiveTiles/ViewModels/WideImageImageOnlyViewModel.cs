using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class WideImageImageOnlyViewModel : SubpageBaseViewModel
    {
        public WideImageImageOnlyViewModel()
        {
            this.ImagePath = "Images/LiveTileImage_310x150.png";
        }

        protected override void CreateTile()
        {
            var applicationTile = TileContentFactory.CreateTileWideImage();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.Image.Src = this.ImagePath;

            applicationTile.RequireSquareContent = false;
            
            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }
    }
}