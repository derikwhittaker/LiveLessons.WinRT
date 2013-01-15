using System;
using GalaSoft.MvvmLight.Command;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace LL.Camera.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private RelayCommand _takePictureCommand;
        private ImageSource _capturedImage;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Camera";
            
        }

        public RelayCommand TakePictureCommand
        {
            get { return _takePictureCommand ?? (_takePictureCommand = new RelayCommand(TakePicture)); }
        }

        private async void TakePicture()
        {
            var cameraCaptureUi = new CameraCaptureUI();
            
            cameraCaptureUi.PhotoSettings.CroppedAspectRatio = new Size(4, 3);
            cameraCaptureUi.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Png;
            cameraCaptureUi.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;

            // show this once done w/ initial demo
            //cameraCaptureUi.PhotoSettings.AllowCropping = false;

            var picture = await cameraCaptureUi.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if ( picture != null )
            {
                var image = new BitmapImage();
                using ( var pictureStream = await picture.OpenReadAsync())
                {
                    image.SetSource(pictureStream);

                    CapturedImage = image;
                }
            }
        }

        public ImageSource CapturedImage
        {
            get { return _capturedImage; }
            set { _capturedImage = value; OnPropertyChanged("CapturedImage"); }
        }
    }
}
