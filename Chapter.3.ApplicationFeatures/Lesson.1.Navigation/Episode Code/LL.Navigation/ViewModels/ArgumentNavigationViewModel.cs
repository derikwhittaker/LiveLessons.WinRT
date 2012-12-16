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

            _frame.Navigated += HandleNavigated;            
        }

        private void HandleNavigated(object sender, NavigationEventArgs args)
        {
            if ((args.NavigationMode == NavigationMode.New || args.NavigationMode == NavigationMode.Forward)
                && args.SourcePageType == typeof(ArgumentNavigationPage))
            {
                PassedArgument = args.Parameter.ToString();
            }
            else
            {
                _frame.Navigated -= HandleNavigated;
            }
        }

        public string PassedArgument
        {
            get { return _passedArgument; }
            set { _passedArgument = value; OnPropertyChanged("PassedArgument"); }
        }
    }
}