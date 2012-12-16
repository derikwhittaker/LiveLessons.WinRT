using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using LL.Navigation.Views;
using Metro.LL.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LL.Navigation.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly Frame _currentFrame;
        private RelayCommand _simpleNavigationCommand;
        private RelayCommand _simpleNavigationWithEventsCommand;
        private RelayCommand _simpleNavigationWithForwardCommand;
        private RelayCommand _simpleNavigationWithArgumentsCommand;

        public DashboardViewModel( Frame currentFrame  )
        {
            _currentFrame = currentFrame;
            PageTitle = "Learning to Navigate";
        }

        public RelayCommand SimpleNavigationCommand
        {
            get { return _simpleNavigationCommand ?? (_simpleNavigationCommand = new RelayCommand(SimpleNavigation)); }
        }
        
        private void SimpleNavigation()
        {
            _currentFrame.Navigate(typeof (SimpleNavigationPage));
        }

        public RelayCommand SimpleNavigationWithForwardCommand
        {
            get
            {
                return _simpleNavigationWithForwardCommand ??
                       (_simpleNavigationWithForwardCommand = new RelayCommand(SimpleNavigationWithForward));
            }
        }

        private void SimpleNavigationWithForward()
        {
            if ( _currentFrame.CanGoForward )
            {
                _currentFrame.GoForward();
            }
        }
        
        public RelayCommand SimpleNavigationWithEventsCommand
        {
            get { return _simpleNavigationWithEventsCommand ?? (_simpleNavigationWithEventsCommand = new RelayCommand(SimpleNavigationWithEvents)); }
        }

        private void SimpleNavigationWithEvents()
        {
            _currentFrame.Navigated += (sender, args) => { Debug.WriteLine("Navigation Completed"); };
            _currentFrame.Navigating += (sender, args) => { Debug.WriteLine("Navigation In Progress"); };
            
            _currentFrame.Navigate(typeof(SimpleNavigationPage));
        }

        public RelayCommand SimpleNavigationWithArgumentsCommand
        {
            get { return _simpleNavigationWithArgumentsCommand ?? (_simpleNavigationWithArgumentsCommand = new RelayCommand(SimpleNavigationWithArguments)); }
        }

        private void SimpleNavigationWithArguments()
        {
            _currentFrame.Navigate(typeof(ArgumentNavigationPage), "Some Value");
        }
    }
}
