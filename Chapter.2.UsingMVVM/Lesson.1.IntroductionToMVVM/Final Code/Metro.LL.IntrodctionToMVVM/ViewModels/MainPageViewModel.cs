using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Metro.LL.IntrodctionToMVVM.Models;

namespace Metro.LL.IntrodctionToMVVM.ViewModels
{
    public class MainPageViewModel : Metro.LL.Common.BaseViewModel
    {
        public IList<ImageModel> Images{get;set;}

        public MainPageViewModel()
        {
            PageTitle = "Introduction to MVVM";

            Images = new List<ImageModel>();
            Images.Add(new ImageModel { DisplayValue = "Planet 01", ImageUri = "PlanetImages/Planet01.jpg", FileName = "Planet01.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 02", ImageUri = "PlanetImages/Planet02.jpg", FileName = "Planet02.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 03", ImageUri = "PlanetImages/Planet03.jpg", FileName = "Planet03.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 04", ImageUri = "PlanetImages/Planet04.jpg", FileName = "Planet04.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 05", ImageUri = "PlanetImages/Planet05.jpg", FileName = "Planet05.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 06", ImageUri = "PlanetImages/Planet06.jpg", FileName = "Planet06.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 07", ImageUri = "PlanetImages/Planet07.jpg", FileName = "Planet07.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 08", ImageUri = "PlanetImages/Planet08.jpg", FileName = "Planet08.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 01", ImageUri = "PlanetImages/Planet01.jpg", FileName = "Planet01.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 02", ImageUri = "PlanetImages/Planet02.jpg", FileName = "Planet02.jpg" });
            Images.Add(new ImageModel { DisplayValue = "Planet 03", ImageUri = "PlanetImages/Planet03.jpg", FileName = "Planet03.jpg" });

        }

        public void InitData()
        {
            if (ImagesCollectionViewSourceCallback != null)
            {
                ImagesCollectionViewSourceCallback.Invoke(Images);
            }
        }

        private void ClickMe()
        {
            ClickResults = string.Format("{0} {1} - Active: {2}", FirstName, LastName, IsActive);
        }

        private string _clickResults;
        public string ClickResults
        {
            get { return _clickResults; }
            set { _clickResults = value; OnPropertyChanged("ClickResults"); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged("IsActive"); }
        }

        private RelayCommand _clickMeCommand;
        public RelayCommand ClickMeCommand
        {
            get{ return _clickMeCommand ?? (_clickMeCommand = new RelayCommand(ClickMe)); }
        }

        public Action<IEnumerable<ImageModel>> ImagesCollectionViewSourceCallback { get; set; }
    }
}
