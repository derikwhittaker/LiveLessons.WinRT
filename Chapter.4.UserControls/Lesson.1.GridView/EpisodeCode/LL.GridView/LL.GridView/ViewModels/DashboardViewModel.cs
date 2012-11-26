using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.GridView.DataModel;
using LL.GridView.Views;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;

namespace LL.GridView.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<DashboardItem> _items;
        private DashboardItem _selectedDashboardItem;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use the Grid View";

            Items= new ObservableCollection<DashboardItem>(new List<DashboardItem>
                                                               {
                                                                   new DashboardItem{ PageType = typeof(PlainGridViewPage), Name = "Plain Grid View", Color = "AliceBlue"},
                                                                   new DashboardItem{ PageType = typeof(GroupedGridViewPage),Name = "Grouped Grid View", Color = "AntiqueWhite"},
                                                                   new DashboardItem{ PageType = typeof(DesignTimeDataGridViewPage),Name = "Using Design Time Data", Color = "Azure"},
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
