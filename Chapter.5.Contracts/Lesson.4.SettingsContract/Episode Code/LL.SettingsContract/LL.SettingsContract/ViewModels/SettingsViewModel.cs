namespace LL.SettingsContract.ViewModels
{
    public class SettingsViewModel : Metro.LL.Common.BaseViewModel
    {
        private bool _enableApplicationBar = false;
        public bool EnableApplicationBar
        {
            get { return _enableApplicationBar; }
            set { _enableApplicationBar = value; OnPropertyChanged("EnableApplicationBar"); }
        }
    }


}

