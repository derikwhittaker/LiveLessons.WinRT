using System;
using GalaSoft.MvvmLight.Command;
using LL.SettingsContract.Views;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace LL.SettingsContract.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private RelayCommand _enableSettingsCommand;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Settings Contract";
            
        }

        private SettingsViewModel _settings = new SettingsViewModel();
        public SettingsViewModel Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public RelayCommand EnableSettingsCommand
        {
            get { return _enableSettingsCommand ?? (_enableSettingsCommand = new RelayCommand(EnableSettings));  }
        }

        private bool _commandsAreEnabled = false;
        private void EnableSettings()
        {
            if (!_commandsAreEnabled)
            {
                SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
                _commandsAreEnabled = true;
            }
            else
            {
                SettingsPane.GetForCurrentView().CommandsRequested -= OnCommandsRequested;
                _commandsAreEnabled = false;
            }
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            var aboutCommandHandler = new UICommandInvokedHandler(OnAboutCommandInvoker);
            var aboutPage = new SettingsCommand("aboutPage", "About", aboutCommandHandler);

            var settingsCommandHandler = new UICommandInvokedHandler(OnSettingsCommandInvoker);
            var settingsPage = new SettingsCommand("settingsPage", "Settings", settingsCommandHandler);

            args.Request.ApplicationCommands.Add(aboutPage);
            args.Request.ApplicationCommands.Add(settingsPage);          
        }

        private Popup settingsPopup;
        private double settingsWidth = 646;
        private Rect windowBounds = Window.Current.Bounds;
        private void OnSettingsCommandInvoker(IUICommand command)
        {
            settingsPopup = new Popup();
            settingsPopup.Closed += SettingsPopupOnClosed;
            Window.Current.Activated += OnWindowActivated;
            settingsPopup.IsLightDismissEnabled = true;
            settingsPopup.Width = settingsWidth;
            settingsPopup.Height = windowBounds.Height;

            settingsPopup.ChildTransitions = new TransitionCollection();
            settingsPopup.ChildTransitions.Add(new PaneThemeTransition()
            {
                Edge = (SettingsPane.Edge == SettingsEdgeLocation.Right) ?
                       EdgeTransitionLocation.Right :
                       EdgeTransitionLocation.Left
            });

            // Create a SettingsFlyout the same dimenssions as the Popup.
            var mypane = new SettingsFlyoutPage
            {
                DataContext = this.Settings
            };

            mypane.Width = settingsWidth;
            mypane.Height = windowBounds.Height;

            settingsPopup.Child = mypane;

            settingsPopup.SetValue(Canvas.LeftProperty, SettingsPane.Edge == SettingsEdgeLocation.Right ? (windowBounds.Width - settingsWidth) : 0);
            settingsPopup.SetValue(Canvas.TopProperty, 0);
            settingsPopup.IsOpen = true;            
        }

        private void OnWindowActivated(object sender, WindowActivatedEventArgs e)
        {
            if( e.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                settingsPopup.IsOpen = false;
            }
        }

        private void SettingsPopupOnClosed(object sender, object e)
        {
            Window.Current.Activated -= OnWindowActivated;
        }

        private void OnAboutCommandInvoker(IUICommand command)
        {
            
        }
    }
}
