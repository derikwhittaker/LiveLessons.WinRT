using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;

namespace LL.ApplicationBar.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private bool _showAppBar;
        private RelayCommand _showAppBarCommand;
        private RelayCommand _handleNextClickCommand;
        private bool _showAppBarButton;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Appliction Bars";
        }

        public RelayCommand HandleNextClickCommand
        {
            get { return _handleNextClickCommand ?? (_handleNextClickCommand = new RelayCommand(() => { ShowAppBarButton = !ShowAppBarButton; })); }
        }

        public bool ShowAppBarButton
        {
            get { return _showAppBarButton; }
            set { _showAppBarButton = value; OnPropertyChanged("ShowAppBarButton"); }
        }

        public RelayCommand ShowAppBarCommand
        {
            get { return _showAppBarCommand ?? (_showAppBarCommand = new RelayCommand(() => { ShowAppBar = !ShowAppBar; })); }
        }

        public bool ShowAppBar
        {
            get { return _showAppBar; }
            set { _showAppBar = value; OnPropertyChanged("ShowAppBar"); }
        }
    }
}
