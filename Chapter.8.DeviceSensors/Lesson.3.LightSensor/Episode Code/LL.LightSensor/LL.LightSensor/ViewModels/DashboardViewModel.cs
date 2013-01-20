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
        private readonly CoreDispatcher _dispatcher;
        private Sensor.LightSensor _lightSensor;
        private bool _isEventing;
        private bool _isPolling;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;
        private double _brightness = .1;
        private string _luxLums;
        private string _currentReadingStyle;


        public DashboardViewModel(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            PageTitle = "Learning to use Light Sensor";
         
            SetupSensor();
        }

        private void SetupSensor()
        {
            _lightSensor = Sensor.LightSensor.GetDefault();

            if (_lightSensor == null)
            {
                
                // tell user no device
            }
    }
        private void SetupEventing(bool enableEventing)
        {
            if ( enableEventing )
            {
                _lightSensor.ReadingChanged += LightSensorOnReadingChanged;
                _lightSensor.ReportInterval = 100;
                CurrentReadingStyle = "Eventing";
            }
            else
            {
                _lightSensor.ReadingChanged -= LightSensorOnReadingChanged;
                CurrentReadingStyle = "Stopped";
            }
        }

        private async void LightSensorOnReadingChanged(Sensor.LightSensor sender, Sensor.LightSensorReadingChangedEventArgs args)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                                                                          {
                                                                              var lightReading = args.Reading;
                                                                              LuxLums = string.Format("{0,5:0.00}", lightReading.IlluminanceInLux);
                                                                              Brightness = lightReading.IlluminanceInLux / 100;
                                                                          });
        }

        private DispatcherTimer _dispatcherTimer;
        private void SetupPolling(bool enablePolling)
        {
            if ( enablePolling)
            {
                _dispatcherTimer = new DispatcherTimer
                                       {
                                           Interval = new TimeSpan(0,0,0,5),
                                       };
                _dispatcherTimer.Tick += DispatcherTimerOnTick;
                _dispatcherTimer.Start();

                CurrentReadingStyle = "Polling";
            }
            else
            {
                if ( _dispatcherTimer != null )
                {
                    _dispatcherTimer.Stop();
                    _dispatcherTimer = null;
                }
                CurrentReadingStyle = "Stopped";
            }
        }

        private void DispatcherTimerOnTick(object sender, object o)
        {
            var lightReading = _lightSensor.GetCurrentReading();
            LuxLums = string.Format("{0,5:0.00}", lightReading.IlluminanceInLux);
            Brightness = lightReading.IlluminanceInLux / 100;            
        }

        public RelayCommand TogglePollingCommand
        {
            get { return _togglePollingCommand ?? (_togglePollingCommand = new RelayCommand(TogglePolling)); }
        }

        private void TogglePolling()
        {
            IsPolling = !IsPolling;
            IsEventing = false;

            SetupEventing(IsEventing);
            SetupPolling(IsPolling);
            
        }

        public RelayCommand ToggleEventingCommand
        {
            get { return _toggleEventingCommand ?? (_toggleEventingCommand = new RelayCommand(ToggleEventing)); }
        }

        private void ToggleEventing()
        {
            IsEventing = !IsEventing;
            IsPolling = false;

            SetupPolling(IsPolling);
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
