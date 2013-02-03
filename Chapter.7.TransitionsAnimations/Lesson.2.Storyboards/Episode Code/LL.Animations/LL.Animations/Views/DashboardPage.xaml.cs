using System;
using System.ComponentModel;
using LL.Animations.ViewModels;
using Windows.UI.Xaml.Media.Animation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace LL.Animations.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DashboardPage : LL.Animations.Common.LayoutAwarePage
    {

        public DashboardPage()
        {
            this.InitializeComponent();

            var vm = new DashboardViewModel();

            vm.PropertyChanged += OnPropertyChanged;

            DataContext = vm;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "BounceBall":
                    BounceBallStoryboard.Begin();
                    break;
                case "SmoothBounceBall":
                    SmoothBouceBallStoryboard.RepeatBehavior = new RepeatBehavior{Type = RepeatBehaviorType.Forever};
                    SmoothBouceBallStoryboard.Begin();
                    break;

                case "EasingBounceBall":
                    EasingAnimation.EasingFunction = new BounceEase
                        {
                            EasingMode = EasingMode.EaseIn
                        };
                    
                    EasingBouceBallStoryboard.Begin();
                    break;
            }
        }
    }
}
