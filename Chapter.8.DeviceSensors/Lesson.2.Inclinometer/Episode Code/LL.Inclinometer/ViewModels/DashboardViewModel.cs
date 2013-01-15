using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Core;
using Sensor = Windows.Devices.Sensors;

namespace LL.Inclinometer.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private readonly CoreDispatcher _dispatcher;
        private bool _isEventing;
        private bool _isPolling;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;
        private Sensor.Inclinometer _inclinometer;

        private int _canvasLeft;
        private int _canvasTop;
        private int _defaultLeft;
        private int _defaultTop;
        private RelayCommand _moveLeftCommand;
        private RelayCommand _moveDownCommand;

        public DashboardViewModel(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            PageTitle = "Learning to use Inclinometer";

            SetupSensor();
        }

        private void SetupSensor()
        {
            _inclinometer = Sensor.Inclinometer.GetDefault();

            if (_inclinometer == null)
            {
                // tell the user they dont have an inclinometer on the device
            }
        }

        private void SetupEventing(bool enableEventing)
        {
            if (enableEventing)
            {
                _inclinometer.ReadingChanged += InclinometerOnReadingChanged;
            }
            else
            {
                _inclinometer.ReadingChanged -= InclinometerOnReadingChanged;
            }
        }

        private async void InclinometerOnReadingChanged(Sensor.Inclinometer sender, Sensor.InclinometerReadingChangedEventArgs args)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var pitchDegrees = args.Reading.PitchDegrees;
                    var rollDegrees = args.Reading.RollDegrees;
                    var yawDegrees = args.Reading.YawDegrees;
                });
        }

        public void SetupDefaultLocation(double canvasWidth, double canvasHeight)
        {
            _defaultLeft = (int)canvasWidth/2;
            _defaultTop = (int)canvasHeight / 2;

            CanvasLeft = _defaultLeft;
            CanvasTop = _defaultTop;
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

        // testing
        public RelayCommand MoveLeftCommand
        {
            get { return _moveLeftCommand ?? (_moveLeftCommand = new RelayCommand(MoveLeft)); }
        }

        private void MoveLeft()
        {
            CanvasLeft = CanvasLeft - 10;
        }

        public RelayCommand MoveDownCommand
        {
            get { return _moveDownCommand ?? (_moveDownCommand = new RelayCommand(MoveDown)); }
        }

        private void MoveDown()
        {
            CanvasTop = CanvasTop + 10;
        }
    }
}
