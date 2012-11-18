using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metro.LL.DisplayingDataWithBinding.ViewModels;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Metro.LL.DisplayingDataWithBinding
{
    partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            var vm = new MainPageViewModel();
            vm.ImagesCollectionViewSourceCallback = (data) =>
            {
                CollectionViewSource.Source = data;
            };

            vm.InitData();
            DataContext = vm;
        }
    }
}
