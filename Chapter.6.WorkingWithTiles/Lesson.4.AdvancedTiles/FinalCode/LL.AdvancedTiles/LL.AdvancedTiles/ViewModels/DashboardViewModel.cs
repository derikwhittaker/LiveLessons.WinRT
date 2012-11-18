using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;
using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

namespace LL.AdvancedTiles.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private RelayCommand _updateStaticLiveTileCommand;
        private RelayCommand _futureLiveTileCommand;
        private RelayCommand _clearLiveTileCommand;
        private bool _expireContent;
        private RelayCommand _queryFutureLiveTileCommand;

        public DashboardViewModel()
        {
            PageTitle = "Advanced Tiles";
        }

        #region Clear Tiles

        public RelayCommand ClearLiveTileCommand
        {
            get { return _clearLiveTileCommand ?? (_clearLiveTileCommand = new RelayCommand(ClearLiveTile)); }
        }

        private void ClearLiveTile()
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            // clear the existing tile info
            tileUpdater.Clear();
        }

        #endregion

        #region Future Tiles

        public RelayCommand FutureLiveTileCommand
        {
            get { return _futureLiveTileCommand ?? (_futureLiveTileCommand = new RelayCommand(FutureLiveTile)); }
        }

        private void FutureLiveTile()
        {
            var applicationTile = TileContentFactory.CreateTileWidePeekImage02();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            // clear the existing tile info
            tileUpdater.Clear();

            applicationTile.TextHeading.Text = "Future Top Scores";
            applicationTile.TextBody1.Text = "Future Player 1 - 100";
            applicationTile.TextBody2.Text = "Future Player 1 - 92";
            applicationTile.TextBody3.Text = "Future Player 1 - 90";
            applicationTile.TextBody4.Text = "Future Player 1 - 85";

            applicationTile.RequireSquareContent = false;
            applicationTile.Image.Src = "/Images/AltLiveTileImage_310x150.png";

            var futureTile = new ScheduledTileNotification(applicationTile.GetXml(), DateTime.Now.AddSeconds(10));
            
            if ( ExpireContent )
            {
                futureTile.ExpirationTime = DateTime.Now.AddSeconds(20);
            }

            tileUpdater.AddToSchedule(futureTile);                    
        }

        public RelayCommand QueryFutureLiveTileCommand
        {
            get { return _queryFutureLiveTileCommand ?? (_queryFutureLiveTileCommand = new RelayCommand(QueryFutureLiveTile)); }
        }

        private void QueryFutureLiveTile()
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            var scheduledNotifications = tileUpdater.GetScheduledTileNotifications();

            foreach (var tile in scheduledNotifications)
            {
                Debug.WriteLine(string.Format("Tile Id {0} Delivery Time {1} Expiration Time: {2} ", tile.Id, tile.DeliveryTime, tile.ExpirationTime ));
                tileUpdater.RemoveFromSchedule(tile);       
            }
        }

        public bool ExpireContent
        {
            get { return _expireContent; }
            set
            {
                _expireContent = value;
                OnPropertyChanged("ExpireContent");
            }
        }

        #endregion

        #region Static Tiles

        public RelayCommand UpdateStaticLiveTileCommand
        {
            get { return _updateStaticLiveTileCommand ?? (_updateStaticLiveTileCommand = new RelayCommand(UpdateStaticLiveTile)); }
        }

        private void UpdateStaticLiveTile()
        {
            var applicationTile = TileContentFactory.CreateTileWidePeekImage02(); 
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            // clear the existing tile info
            tileUpdater.Clear();

            applicationTile.TextHeading.Text = "Top Scores";
            applicationTile.TextBody1.Text = "Player 1 - 100";
            applicationTile.TextBody2.Text = "Player 2 - 92";
            applicationTile.TextBody3.Text = "Player 3 - 90";
            applicationTile.TextBody4.Text = "Player 4 - 85";

            applicationTile.RequireSquareContent = false;
            applicationTile.Image.Src = "/Images/LiveTileImage_310x150.png";

            var tileNotification = applicationTile.CreateNotification();
            tileUpdater.Update(tileNotification);
        }

    #endregion

    }
}
