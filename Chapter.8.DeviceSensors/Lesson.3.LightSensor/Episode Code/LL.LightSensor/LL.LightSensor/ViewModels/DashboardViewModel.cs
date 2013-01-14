using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Sensor = Windows.Devices.Sensors;

namespace LL.LightSensor.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private Sensor.LightSensor _lightSensor;

        private bool _isEventing;
        private bool _isPolling;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;
        private double _brightness = .1;
        private string _luxLums;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Light Sensor";
            
            SetupLightSensor();
        }

        private void SetupLightSensor()
        {
            _lightSensor = Sensor.LightSensor.GetDefault();

            if (_lightSensor == null)
            {
                LuxLums = "Your current device does not suppor the light sensor";
            }
        }

        private void SetupEventing(bool enableEventing)
        {
            if (enableEventing)
            {
                _lightSensor.ReadingChanged += LightSensorOnReadingChanged;
            }
            else
            {
                _lightSensor.ReadingChanged -= LightSensorOnReadingChanged;
            }
        }

        private void LightSensorOnReadingChanged(Sensor.LightSensor sender, Sensor.LightSensorReadingChangedEventArgs args)
        {
            var lightSensorReading = args.Reading;

            LuxLums = lightSensorReading.IlluminanceInLux.ToString("{0,5:0.00}");
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

            SetupEventing(IsEventing);
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
