using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using LL.SecondaryTiles.DataModel;
using LL.SecondaryTiles.DataModel;
using LL.SecondaryTiles.Managers;
using Metro.LL.Common;

namespace LL.SecondaryTiles.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public const string TileIdPattern = "DetailsPage.{0}.{1}";
        private readonly Repository _repository;
        private IPinManager _pinManager = new PinManager();

        public DetailsViewModel() : this(new Repository())
        {
        }

        public DetailsViewModel(Repository repository)
        {
            _repository = repository;
            _repository = repository;

            PageTitle = "Details";
            CreateSampleData();

            OnPropertyChanged("IsCurrentCarPinned");
        }

        public void SetSelectedItem(int index )
        {
            var item = Items[index];
            SelectedItem = item;
        }

        private DashboardItemModel _selectedItem;
        public DashboardItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                PageTitle = value.Name;

                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("IsCurrentCarPinned");
            }
        }

        private ObservableCollection<DashboardItemModel> _items = new ObservableCollection<DashboardItemModel>();
        public ObservableCollection<DashboardItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private RelayCommand _pinCurrentPageCommand;
        public RelayCommand PinCurrentPageCommand
        {
            get { return _pinCurrentPageCommand ?? (_pinCurrentPageCommand = new RelayCommand(PinCurrentPage)); }
        }

        private async void PinCurrentPage()
        {
            var pinId = buildPinId();

            if (!_pinManager.IsPinned(pinId))
            {
                var shortName = string.Format("Car: {0}", SelectedItem.Name);
                var description = SelectedItem.ShortDescription;
                var tileActivationArgs = string.Format("DetailsPage={0}|{1}", SelectedItem.Id, SelectedItem.Name).Replace(" ", "");
                var tileLogoPath = "SecondaryTiles_150x150.png";
                var smallTileLogoPath = "Assets/SmallLogo.png";

                await _pinManager.Pin(shortName, description, pinId, tileActivationArgs, tileLogoPath, smallTileLogoPath);

                OnPropertyChanged("IsCurrentCarPinned");
            }
        }
        
        private RelayCommand _unpinCurrentPageCommand;
        public RelayCommand UnPinCurrentPageCommand
        {
            get { return _unpinCurrentPageCommand ?? (_unpinCurrentPageCommand = new RelayCommand(UnpinCurrentPage)); }
        }

        private async void UnpinCurrentPage()
        {
            var pinId = buildPinId();

            if (_pinManager.IsPinned(pinId))
            {
                await _pinManager.UnPin(pinId);

                OnPropertyChanged("IsCurrentCarPinned");
            }
        }

        private string buildPinId()
        {
            return string.Format(TileIdPattern, SelectedItem.Id, SelectedItem.Name).Replace(" ", "");
        }

        protected void CreateSampleData()
        {
            var items = _repository.All();

            foreach (var item in items)
            {
                Items.Add(new DashboardItemModel(item));
            }

        }

        public bool IsCurrentCarPinned
        {
            get
            {
                var pinId = buildPinId();

                var result = _pinManager.IsPinned(pinId);

                return result;
            }
        }
    }
}
