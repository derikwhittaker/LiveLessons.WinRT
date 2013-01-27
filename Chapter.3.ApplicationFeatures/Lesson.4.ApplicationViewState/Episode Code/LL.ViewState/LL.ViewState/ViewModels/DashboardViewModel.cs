using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LL.ViewState.DataModel;
using Metro.LL.Common.Models;

namespace LL.ViewState.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private Repository _repository = new Repository();
        private ObservableCollection<SimpleItem> _items;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use View State";

            Items = new ObservableCollection<SimpleItem>(_repository.All());
        }

        public ObservableCollection<SimpleItem> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
    }
}
