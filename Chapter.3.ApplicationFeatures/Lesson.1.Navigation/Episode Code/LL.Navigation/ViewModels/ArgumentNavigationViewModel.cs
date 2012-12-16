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
        
        public string PassedArgument
        {
            get { return _passedArgument; }
            set { _passedArgument = value; OnPropertyChanged("PassedArgument"); }
        }
    }
}