using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.FlipView.DataModel;
using LL.FlipView.Views;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;

namespace LL.FlipView.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            PageTitle = "Learning to use the Flip View";
            var temp = new List<Item>
                                           {
                                                new Item{Title = "Aston Martin", ImageName = @"../Images/AstonMartin_V12Zagato.png"},
                                                new Item{Title = "Audi A8", ImageName = @"../Images/Audi_R8.png"},
                                                new Item{Title = "Bugatti Veyron", ImageName = @"../Images/Bugatti_Veyron.png"},
                                                new Item{Title = "Corvette Z06", ImageName = @"../Images/Corvette_Z06.png"},
                                                new Item{Title = "Ferrari F12 Berlinetta", ImageName = @"../Images/Ferrari_F12berlinetta.png"},
                                                new Item{Title = "Jaguar XJ", ImageName = @"../Images/Jaguar_xj.png"},
                                                new Item{Title = "Lamborghini Aventador", ImageName = @"../Images/Lamborghini_Aventador.png"},
                                                new Item{Title = "Lotus Exige S", ImageName = @"../Images/Lotus_ExigeS.png"},
                                                new Item{Title = "McLaren", ImageName = @"../Images/McLaren_MP4.png"},
                                                new Item{Title = "Porsche", ImageName = @"../Images/Porsche_Panamera.png"},

                                           };

            Items = new ObservableCollection<Item>(temp);
        }

        private ObservableCollection<Item> _items;
        private Item _selectedItem;

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
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                OnPropertyChanged("SelectedItem");
            }
        }
    }
}
