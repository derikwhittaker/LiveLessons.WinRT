using System;
using Metro.LL.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LL.Navigation.ViewModels
{
    public class SimpleNavigationViewModel :BaseViewModel
    {
        private readonly Frame _frame;

        public SimpleNavigationViewModel(Frame frame)
        {
            _frame = frame;
            PageTitle = "Simple Navigation";

        }
    }
}