using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace LL.VSM.Views
{
    [TemplateVisualState(Name = "Selected", GroupName = "InteractionGroup")]
    [TemplateVisualState(Name = "Unselected", GroupName = "InteractionGroup")]
    [TemplateVisualState(Name = "Enabled", GroupName = "CommonGroup")]
    [TemplateVisualState(Name = "Disabled", GroupName = "CommonGroup")]
    public sealed class AutoDisplayControl : Control
    {
        public AutoDisplayControl()
        {
            this.DefaultStyleKey = typeof(AutoDisplayControl);
        }

        public Image AutoImage { get; set; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.IsEnabledChanged += OnIsEnabledChanged;

            AutoImage = GetTemplateChild("AutoImage") as Image;
            AutoImage.Tapped += AutoImageOnTapped;
        }

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if ( this.IsEnabled)
            {
                VisualStateManager.GoToState(this, "Enabled", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Disabled", true);
            }
        }

        private bool _tapped = false;
        private void AutoImageOnTapped(object sender, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            if (!_tapped)
            {
                VisualStateManager.GoToState(this, "Selected", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Unselected", true);
            }

            _tapped = !_tapped;
        }

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(ImageSource), typeof(AutoDisplayControl), new PropertyMetadata(default(ImageSource)));

        public ImageSource ImagePath
        {
            get { return (ImageSource)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AutoDisplayControl), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public static readonly DependencyProperty SubTitleProperty =
            DependencyProperty.Register("SubTitle", typeof(string), typeof(AutoDisplayControl), new PropertyMetadata(default(string)));

        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }
    }
}
