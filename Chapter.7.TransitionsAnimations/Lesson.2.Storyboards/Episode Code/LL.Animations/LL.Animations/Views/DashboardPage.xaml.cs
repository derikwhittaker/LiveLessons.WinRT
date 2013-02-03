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

            vm.PropertyChanged += VmOnPropertyChanged;
            
            DataContext = vm;
        }

        private void VmOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "BounceBall":
                    BounceStoryboard.Begin();
                    break;
                case "SmoothBounceBall":
                    SmoothBounceStoryboard.RepeatBehavior = new RepeatBehavior { Type = RepeatBehaviorType.Count, Count = 5};
                    //SmoothBounceStoryboard.RepeatBehavior = new RepeatBehavior{Type = RepeatBehaviorType.Forever};
                    SmoothBounceStoryboard.Begin();
                    break;

                case "EasingBounceBall":
                    EasingBounceBallAnimation.EasingFunction = new CubicEase();
                    EasingBounceBallStoryboard.Begin();
                    break;
            }
        }
    }
}
