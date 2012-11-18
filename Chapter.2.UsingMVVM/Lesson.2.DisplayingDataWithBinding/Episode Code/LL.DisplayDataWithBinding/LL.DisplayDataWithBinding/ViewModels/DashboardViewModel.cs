using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using LL.IntroToMVVM.DataModel;

namespace LL.DisplayDataWithBinding.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {

        #region List Binding

        public DashboardViewModel()
        {
            var temp = new List<ImageModel>
                           {
                               new ImageModel {DisplayValue = "Planet 1", ImageUri = "../Images/Planet01.jpg"},
                               new ImageModel {DisplayValue = "Planet 2", ImageUri = "../Images/Planet02.jpg"},
                               new ImageModel {DisplayValue = "Planet 3", ImageUri = "../Images/Planet03.jpg"},
                               new ImageModel {DisplayValue = "Planet 4", ImageUri = "../Images/Planet04.jpg"},
                           };

            Items = new ObservableCollection<ImageModel>(temp);
        }

        private ObservableCollection<ImageModel> _items;
        private ImageModel _selectedItem;

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
                OnPropertyChanged("SelectedItemText");
            }
        }
        public string SelectedItemText
        {
            get
            {
                if (SelectedItem != null)
                {
                    return SelectedItem.DisplayValue;
                }

                return "";
            }
        }

        #endregion

        #region Text Binding

        private string _textBoxValueByElementName = "Text Box Value w/ Element";
        private string _textBoxValueByPath = "Text Box Value w/ Path";
        private string _textBoxValue = "Text Box Value";
        private ChildViewModel _child = new ChildViewModel();

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set { _textBoxValue = value; OnPropertyChanged("TextBoxValue"); }
        }

        public string TextBoxValueByPath
        {
            get { return _textBoxValueByPath; }
            set { _textBoxValueByPath = value; OnPropertyChanged("TextBoxValueByPath"); }
        }

        public string TextBoxValueByElementName
        {
            get { return _textBoxValueByElementName; }
            set { _textBoxValueByElementName = value; OnPropertyChanged("TextBoxValueByElementName"); }
        }

        public ChildViewModel Child
        {
            get { return _child; }
            set { _child = value; }
        }
        #endregion

        #region Converter Binding
        private string _textWithStyle = "ConverterOffItemTextStyle";
        private bool _canSeeText;
        private RelayCommand _toggleTextVisibility;
        private RelayCommand _toggleTextStyle;

        public RelayCommand ToggleTextVisibility
        {
            get { return _toggleTextVisibility ?? (_toggleTextVisibility = new RelayCommand(() => { CanSeeText = !CanSeeText; })); }
        }

        public bool CanSeeText
        {
            get { return _canSeeText; }
            set { _canSeeText = value; OnPropertyChanged("CanSeeText"); }
        }

        public RelayCommand ToggleTextStyle
        {
            get
            {
                return _toggleTextStyle ?? (_toggleTextStyle = new RelayCommand(() =>
                {
                    if (TextWithStyle == "ConverterOnItemTextStyle")
                    {
                        TextWithStyle = "ConverterOffItemTextStyle";
                    }
                    else
                    {
                        TextWithStyle = "ConverterOnItemTextStyle";
                    }
                }));
            }
        }

        public string TextWithStyle
        {
            get { return _textWithStyle; }
            set { _textWithStyle = value; OnPropertyChanged("TextWithStyle"); }
        }

        #endregion
    }

    public class ChildViewModel : Metro.LL.Common.BaseViewModel
    {
        private string _childValue = "Child Value";
        public string ChildValue
        {
            get { return _childValue; }
            set { _childValue = value; OnPropertyChanged("ChildValue"); }
        }
    }
}
