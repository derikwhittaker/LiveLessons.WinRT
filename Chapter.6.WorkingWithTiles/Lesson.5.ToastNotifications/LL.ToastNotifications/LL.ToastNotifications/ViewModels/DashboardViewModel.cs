using System;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace LL.ToastNotifications.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            PageTitle = "Toast Notifications";
        }

        #region Is Toast Enabled

        private RelayCommand _isToastEnabledCommand;
        public RelayCommand IsToastEnabledCommand
        {
            get { return _isToastEnabledCommand ?? (_isToastEnabledCommand = new RelayCommand(IsToastEnabled)); }
        }

        private async void IsToastEnabled()
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();

            if ( notifier.Setting == NotificationSetting.Enabled )
            {
                var dialog = new MessageDialog("Notifications are enabled");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Notifications are NOT enabled");
                await dialog.ShowAsync();
            }
        }

        #endregion

        #region Send Plain Text

        private RelayCommand _sendPlainTextCommand;
        private string _plainTextValue;

        public RelayCommand SendPlainTextCommand
        {
            get { return _sendPlainTextCommand ?? (_sendPlainTextCommand = new RelayCommand(SendPlainTextToast)); }
        }

        private void SendPlainTextToast()
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var tempate = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var element = tempate.GetElementsByTagName("text")[0];
            element.AppendChild(tempate.CreateTextNode(PlainTextValue));

            var toast = new ToastNotification(tempate);
            notifier.Show(toast);
        }

        public string PlainTextValue
        {
            get { return _plainTextValue; }
            set
            {
                _plainTextValue = value;
                OnPropertyChanged("PlainTextValue");
            }
        }

        #endregion

        #region Send Image Text

        private RelayCommand _sendImageToastCommand;
        private string _imageTextValue;

        public RelayCommand SendImageToastCommand
        {
            get { return _sendImageToastCommand ?? (_sendImageToastCommand = new RelayCommand(SendImageToast)); }
        }

        private void SendImageToast()
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var tempate = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);

            var element = tempate.GetElementsByTagName("text")[0];
            element.AppendChild(tempate.CreateTextNode(ImageTextValue));

            var images = tempate.GetElementsByTagName("image");
            ((XmlElement)images[0]).SetAttribute("src", "Images/GreenToastSquare.png");

            var toast = new ToastNotification(tempate);
            notifier.Show(toast);
        }

        public string ImageTextValue
        {
            get { return _imageTextValue; }
            set
            {
                _imageTextValue = value;
                OnPropertyChanged("ImageTextValue");
            }
        }

        #endregion

        #region Send Future Toast

        private RelayCommand _sendDelayToastCommand;
        private string _delayedTextValue;

        public RelayCommand SendDelayToastCommand
        {
            get { return _sendDelayToastCommand ?? (_sendDelayToastCommand = new RelayCommand(SendDelayToast)); }
        }

        private void SendDelayToast()
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var tempate = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);

            var element = tempate.GetElementsByTagName("text")[0];
            element.AppendChild(tempate.CreateTextNode(DelayedTextValue));

            var images = tempate.GetElementsByTagName("image");
            ((XmlElement)images[0]).SetAttribute("src", "Images/GreenToastSquare.png");

            var date = DateTimeOffset.Now.AddSeconds(5);
            var toast = new ScheduledToastNotification(tempate, date);
            notifier.AddToSchedule(toast);

        }

        public string DelayedTextValue
        {
            get { return _delayedTextValue; }
            set
            {
                _delayedTextValue = value;
                OnPropertyChanged("DelayedTextValue");
            }
        }

        #endregion
    }
}
