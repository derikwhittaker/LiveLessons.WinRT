using System;
using LL.Navigation.Views;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LL.Navigation.ViewModels
{
    public class ArgumentNavigationViewModel : BaseViewModel
    {
        private readonly Frame _frame;
        private string _passedArgument;

        public ArgumentNavigationViewModel(Frame frame)
        {
            _frame = frame;
            PageTitle = "Argument Navigation";
      
            _frame.Navigated += FrameOnNavigated;
        }

        private void FrameOnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            if ( navigationEventArgs.NavigationMode == NavigationMode.New || navigationEventArgs.NavigationMode == NavigationMode.Forward
                && navigationEventArgs.SourcePageType == typeof(ArgumentNavigationPage) )
            {
                var asArray = navigationEventArgs.Parameter as string[];
                
                PassedArgument = asArray[0];
            }

            _frame.Navigated -= FrameOnNavigated;
        }

        public string PassedArgument
        {
            get { return _passedArgument; }
            set { _passedArgument = value; OnPropertyChanged("PassedArgument"); }
        }
    }
}