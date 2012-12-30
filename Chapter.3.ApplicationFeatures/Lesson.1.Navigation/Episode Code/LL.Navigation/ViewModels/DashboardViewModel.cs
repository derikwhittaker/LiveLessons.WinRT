using System;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using LL.Navigation.Views;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LL.Navigation.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public Frame CurrentFrame { get; set; }
        private RelayCommand _simpleNavigationCommand;
        private RelayCommand _simpleNavigationWithForwardCommand;
        private RelayCommand _simpleNavigationWithEventsCommand;
        private RelayCommand _simpleNavigationWithArgumentsCommand;

        public DashboardViewModel(Frame currentFrame)
        {
            CurrentFrame = currentFrame;
            PageTitle = "Learning to Navigate";
        }

        public RelayCommand SimpleNavigationCommand
        {
            get { return _simpleNavigationCommand ?? (_simpleNavigationCommand = new RelayCommand(SimpleNavigation)); }
        }

        private void SimpleNavigation()
        {
            CurrentFrame.Navigate(typeof (SimpleNavigationPage));
        }

        public RelayCommand SimpleNavigationWithForwardCommand
        {
            get { return _simpleNavigationWithForwardCommand ?? (_simpleNavigationWithForwardCommand = new RelayCommand(SimpleNavigationWithForward)); }
        }

        private void SimpleNavigationWithForward()
        {
            if ( CurrentFrame.CanGoForward )
            {
                CurrentFrame.GoForward();
            }
        }

        public RelayCommand SimpleNavigationWithEventsCommand
        {
            get { return _simpleNavigationWithEventsCommand ?? (_simpleNavigationWithEventsCommand = new RelayCommand(SimpleNavigationWithEvents));  }
        }

        private void SimpleNavigationWithEvents()
        {
            CurrentFrame.Navigated += CurrentFrameOnNavigated;
            CurrentFrame.Navigating += CurrentFrameOnNavigating;

            CurrentFrame.Navigate(typeof (SimpleNavigationPage));

        }

        private void CurrentFrameOnNavigating(object sender, NavigatingCancelEventArgs navigatingCancelEventArgs)
        {
            Debug.WriteLine("Navigatino In Progress");
            CurrentFrame.Navigating -= CurrentFrameOnNavigating;
        }

        private void CurrentFrameOnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            Debug.WriteLine("Navigation Completed");
            CurrentFrame.Navigated -= CurrentFrameOnNavigated;
        }

        public RelayCommand SimpleNavigationWithArgumentsCommand
        {
            get { return _simpleNavigationWithArgumentsCommand ?? (_simpleNavigationWithArgumentsCommand = new RelayCommand(SimpleNavigationWithArguments)); }
        }

        private void SimpleNavigationWithArguments()
        {
            CurrentFrame.Navigate(typeof(ArgumentNavigationPage), new string[]{"Hello World"});
        }
    }
}
