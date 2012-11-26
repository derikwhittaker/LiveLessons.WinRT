using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.GridView.DataModel;
using Metro.LL.Common;

namespace LL.GridView.ViewModels
{
    public class GroupedGridViewModel : BaseViewModel
    {
        private ObservableCollection<ItemGroup> _groups;

        public GroupedGridViewModel()
        {
            PageTitle = "Grouped Items Grid View";

            var groups = new List<ItemGroup>();

            groups.Add(new ItemGroup
                           {
                               Header = "Group 1",
                               Items = new List<Item>
                                           {
                                                new Item{Title = "Item 1", Description = "Item 1 Description", ImageName = @"../Images/BlueSmallSquare.png"},
                                                new Item{Title = "Item 2", Description = "Item 2 Description", ImageName = @"../Images/BrownSmallSquare.png"},
                                                new Item{Title = "Item 3", Description = "Item 3 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                new Item{Title = "Item 4", Description = "Item 4 Description", ImageName = @"../Images/BrownSmallSquare.png"},                                               
                                           }
                           });

            groups.Add(new ItemGroup
                            {
                                Header = "Group 2",
                                Items = new List<Item>
                                            {
                                                new Item{Title = "Item 1", Description = "Item Description", ImageName = @"../Images/BlueSmallSquare.png"},
                                                new Item{Title = "Item 2", Description = "Item Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                new Item{Title = "Item 3", Description = "Item Description", ImageName = @"../Images/BrownSmallSquare.png"},                                                                
                                                new Item{Title = "Item 4", Description = "Item Description", ImageName = @"../Images/RedSmallSquare.png"},                                               
                                            }
                            });

            groups.Add(new ItemGroup
                            {
                                Header = "Group 3",
                                Items = new List<Item>
                                            {
                                                new Item{Title = "Item 1", Description = "Item 1 Description", ImageName = @"../Images/BrownSmallSquare.png"},
                                                new Item{Title = "Item 2", Description = "Item 2 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                new Item{Title = "Item 3", Description = "Item 3 Description", ImageName = @"../Images/GreenSmallSquare.png"},
                                                new Item{Title = "Item 4", Description = "Item 4 Description", ImageName = @"../Images/BlueSmallSquare.png"},                                               
                                            }
                            });

            Groups = new ObservableCollection<ItemGroup>(groups);
        }

        public ObservableCollection<ItemGroup> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;

                OnPropertyChanged("Groups");
            }
        }
    }
}