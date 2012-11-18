using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.LiveTiles.ViewModels
{
    public class WideImageCollectionViewModel : SubpageBaseViewModel
    {

        public WideImageCollectionViewModel()
        {
            this.ImagePath = "Images/LiveTileImage_310x150.png";
            this.SmallImagePath = "Images/LiveTileImage_150x150.png";
            this.SmallImageCollection1Path = "Images/RedSmallSquare.png";
            this.SmallImageCollection2Path = "Images/GreenSmallSquare.png";
            this.SmallImageCollection3Path = "Images/BlueSmallSquare.png";
            this.SmallImageCollection4Path = "Images/BrownSmallSquare.png";
        }

        protected override void CreateTile()
        {
            var applicationTile = TileContentFactory.CreateTileWidePeekImageCollection01();
            var smallApplicationTile = TileContentFactory.CreateTileSquareImage();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();

            applicationTile.ImageMain.Src = this.ImagePath;
            smallApplicationTile.Image.Src = this.SmallImagePath;
            applicationTile.ImageSmallColumn1Row1.Src = this.SmallImageCollection1Path;
            applicationTile.ImageSmallColumn1Row2.Src = this.SmallImageCollection2Path;
            applicationTile.ImageSmallColumn2Row1.Src = this.SmallImageCollection3Path;
            applicationTile.ImageSmallColumn2Row2.Src = this.SmallImageCollection4Path;

            applicationTile.SquareContent = smallApplicationTile;

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }
    }
}