using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using LL.ListView.DataModel;
using Metro.LL.Common;

namespace LL.ListView.ViewModels
{
    public class BasicListViewModel : BaseViewModel
    {
        private ObservableCollection<Item> _items;
        private RelayCommand _addNewItemCommand;

        public BasicListViewModel()
        {
            PageTitle = "Basic List View";

            var temp = new List<Item>
                                           {
                                                new Item{Title = "Item 1", Description = "Item 1 Description", ImageName = @"../Images/BlueSmallSquare.png"},
                                                new Item{Title = "Item 2", Description = "Item 2 Description", ImageName = @"../Images/BrownSmallSquare.png"},
                                                new Item{Title = "Item 3", Description = "Item 3 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                new Item{Title = "Item 4", Description = "Item 4 Description", ImageName = @"../Images/BrownSmallSquare.png"},                                               
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

        public RelayCommand AddNewItemCommand
        {
            get { return _addNewItemCommand ?? ( _addNewItemCommand = new RelayCommand(AddNewItem)); }
        }

        private void AddNewItem()
        {
            var newItem = new Item
                              {
                                  Title = "New Item",
                                  Description = "New Item Desc",
                                  ImageName = @"../Images/BrownSmallSquare.png"
                              };

            Items.Add(newItem);
        }
    }
}