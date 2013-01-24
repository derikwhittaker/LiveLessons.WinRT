using GalaSoft.MvvmLight.Command;
using LL.SettingsContract.Views;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace LL.SettingsContract.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private RelayCommand _enableSettingsCommand;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Settings Contract";
            
        }

        private SettingsViewModel _settings = new SettingsViewModel();
        public SettingsViewModel Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public RelayCommand EnableSettingsCommand
        {
            get { return _enableSettingsCommand ?? (_enableSettingsCommand = new RelayCommand(EnableSettings));  }
        }

        private bool _commandsAreEnabled = false;
        private void EnableSettings()
        {
         
        }

    }
}
