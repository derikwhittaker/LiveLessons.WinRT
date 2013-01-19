
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
        private bool _isEventing;
        private bool _isShaking;
        private int _ellipseSize = 150;
        private RelayCommand _toggleShakeCommand;
        private RelayCommand _toggleEventingCommand;

        private Sensor.Accelerometer _accelerometer;
        private double _xAxisReading;
        private double _yAxisReading;
        private double _zAxisReading;
        private string _currentReadingStyle;

        public DashboardViewModel(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            PageTitle = "Learning to use Accelerometer";

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

            var zMovement = CalculateMovement(ZAxisReading, _lastZAxisReading);
            EllipseSize = EllipseSize + zMovement;

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
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                XAxisReading = args.Reading.AccelerationX;
                YAxisReading = args.Reading.AccelerationY;
                ZAxisReading = args.Reading.AccelerationZ;

                SetupNewLocation();
            });
        }

        private void SetupShaking(bool enableShaking)
        {
            if (enableShaking)
            {
                _accelerometer.Shaken += AccelerometerOnShaken;
                CurrentReadingStyle = "Shaking";
            }
            else
            {
                _accelerometer.Shaken -= AccelerometerOnShaken;
                CurrentReadingStyle = "Stopped";
            }
        }

        private void AccelerometerOnShaken(Sensor.Accelerometer sender, Sensor.AccelerometerShakenEventArgs args)
        {
            
        }


        private void SetupSensor()
        {
            _accelerometer = Sensor.Accelerometer.GetDefault();

            if (_accelerometer == null)
            {
                // there is no grometer on this device.....
            }
        }

        public RelayCommand ToggleShakeCommand
        {
            get { return _toggleShakeCommand ?? (_toggleShakeCommand = new RelayCommand(ToggleShake)); }
        }

        private void ToggleShake()
        {
            IsShaking = !IsShaking;
            IsEventing = false;
        }

        public RelayCommand ToggleEventingCommand
        {
            get { return _toggleEventingCommand ?? (_toggleEventingCommand = new RelayCommand(ToggleEventing)); }
        }

        private void ToggleEventing()
        {
            IsEventing = !IsEventing;
            IsShaking = false;
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

    }
}
