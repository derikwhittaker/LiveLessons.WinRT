using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Sensor = Windows.Devices.Sensors;

namespace LL.Inclinometer.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private bool _isEventing;
        private bool _isPolling;
        private RelayCommand _togglePollingCommand;
        private RelayCommand _toggleEventingCommand;
        
        private int _canvasLeft;
        private int _canvasTop;
        private int _defaultLeft;
        private int _defaultTop;
        private float _pitchDegrees;
        private float _rollDegrees;
        private float _yawDegress;
        private int _ellipseSize = 150;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Inclinometer";
        }

        public void SetupDefaultLocation(double canvasWidth, double canvasHeight)
        {
            _defaultLeft = ((int)canvasWidth / 2) - (_ellipseSize / 2);
            _defaultTop = ((int)canvasHeight / 2) - (_ellipseSize / 2);

            CanvasLeft = _defaultLeft;
            CanvasTop = _defaultTop;
        }
        
        private float _lastRollDegrees = 0;
        private float _lastPitchDegrees = 0;
        private string _currentReadingStyle;

        public void SetupNewLocation()
        {
            var rollMovement = CalculateMovement(RollDegrees, _lastRollDegrees);
            CanvasLeft = CanvasLeft + rollMovement;
            
            var pitchMovement = CalculateMovement(PitchDegrees, _lastPitchDegrees);
            CanvasTop = CanvasTop + pitchMovement;
            
            _lastPitchDegrees = PitchDegrees;
            _lastRollDegrees = RollDegrees;
        }

        private int CalculateMovement(float current, float last)
        {
            var movement = (current - last);
            var absMovement = Math.Abs(movement);
            var returnValue = 0;

            if ( movement == 0)
            {
                return 0;
            }
            else if ( movement >= 0)
            {
                returnValue = absMovement > 1 ? (int)movement : 1;
            }
            else
            {
                returnValue = absMovement > 1 ? (int)movement : -1;
            }

            return returnValue*5;

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
        
        public float PitchDegrees
        {
            get { return _pitchDegrees; }
            set { _pitchDegrees = value; OnPropertyChanged("PitchDegrees"); }
        }

        public float RollDegrees
        {
            get { return _rollDegrees; }
            set { _rollDegrees = value; OnPropertyChanged("RollDegrees"); }
        }

        public float YawDegrees
        {
            get { return _yawDegress; }
            set { _yawDegress = value; OnPropertyChanged("YawDegrees"); }
        }

        public string CurrentReadingStyle
        {
            get { return _currentReadingStyle; }
            set { _currentReadingStyle = value; OnPropertyChanged("CurrentReadingStyle"); }
        }
    }
}
