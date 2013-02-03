using GalaSoft.MvvmLight.Command;

namespace LL.Animations.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private RelayCommand _bounceBallCommand;
        private RelayCommand _smoothBounceBallCommand;
        private RelayCommand _easingBounceBallCommand;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Animations";
            
        }

        public RelayCommand BounceBallCommand
        {
            get { return _bounceBallCommand ?? (_bounceBallCommand = new RelayCommand(BounceBall)); }
        }

        private void BounceBall()
        {
            OnPropertyChanged("BounceBall");
        }

        public RelayCommand SmoothBounceBallCommand
        {
            get { return _smoothBounceBallCommand ?? (_smoothBounceBallCommand = new RelayCommand(SmoothBounceBall)); }
        }

        private void SmoothBounceBall()
        {
            OnPropertyChanged("SmoothBounceBall");
        }

        public RelayCommand EasingBounceBallCommand
        {
            get { return _easingBounceBallCommand ?? (_easingBounceBallCommand = new RelayCommand(EasingBounceBall)); }
        }

        private void EasingBounceBall()
        {
            OnPropertyChanged("EasingBounceBall");
        }
    }
}
