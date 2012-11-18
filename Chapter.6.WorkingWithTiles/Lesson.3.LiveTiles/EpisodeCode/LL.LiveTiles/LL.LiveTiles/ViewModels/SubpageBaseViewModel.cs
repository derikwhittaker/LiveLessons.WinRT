using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;

namespace LL.LiveTiles.ViewModels
{
    public abstract class SubpageBaseViewModel : BaseViewModel
    {
        public string PinId { get; set; }

        protected abstract void CreateTile();

        private RelayCommand _createTileCommand;
        public RelayCommand CreateTileCommand
        {
            get { return _createTileCommand ?? (_createTileCommand = new RelayCommand(CreateTile)); }
        }

        protected void ClearTile()
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            tileUpdater.Clear();
        }
        
        private RelayCommand _clearTileCommand;
        public RelayCommand ClearTileCommand
        {
            get { return _clearTileCommand ?? (_clearTileCommand = new RelayCommand(ClearTile)); }
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set { _header = value; OnPropertyChanged("Header"); }
        }

        private string _line1;
        public string Line1
        {
            get { return _line1; }
            set { _line1 = value; OnPropertyChanged("Line1"); }
        }

        private string _line2;
        public string Line2
        {
            get { return _line2; }
            set { _line2 = value; OnPropertyChanged("Line2"); }
        }

        private string _line3;
        public string Line3
        {
            get { return _line3; }
            set { _line3 = value; OnPropertyChanged("Line3"); }
        }

        private string _line4;
        public string Line4
        {
            get { return _line4; }
            set { _line4 = value; OnPropertyChanged("Line4"); }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged("ImagePath"); }
        }

        private string _smallImagePath;
        public string SmallImagePath
        {
            get { return _smallImagePath; }
            set { _smallImagePath = value; OnPropertyChanged("SmallImagePath"); }
        }

        private string _smallImageCollection1Path;
        public string SmallImageCollection1Path
        {
            get { return _smallImageCollection1Path; }
            set { _smallImageCollection1Path = value; OnPropertyChanged("SmallImageCollection1Path"); }
        }

        private string _smallImageCollection2Path;
        public string SmallImageCollection2Path
        {
            get { return _smallImageCollection2Path; }
            set { _smallImageCollection2Path = value; OnPropertyChanged("SmallImageCollection2Path"); }
        }

        private string _smallImageCollection3Path;
        public string SmallImageCollection3Path
        {
            get { return _smallImageCollection3Path; }
            set { _smallImageCollection3Path = value; OnPropertyChanged("SmallImageCollection3Path"); }
        }

        private string _smallImageCollection4Path;
        public string SmallImageCollection4Path
        {
            get { return _smallImageCollection4Path; }
            set { _smallImageCollection4Path = value; OnPropertyChanged("SmallImageCollection4Path"); }
        }
    }
}
