using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;

namespace LL.DataWithCommanding.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private string _firstName = "Captain";
        private string _lastName = "Commander";
        private string _emailAddress = "captain.commander@email.com";
        private ICommand _commandCommand;
        private RelayCommand _relayCommand;
        private RelayCommand _canExecuteCommand;
        private RelayCommand<string> _withParameterCommand;
        private string _myParm = " Something";

        public DashboardViewModel()
        {
            PageTitle = "Data Actions w/ Commanding";
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");

                CanExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }

        #region ICommand

        public ICommand CommandCommand
        {
            get { return _commandCommand ?? (_commandCommand = new RelayCommand(HandleCommand)); }
        }

        private void HandleCommand()
        {
            FirstName = FirstName + " From ICommand";
            LastName = LastName + " From ICommand";
            EmailAddress = EmailAddress + " From ICommand";
        }

        #endregion

        #region RElayCOmmand

        public RelayCommand RelayCommand
        {
            get { return _relayCommand ?? (_relayCommand = new RelayCommand(HandleRelayCommand)); }
        }

        private void HandleRelayCommand()
        {
            FirstName = FirstName + " From RelayCommand";
            LastName = LastName + " From RelayCommand";
            EmailAddress = EmailAddress + " From RelayCommand";
        }

        #endregion

        #region CanRelayCommand

        public RelayCommand CanExecuteCommand
        {
            get { return _canExecuteCommand ?? (_canExecuteCommand = new RelayCommand(HandleRelayCommand, CanHandleRelayCommand)); }
        }

        private bool CanHandleRelayCommand()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(EmailAddress);
        }

        #endregion

        #region W/ Param

        public RelayCommand<string> WithParameterCommand
        {
            get { return _withParameterCommand ?? (_withParameterCommand= new RelayCommand<string>(HandleWithParameter)); }
        }

        private void HandleWithParameter(string value)
        {
            FirstName = FirstName + value;
            LastName = LastName + value;
            EmailAddress = EmailAddress + value;
        }

        public string MyParm
        {
            get { return _myParm; }
            set { _myParm = value; }
        }

        #endregion

    }

    public class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
