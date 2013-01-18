using System;
using GalaSoft.MvvmLight.Command;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace LL.Camera.ViewModels
{
    public class DashboardViewModel : Metro.LL.Common.BaseViewModel
    {
        private RelayCommand _takePictureCommand;
        private ImageSource _capturedImage;
        private RelayCommand _takeVideoCommand;
        private bool _showPicture;
        private bool _showVideo;
        private MediaElement _capturedMedia;

        public DashboardViewModel()
        {
            PageTitle = "Learning to use Camera";
            
        }

        public RelayCommand TakePictureCommand
        {
            get { return _takePictureCommand ?? (_takePictureCommand = new RelayCommand(TakePicture)); }
        }

        public RelayCommand TakeVideoCommand
        {
            get { return _takeVideoCommand ?? (_takeVideoCommand = new RelayCommand(TakeVideo));  }
        }

        private IRandomAccessStream _videoStream;
        private async void TakeVideo()
        {
            ShowPicture = false;
            ShowVideo = true;

            var cameraCaptureUI = new CameraCaptureUI();
            cameraCaptureUI.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

            var video = await cameraCaptureUI.CaptureFileAsync(CameraCaptureUIMode.Video);

            if ( video != null)
            {
                _videoStream = await video.OpenAsync(FileAccessMode.Read);

                CapturedMedia = new MediaElement {AutoPlay = true};
                CapturedMedia.Loaded += (sender, args) =>
                                            {
                                                CapturedMedia.SetSource(_videoStream, "video/mp4");
                                                CapturedMedia.Play();
                                            };
            }

        }

        private async void TakePicture()
        {
            ShowPicture = true;
            ShowVideo = false;

            var cameraCaptureUI = new CameraCaptureUI();

            cameraCaptureUI.PhotoSettings.CroppedAspectRatio = new Size(4,3);
            cameraCaptureUI.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            cameraCaptureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Png;

            var picture = await cameraCaptureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if ( picture != null )
            {
                var image = new BitmapImage();
                using(var pictureStream = await  picture.OpenReadAsync())
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

        public MediaElement CapturedMedia
        {
            get { return _capturedMedia; }
            set { _capturedMedia = value; OnPropertyChanged("CapturedMedia"); }
        }

        public bool ShowPicture
        {
            get { return _showPicture; }
            set { _showPicture = value; OnPropertyChanged("ShowPicture"); }
        }

        public bool ShowVideo
        {
            get { return _showVideo; }
            set { _showVideo = value; OnPropertyChanged("ShowVideo"); }
        }
    }
}
