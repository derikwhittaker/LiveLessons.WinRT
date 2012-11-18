using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

using Metro.LL.IntrodctionToMVVM.Models;
using Metro.LL.IntrodctionToMVVM.ViewModels;

namespace Metro.LL.IntrodctionToMVVM
{
    partial class MainPage
    {
        private IList<ImageModel> _images = new List<ImageModel>();
        public IList<ImageModel> Images
        {
            get { return _images; }
            set { _images = value; }
        }

        public MainPage()
        {
            InitializeComponent();

            PageTitle.Text = "Introduction to MVVM";

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

            CollectionViewSource.Source = Images;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var isActive = ActiveCheckBox.IsChecked;

            ClickResults.Text = string.Format("{0} {1} - Active: {2}", firstName, lastName, isActive);

        }

    }
}
