using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using LL.Navigation.Views;
using Metro.LL.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LL.Navigation.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        
        public DashboardViewModel()
        {
            PageTitle = "Learning to Navigate";
        }
    }
}
