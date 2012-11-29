using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.ListView.DataModel;
using LL.ListView.Views;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;

namespace LL.ListView.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<DashboardItem> _items;
        private DashboardItem _selectedDashboardItem;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use the List View";
            Items = new ObservableCollection<DashboardItem>(new List<DashboardItem>
                                                               {
                                                                   new DashboardItem{ PageType = typeof(BasicListViewPage), Name = "Basic List View", Color = "AliceBlue"},
                                                                   new DashboardItem{ PageType = typeof(StyledListViewPage), Name = "Styled List View", Color = "AntiqueWhite"},
                                                                   new DashboardItem{ PageType = typeof(BasicListViewPage), Name = "Something...", Color = "Azure"},
                                                               });
        }

        public ObservableCollection<DashboardItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public DashboardItem SelectedDashboardItem
        {
            get { return _selectedDashboardItem; }
            set
            {
                _selectedDashboardItem = value;

                OnPropertyChanged("SelectedDashboardItem");

                NavigateToSelectedPage(value);
            }
        }

        private void NavigateToSelectedPage(DashboardItem dashboardItem)
        {
            var currentFrame = Windows.UI.Xaml.Window.Current;
            var frame = currentFrame.Content as Frame;

            var args = new Dictionary<string, string> { };

            frame.Navigate(dashboardItem.PageType, args);
        }
    }
}
