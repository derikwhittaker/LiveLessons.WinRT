using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.GridView.DataModel;
using Metro.LL.Common;

namespace LL.GridView.ViewModels
{
    public class PlainGridViewModel : BaseViewModel
    {
        private ObservableCollection<Item> _items;

        public PlainGridViewModel()
        {
            PageTitle = "Plain Grid View";

            Items = new ObservableCollection<Item>(new List<Item>
                                                       {
                                                           new Item{Title = "Item 1", Description = "Item 1 Description", ImageName = @"../Images/BlueSmallSquare.png"},
                                                           new Item{Title = "Item 2", Description = "Item 2 Description", ImageName = @"../Images/BrownSmallSquare.png"},
                                                           new Item{Title = "Item 3", Description = "Item 3 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                           new Item{Title = "Item 4", Description = "Item 4 Description", ImageName = @"../Images/BrownSmallSquare.png"},
                                                           new Item{Title = "Item 5", Description = "Item 5 Description", ImageName = @"../Images/RedSmallSquare.png"},
                                                           new Item{Title = "Item 6", Description = "Item 6 Description", ImageName = @"../Images/RedSmallSquare.png"},
                                                           new Item{Title = "Item 7", Description = "Item 7 Description", ImageName = @"../Images/BlueSmallSquare.png"},
                                                           new Item{Title = "Item 8", Description = "Item 8 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                       });
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
    }
}