using System.Collections.Generic;
using LL.LiveTiles.DataModel;
using LL.LiveTiles.Views;
using Metro.LL.Common;

namespace LL.LiveTiles.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private IList<LiveTileScenario> _scenarios;
        private LiveTileScenario _selectedScenario;
        
        public DashboardViewModel()
        {
            PageTitle = "Live Tiles";

            Scenarios = new List<LiveTileScenario>
                            {
                                new LiveTileScenario {Id = 1, Name = "Square Block Header"},
                                new LiveTileScenario {Id = 2, Name = "Square Block Image Only"},
                                new LiveTileScenario {Id = 3, Name = "Square Block w/ Peek"},
                                new LiveTileScenario {Id = 4, Name = "Wide Image Only"},
                                new LiveTileScenario {Id = 5, Name = "Wide Text Only"},
                                new LiveTileScenario {Id = 6, Name = "Wide Image Collection"},
                                new LiveTileScenario {Id = 7, Name = "Wide Image Peek"},
                                new LiveTileScenario {Id = 8, Name = "Wide w/ Small Image"},
                            };

            HideAll();
        }

        public LiveTileScenario SelectedScenario
        {
            get { return _selectedScenario; }
            set
            {
                _selectedScenario = value;

                OnPropertyChanged("SelectedScenario");

                SetupScenario(value);
            }
        }

        private void SetupScenario(LiveTileScenario selectedScenario)
        {
            HideAll();

            switch (selectedScenario.Id)
            {
                case 1:                    
                    ShowSquareBlockHeader = true;                    
                    break;

                case 2:
                    ShowSquareBlockImageOnly = true;                    
                    break;

                case 3:
                    ShowSquareBlockWithPeek = true;                    
                    break;

                case 4:
                    ShowWideImageOnly = true;                    
                    break;

                case 5:
                    ShowWideTextOnly = true;
                    break;

                case 6:
                    ShowWideImageCollection = true;
                    break;

                case 7:
                    ShowWideImagePeek = true;
                    break;

                case 8:
                    ShowWideImageWithSmallImage = true;
                    break;
            }
        }

        private void HideAll()
        {
            ShowSquareBlockHeader = false;
            ShowSquareBlockImageOnly = false;
            ShowSquareBlockWithPeek = false;
            ShowWideImageOnly = false;
            ShowWideTextOnly = false;
            ShowWideImageCollection = false;
            ShowWideImagePeek = false;
            ShowWideImageWithSmallImage = false;
        }

        public IList<LiveTileScenario> Scenarios
        {
            get { return _scenarios; }
            set
            {
                _scenarios = value;

                OnPropertyChanged("Scenarios");
            }
        }

        private bool _showSquareBlockHeader;
        public bool ShowSquareBlockHeader
        {
            get { return _showSquareBlockHeader; }
            set { _showSquareBlockHeader = value; OnPropertyChanged("ShowSquareBlockHeader"); }
        }

        private bool _showSquareBlockImageOnly;
        public bool ShowSquareBlockImageOnly
        {
            get { return _showSquareBlockImageOnly; }
            set { _showSquareBlockImageOnly = value; OnPropertyChanged("ShowSquareBlockImageOnly"); }
        }

        private bool _showSquareBlockWithPeek;
        public bool ShowSquareBlockWithPeek
        {
            get { return _showSquareBlockWithPeek; }
            set { _showSquareBlockWithPeek = value; OnPropertyChanged("ShowSquareBlockWithPeek"); }
        }
        
        private bool _showWideImageOnly;
        public bool ShowWideImageOnly
        {
            get { return _showWideImageOnly; }
            set { _showWideImageOnly = value; OnPropertyChanged("ShowWideImageOnly"); }
        }

        private bool _showWideTextOnly;
        public bool ShowWideTextOnly
        {
            get { return _showWideTextOnly; }
            set { _showWideTextOnly = value; OnPropertyChanged("ShowWideTextOnly"); }
        }
        
        private bool _showWideImageCollection;
        public bool ShowWideImageCollection
        {
            get { return _showWideImageCollection; }
            set { _showWideImageCollection = value; OnPropertyChanged("ShowWideImageCollection"); }
        }

        private bool _showWideImagePeek;
        public bool ShowWideImagePeek
        {
            get { return _showWideImagePeek; }
            set { _showWideImagePeek = value; OnPropertyChanged("ShowWideImagePeek"); }
        }

        private bool _showWideImageWithSmallImage;
        public bool ShowWideImageWithSmallImage
        {
            get { return _showWideImageWithSmallImage; }
            set { _showWideImageWithSmallImage = value; OnPropertyChanged("ShowWideImageWithSmallImage"); }
        }
    }
}
