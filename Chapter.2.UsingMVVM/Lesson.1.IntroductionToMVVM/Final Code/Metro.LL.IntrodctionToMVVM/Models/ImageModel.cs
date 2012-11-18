using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro.LL.Common;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Metro.LL.IntrodctionToMVVM.Models
{
    public class ImageModel : BaseViewModel
    {
        private async void LoadSourceAsync(string imageUrl)
        {
            var baseUri = new Uri("ms-resource://Metro.LL.IntrodctionToMVVM/Files/MainPage.xaml");
            var uri = new Uri(baseUri, imageUrl);


            try
            {
                Image = new BitmapImage(uri);
                                                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public string DisplayValue { get; set; }

        public string FileName { get; set; }

        private string _imageUrl;
        public string ImageUri
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                LoadSourceAsync(value);
            }
        }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged("Image"); }
        }

    }
}
