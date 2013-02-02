
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Core;
using Sensor = Windows.Devices.Sensors;

namespace LL.Accelerometer.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private readonly CoreDispatcher _dispatcher;
        private Sensor.Accelerometer _accelerometer;
        private bool _isEventing;
        private bool _isShaking;
        private int _ellipseSize = 150;
        private RelayCommand _toggleShakeCommand;
        private RelayCommand _toggleEventingCommand;

        private double _xAcceleration;
        private double _yAcceleration;
        private double _zAcceleration;
        private string _currentReadingStyle;

        public DashboardViewModel(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            PageTitle = "Learning to use Accelerometer";

            SetupSensor();
        }

        private void SetupSensor()
        {
            _accelerometer = Sensor.Accelerometer.GetDefault();

            if ( _accelerometer == null )
            {
                // tell user no accelerometer
            }
        }

        private void SetupEventing(bool enableEventing)
        {
            if ( enableEventing )
            {
                _accelerometer.ReadingChanged += AccelerometerOnReadingChanged;
                CurrentReadingStyle = "Eventing";
            }
            else
            {
                _accelerometer.ReadingChanged -= AccelerometerOnReadingChanged;
                CurrentReadingStyle = "Stopped";
            }
        }

private async void AccelerometerOnReadingChanged(Sensor.Accelerometer sender, Sensor.AccelerometerReadingChangedEventArgs args)
{
    await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, 
        () =>
            {
                XAcceleration = args.Reading.AccelerationX;
                YAcceleration = args.Reading.AccelerationY;
                ZAcceleration = args.Reading.AccelerationZ;

                SetupNewLocation();
            });
}

private void SetupShaken(bool enableShaking)
{
    if ( enableShaking )
    {
        _accelerometer.Shaken += AccelerometerOnShaken;
        ShakeCount = 0;
        CurrentReadingStyle = "Shaking";
    }
    else
    {
        _accelerometer.Shaken -= AccelerometerOnShaken;
        CurrentReadingStyle = "Stopped";
    }
}

private async void AccelerometerOnShaken(Sensor.Accelerometer sender, Sensor.AccelerometerShakenEventArgs args)
{
    await _dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                () =>
                                    {
                                        ShakeCount = ShakeCount + 1;
                                    });
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
        private int _shakeCount;

        public void SetupNewLocation()
        {
            var xMovement = CalculateMovement(XAcceleration, _lastXAxisReading);
            CanvasLeft = CanvasLeft + xMovement;

            var yMovement = CalculateMovement(YAcceleration, _lastYAxisReading);
            CanvasTop = CanvasTop + yMovement;

            var zMovement = CalculateMovement(ZAcceleration, _lastZAxisReading);
            EllipseSize = EllipseSize + zMovement;

            _lastXAxisReading = XAcceleration;
            _lastYAxisReading = YAcceleration;
            _lastZAxisReading = ZAcceleration;
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

            return returnValue * 10;
        }
        
        public RelayCommand ToggleShakeCommand
        {
            get { return _toggleShakeCommand ?? (_toggleShakeCommand = new RelayCommand(ToggleShake)); }
        }

        private void ToggleShake()
        {
            IsShaking = !IsShaking;
            IsEventing = false;

            SetupEventing(IsEventing);
            SetupShaken(IsShaking);
            
        }

        public RelayCommand ToggleEventingCommand
        {
            get { return _toggleEventingCommand ?? (_toggleEventingCommand = new RelayCommand(ToggleEventing)); }
        }

        private void ToggleEventing()
        {
            IsEventing = !IsEventing;
            IsShaking = false;

            SetupShaken(IsShaking);
            SetupEventing(IsEventing);
        }

        public bool IsEventing
        {
            get { return _isEventing; }
            set { _isEventing = value; OnPropertyChanged("IsEventing"); }
        }

        public bool IsShaking
        {
            get { return _isShaking; }
            set { _isShaking = value; OnPropertyChanged("IsShaking"); }
        }

        public int ShakeCount
        {
            get { return _shakeCount; }
            set { _shakeCount = value; OnPropertyChanged("ShakeCount"); }
        }

        public double XAcceleration
        {
            get { return _xAcceleration; }
            set { _xAcceleration = value; OnPropertyChanged("XAcceleration"); }
        }

        public double YAcceleration
        {
            get { return _yAcceleration; }
            set { _yAcceleration = value; OnPropertyChanged("YAcceleration"); }
        }

        public double ZAcceleration
        {
            get { return _zAcceleration; }
            set { _zAcceleration = value; OnPropertyChanged("ZAcceleration"); }
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

    }
}
