using System.Collections.ObjectModel;
using LL.SearchContracts.DataModel;
using Metro.LL.Common;

namespace LL.SearchContracts.ViewModels
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

        private SearchItemModel _selectedItem;
        public SearchItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                PageTitle = value.Name;

                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<SearchItemModel> _items = new ObservableCollection<SearchItemModel>();
        public ObservableCollection<SearchItemModel> Items
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
                Items.Add(new SearchItemModel(item));
            }

        }
    }
}
