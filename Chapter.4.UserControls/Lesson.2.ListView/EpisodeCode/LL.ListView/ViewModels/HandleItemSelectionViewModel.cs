using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.ListView.DataModel;
using Metro.LL.Common;

namespace LL.ListView.ViewModels
{
    public class HandleItemSelectionViewModel : BaseViewModel
    {
        private ObservableCollection<Item> _items;
        private Item _selectedItem;
        private Item _selectedItem1;
        private string _selectedItemText;

        public HandleItemSelectionViewModel()
        {
            PageTitle = "List View Item Selection";

            var temp = new List<Item>
                           {
                               new Item{Title = "Item 1", Description = "Item 1 Description", ImageName = @"../Images/BlueSmallSquare.png", ItemType = 1},
                               new Item{Title = "Item 2", Description = "Item 2 Description", ImageName = @"../Images/BrownSmallSquare.png", ItemType = 2},
                               new Item{Title = "Item 3", Description = "Item 3 Description", ImageName = @"../Images/GreenSmallSquare.png", ItemType = 2},
                               new Item{Title = "Item 4", Description = "Item 4 Description", ImageName = @"../Images/BrownSmallSquare.png", ItemType = 1},                                               
                           };

            Items = new ObservableCollection<Item>(temp);
        }

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;

                OnPropertyChanged("Items");
            }
        }

        public Item SelectedItem
        {
            get { return _selectedItem1; }
            set
            {
                _selectedItem1 = value;

                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("SelectedItemText");
            }
        }

        public string SelectedItemText
        {
            get
            {
                if (SelectedItem == null)
                {
                    return "";
                }

                return string.Format("Selected Item {0}", SelectedItem.Title);
            }
        }
    }
}