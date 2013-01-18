using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Sensor = Windows.Devices.Sensors;

namespace LL.Gyrometer.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private DispatcherTimer _dispatcherTimer;
        private readonly CoreDispatcher _dispatcher;
        private bool _isEventing;
        private bool _isPolling;
        private int _ellipseSize = 150;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;

        private Sensor.Gyrometer _gyrometer;
        private double _xAxisReading;
        private double _yAxisReading;
        private double _zAxisReading;
        private string _currentReadingStyle;

        public DashboardViewModel(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            PageTitle = "Learning to use Gyrometer";

            SetupSensor();
        }

        private int _canvasLeft;
        private int _canvasTop;
        private int _defaultLeft;
        private int _defaultTop;

        public void SetupDefaultLocation(double canvasWidth, double canvasHeight)
        {
            _defaultLeft = ((int)canvasWidth / 2) - (EllipseSize / 2);
            _defaultTop = ((int)canvasHeight / 2) - (EllipseSize / 2);

            CanvasLeft = _defaultLeft;
            CanvasTop = _defaultTop;
        }

        private double _lastXAxisReading = 0;
        private double _lastYAxisReading = 0;
        private double _lastZAxisReading = 0;
        public void SetupNewLocation()
        {
            var xMovement = CalculateMovement(XAxisReading, _lastXAxisReading);
            CanvasLeft = CanvasLeft + xMovement;

            var yMovement = CalculateMovement(YAxisReading, _lastYAxisReading);
            CanvasTop = CanvasTop + yMovement;
            
            _lastXAxisReading = XAxisReading;
            _lastYAxisReading = YAxisReading;
            _lastZAxisReading = ZAxisReading;
        }
        private int CalculateMovement(double current, double last)
        {
            var movement = (current - last);
            var absMovement = Math.Abs(movement);
            var returnValue = 0;

            if (movement == 0)
            {
                return 0;
            }
            else if (movement >= 0)
            {
                returnValue = absMovement > 1 ? (int)movement : 1;
            }
            else
            {
                returnValue = absMovement > 1 ? (int)movement : -1;
            }

            return returnValue * 5;
        }


        private void SetupEventing(bool enableEventing)
        {
            if (enableEventing)
            {
                _gyrometer.ReadingChanged += GyrometerOnReadingChanged;
                CurrentReadingStyle = "Eventing";
            }
            else
            {
                _gyrometer.ReadingChanged -= GyrometerOnReadingChanged;
                CurrentReadingStyle = "Stopped";
            }
        }

        private async void GyrometerOnReadingChanged(Sensor.Gyrometer sender, Sensor.GyrometerReadingChangedEventArgs args)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                XAxisReading = args.Reading.AngularVelocityX;
                YAxisReading = args.Reading.AngularVelocityY;
                ZAxisReading = args.Reading.AngularVelocityZ;

                SetupNewLocation();
            });            
        }

        private void SetupPolling(bool enablePolling)
        {
            if (enablePolling)
            {
                _dispatcherTimer = new DispatcherTimer();
                _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
                _dispatcherTimer.Tick += DispatcherTimerOnTick;

                _dispatcherTimer.Start();

                CurrentReadingStyle = "Polling";
            }
            else
            {
                if (_dispatcherTimer != null)
                {
                    _dispatcherTimer.Stop();
                    _dispatcherTimer = null;
                }

                CurrentReadingStyle = "Stopped";
            }
        }

        private void DispatcherTimerOnTick(object sender, object o)
        {
            XAxisReading = _gyrometer.GetCurrentReading().AngularVelocityX;
            YAxisReading = _gyrometer.GetCurrentReading().AngularVelocityY;
            ZAxisReading = _gyrometer.GetCurrentReading().AngularVelocityZ;

            SetupNewLocation();
        }

        private void SetupSensor()
        {
            _gyrometer = Sensor.Gyrometer.GetDefault();

            if (_gyrometer == null)
            {
                // there is no grometer on this device.....
            }
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

        public double XAxisReading
        {
            get { return _xAxisReading; }
            set { _xAxisReading = value; OnPropertyChanged("XAxisReading"); }
        }

        public double YAxisReading
        {
            get { return _yAxisReading; }
            set { _yAxisReading = value; OnPropertyChanged("YAxisReading"); }
        }

        public double ZAxisReading
        {
            get { return _zAxisReading; }
            set { _zAxisReading = value; OnPropertyChanged("ZAxisReading"); }
        }

        public string CurrentReadingStyle
        {
            get { return _currentReadingStyle; }
            set { _currentReadingStyle = value; OnPropertyChanged("CurrentReadingStyle"); }
        }

        public int EllipseSize
        {
            get { return _ellipseSize; }
            set { _ellipseSize = value; OnPropertyChanged("EllipseSize"); }
        }

        public int CanvasLeft
        {
            get { return _canvasLeft; }
            set { _canvasLeft = value; OnPropertyChanged("CanvasLeft"); }
        }

        public int CanvasTop
        {
            get { return _canvasTop; }
            set { _canvasTop = value; OnPropertyChanged("CanvasTop"); }
        }
<<<<<<< HEAD

        // testing
        public RelayCommand MoveXCommand
        {
            get { return _moveXCommand ?? (_moveXCommand = new RelayCommand(() =>
                {
                    XAxisReading = XAxisReading + 1;
                    SetupNewLocation();
                }));  }
        }

        public RelayCommand MoveXNegativeCommand
        {
            get
            {
                return _moveXNegatveCommand ?? (_moveXNegatveCommand = new RelayCommand(() =>
                {
                        XAxisReading = XAxisReading - 1;
                    SetupNewLocation();
                }));
            }
        }

        public RelayCommand MoveYCommand
        {
            get { return _moveYCommand ?? (_moveYCommand = new RelayCommand(() =>
                {
                    {
                        YAxisReading = YAxisReading + 1;
                        SetupNewLocation();
                    }
                })); }
        }


        public RelayCommand MoveZCommand
        {
            get
            {
                return _moveZCommand ?? (_moveZCommand = new RelayCommand(() =>
                {
                    ZAxisReading = ZAxisReading + 1;
                    SetupNewLocation();
                }));
            }
        }

=======
        
>>>>>>> Post Recording Camera
    }
}
