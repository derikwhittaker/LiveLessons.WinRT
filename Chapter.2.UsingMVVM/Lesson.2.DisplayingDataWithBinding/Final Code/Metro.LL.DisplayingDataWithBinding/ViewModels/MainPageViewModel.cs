using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Metro.LL.DisplayingDataWithBinding.Models;
using Microsoft.Foundations.Collections;
using Windows.Foundation.Collections;

namespace Metro.LL.DisplayingDataWithBinding.ViewModels
{
    public class MainPageViewModel : Metro.LL.Common.BaseViewModel
    {

        public MainPageViewModel()
        {
            PageTitle = "Using Binding in MVVM";

            Images.Add(new ImageModel { DisplayValue = "Planet 01", ImageUri = "PlanetImages/Planet01.jpg", FileName = "Planet01.jpg", UploadedDate = DateTime.Now.AddDays(-1), IsInUse = true });
            Images.Add(new ImageModel { DisplayValue = "Planet 02", ImageUri = "PlanetImages/Planet02.jpg", FileName = "Planet02.jpg", UploadedDate = DateTime.Now.AddDays(-2), IsInUse = false });
            Images.Add(new ImageModel { DisplayValue = "Planet 03", ImageUri = "PlanetImages/Planet03.jpg", FileName = "Planet03.jpg", UploadedDate = DateTime.Now.AddDays(-3), IsInUse = true });
            Images.Add(new ImageModel { DisplayValue = "Planet 04", ImageUri = "PlanetImages/Planet04.jpg", FileName = "Planet04.jpg", UploadedDate = DateTime.Now.AddDays(-4), IsInUse = true });
            Images.Add(new ImageModel { DisplayValue = "Planet 05", ImageUri = "PlanetImages/Planet05.jpg", FileName = "Planet05.jpg", UploadedDate = DateTime.Now.AddDays(-2), IsInUse = false });
            Images.Add(new ImageModel { DisplayValue = "Planet 06", ImageUri = "PlanetImages/Planet06.jpg", FileName = "Planet06.jpg", UploadedDate = DateTime.Now.AddDays(-5), IsInUse = true });
            Images.Add(new ImageModel { DisplayValue = "Planet 07", ImageUri = "PlanetImages/Planet07.jpg", FileName = "Planet07.jpg", UploadedDate = DateTime.Now.AddDays(-1), IsInUse = true });
            Images.Add(new ImageModel { DisplayValue = "Planet 08", ImageUri = "PlanetImages/Planet08.jpg", FileName = "Planet08.jpg", UploadedDate = DateTime.Now.AddDays(00), IsInUse = false });
            Images.Add(new ImageModel { DisplayValue = "Planet 01", ImageUri = "PlanetImages/Planet01.jpg", FileName = "Planet01.jpg", UploadedDate = DateTime.Now.AddDays(-2), IsInUse = false });
            Images.Add(new ImageModel { DisplayValue = "Planet 02", ImageUri = "PlanetImages/Planet02.jpg", FileName = "Planet02.jpg", UploadedDate = DateTime.Now.AddDays(-3), IsInUse = false });
            Images.Add(new ImageModel { DisplayValue = "Planet 03", ImageUri = "PlanetImages/Planet03.jpg", FileName = "Planet03.jpg", UploadedDate = DateTime.Now.AddDays(-5), IsInUse = true });

        }

        public void InitData()
        {
            if (ImagesCollectionViewSourceCallback != null)
            {
                ImagesCollectionViewSourceCallback.Invoke(Images);
            }
        }

        private IList<ImageModel> _images = new List<ImageModel>();
        public IList<ImageModel> Images
        {
            get { return _images; }
            set { _images = value; }
        }
        
        public Action<IEnumerable<ImageModel>> ImagesCollectionViewSourceCallback { get; set; }

        private ImageModel _selectedImageModel;
        public ImageModel SelectedImageModel 
        {
            get { return _selectedImageModel; }
            set
            { 
                _selectedImageModel = value;

                OnPropertyChanged("SelectedImageModel");
            }
            
        }
    }
}
