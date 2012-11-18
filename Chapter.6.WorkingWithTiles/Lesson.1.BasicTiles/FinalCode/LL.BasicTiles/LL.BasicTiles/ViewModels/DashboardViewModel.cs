using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LL.BasicTiles.DataModel;
using LL.BasicTiles.DataModel;
using Metro.LL.Common;
using Metro.LL.Common.Models;

namespace LL.BasicTiles.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly Repository _repository;

        public DashboardViewModel() : this(new Repository())
        {
        }

        public DashboardViewModel( Repository repository )
        {
            _repository = repository;

            PageTitle = "Basic Tiles";
            PopulateData(_repository.All());
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

        protected void PopulateData(IList<SimpleItem> items )
        {
            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(new DashboardItemModel(item));
            }

            OnPropertyChanged("Items");
        }

        public async void PerformSearchAsync(string queryText)
        {
            var results = await _repository.SearchAsync(queryText);

            PopulateData(results);
        }

        public async Task<IList<string>> SearchSuggestiongsAsync(string queryText)
        {
            var results = await _repository.SearchSuggestionsAsync(queryText);

            return results;
        }
    }
}
