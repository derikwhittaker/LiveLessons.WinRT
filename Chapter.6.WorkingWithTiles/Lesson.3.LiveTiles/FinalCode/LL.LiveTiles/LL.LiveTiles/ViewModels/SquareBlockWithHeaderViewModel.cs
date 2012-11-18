using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class SquareBlockWithHeaderViewModel : SubpageBaseViewModel
    {

        protected override void CreateTile()
        {
            var applicationTile = TileContentFactory.CreateTileSquareText01();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.TextHeading.Text = this.Header;
            applicationTile.TextBody1.Text = this.Line1;
            applicationTile.TextBody2.Text = this.Line2;
            applicationTile.TextBody3.Text = this.Line3;

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }

    }
}