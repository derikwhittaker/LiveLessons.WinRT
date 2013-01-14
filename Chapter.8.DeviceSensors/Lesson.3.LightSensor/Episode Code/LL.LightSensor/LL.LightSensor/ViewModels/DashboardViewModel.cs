using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Sensor = Windows.Devices.Sensors;

namespace LL.LightSensor.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private bool _isEventing;
        private bool _isPolling;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;
        private double _brightness = .1;
        private string _luxLums;
        private string _currentReadingStyle;


        public DashboardViewModel()
        {
            PageTitle = "Learning to use Light Sensor";
            
        }

        public RelayCommand TogglePollingCommand
        {
            get { return _togglePollingCommand ?? (_togglePollingCommand = new RelayCommand(TogglePolling)); }
        }

        private void TogglePolling()
        {
            IsPolling = !IsPolling;
            IsEventing = false;
        }

        public RelayCommand ToggleEventingCommand
        {
            get { return _toggleEventingCommand ?? (_toggleEventingCommand = new RelayCommand(ToggleEventing)); }
        }

        private void ToggleEventing()
        {
            IsEventing = !IsEventing;
            IsPolling = false;
        }

        public bool IsEventing
        {
            get { return _isEventing; }
            set { _isEventing = value; OnPropertyChanged("IsEventing"); }
        }

        public bool IsPolling
        {
            get { return _isPolling; }
            set { _isPolling = value; OnPropertyChanged("IsPolling"); }
        }

        public string CurrentReadingStyle
        {
            get { return _currentReadingStyle; }
            set { _currentReadingStyle = value; OnPropertyChanged("CurrentReadingStyle"); }
        }

        public double Brightness
        {
            get { return _brightness; }
            set { _brightness = value; OnPropertyChanged("Brightness"); }
        }

        public string LuxLums
        {
            get { return _luxLums; }
            set { _luxLums = value; OnPropertyChanged("LuxLums"); }
        }
    }
}
