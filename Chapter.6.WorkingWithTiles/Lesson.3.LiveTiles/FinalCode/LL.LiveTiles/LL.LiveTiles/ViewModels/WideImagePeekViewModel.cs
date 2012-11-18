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
            var applicationTile = TileContentFactory.CreateTileWidePeekImageAndText02();
            var smallApplicationTile = TileContentFactory.CreateTileSquareImage();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.Image.Src = this.ImagePath;
            smallApplicationTile.Image.Src = "Images/LiveTileImage_150x150.png";

            applicationTile.SquareContent = smallApplicationTile;
            applicationTile.TextBody1.Text = this.Line1;
            applicationTile.TextBody2.Text = this.Line2;

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }
    }
}