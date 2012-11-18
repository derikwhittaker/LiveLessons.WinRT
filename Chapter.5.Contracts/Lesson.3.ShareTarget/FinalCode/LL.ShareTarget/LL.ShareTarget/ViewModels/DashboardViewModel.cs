using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.ShareTarget.DataModel;
using Metro.LL.Common;
using Metro.LL.Common.Models;

namespace LL.ShareTarget.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly Repository _repository;
        private ObservableCollection<SearchItemModel> _items = new ObservableCollection<SearchItemModel>();
        private SearchItemModel _selectedItem;

        public DashboardViewModel() : this(new Repository())
        {
        }

        public DashboardViewModel( Repository repository )
        {
            _repository = repository;

            PageTitle = "Share Target";
            PopulateData(_repository.All());
        }

        public SearchItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                OnPropertyChanged("SelectedItem");
            }
        }
        
        public ObservableCollection<SearchItemModel> Items
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
                Items.Add(new SearchItemModel(item));
            }

            OnPropertyChanged("Items");
        }


    }
}
