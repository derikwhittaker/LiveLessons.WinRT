using System.Collections.ObjectModel;
using System.Linq;
using LL.SearchContracts.DataModel;
using Metro.LL.Common;

namespace LL.SearchContracts.ViewModels
{
    public class SearchResultsViewModel : BaseViewModel
    {
        private readonly Repository _repository;

        public SearchResultsViewModel() : this(new Repository())
        {
            
        }

        public SearchResultsViewModel( Repository repository )
        {
            _repository = repository;
        }

        public async void PerformSearchAsync(string searchString )
        {
            SearchString = searchString;
            PageTitle = string.Format("Search: {0}", searchString);
            Items.Clear();

            // do search here
            var searchResults = await _repository.SearchAsync(searchString);
            if ( !searchResults.Any() ){return;}

            foreach (var searchResult in searchResults)
            {
                Items.Add(new SearchItemModel(searchResult));
            }

            SelectedItem = Items.First();
            OnPropertyChanged("Items");
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

        public string SearchString { get; set; }
    }
}
