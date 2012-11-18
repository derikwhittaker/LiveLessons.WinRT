using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using LL.IntroToMVVM.DataModel;

namespace LL.IntroToMVVM.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private ObservableCollection<ImageModel> _items;
        private string _firstName;
        private string _lastName;
        private bool _selected;
        private ImageModel _selectedItem;
        private RelayCommand _buttonClickedCommand;
        private string _clickResults;

        public DashboardViewModel()
        {
            PageTitle = "Introduction to MVVM (Bound)";

            FirstName = "Test";
            LastName = "User";

            var temp = new List<ImageModel>
                           {
                               new ImageModel {DisplayValue = "Planet 1", ImageUri = "../Images/Planet01.jpg"},
                               new ImageModel {DisplayValue = "Planet 2", ImageUri = "../Images/Planet02.jpg"},
                               new ImageModel {DisplayValue = "Planet 3", ImageUri = "../Images/Planet03.jpg"},
                               new ImageModel {DisplayValue = "Planet 4", ImageUri = "../Images/Planet04.jpg"},
                               new ImageModel {DisplayValue = "Planet 5", ImageUri = "../Images/Planet05.jpg"},
                               new ImageModel {DisplayValue = "Planet 6", ImageUri = "../Images/Planet06.jpg"},
                               new ImageModel {DisplayValue = "Planet 7", ImageUri = "../Images/Planet07.jpg"},
                               new ImageModel {DisplayValue = "Planet 8", ImageUri = "../Images/Planet08.jpg"},
                           };

            Items = new ObservableCollection<ImageModel>(temp);
        }

        public RelayCommand ButtonClickedCommand
        {
            get { return _buttonClickedCommand ?? (_buttonClickedCommand = new RelayCommand(HandleClick)); }
        }

        private void HandleClick()
        {
            var selectedValue = "";
            if ( SelectedItem != null )
            {
                selectedValue = SelectedItem.DisplayValue;
            }

            var firstName = FirstName;
            var lastName = LastName;
            var isActive = Selected;

            ClickResults = string.Format("First: {0} Last: {1} Active: {2} Selected: {3}", firstName, lastName, isActive, selectedValue);
        }

        public string ClickResults
        {
            get { return _clickResults; }
            set
            {
                _clickResults = value;
                OnPropertyChanged("ClickResults");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public ObservableCollection<ImageModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public ImageModel SelectedItem
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
