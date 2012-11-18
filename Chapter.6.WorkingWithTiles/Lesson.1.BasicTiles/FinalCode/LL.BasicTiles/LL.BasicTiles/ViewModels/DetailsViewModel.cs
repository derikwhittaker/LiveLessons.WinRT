using System.Collections.ObjectModel;
using LL.BasicTiles.DataModel;
using LL.BasicTiles.DataModel;
using Metro.LL.Common;

namespace LL.BasicTiles.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly Repository _repository;

        public DetailsViewModel() : this(new Repository())
        {
        }

        public DetailsViewModel(Repository repository)
        {
            _repository = repository;
            _repository = repository;

            PageTitle = "Details";
            CreateSampleData();
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

        protected void CreateSampleData()
        {
            var items = _repository.All();

            foreach (var item in items)
            {
                Items.Add(new DashboardItemModel(item));
            }

        }
    }
}
