using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Metro.LL.Common;
using Metro.LL.Common.Extensions;

using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace LL.ShareTarget.ViewModels
{
    public class ShareViewModel : BaseViewModel
    {

        private ShareOperation _shareOperation;
        public ShareViewModel()
        {
            PageTitle = "Share Content";
        }

        public async Task ShareAsync(ShareOperation shareOperation)
        {
            _shareOperation = shareOperation;
            shareOperation.ReportStarted();
            var dataPackageView = shareOperation.Data;

            RequestTitle = shareOperation.Data.Properties.Title;
            RequestDescription = shareOperation.Data.Properties.Description;

            try
            {
                if ( dataPackageView.IsTextMessage() )
                {
                    IsTextRequest = true;
                    TextShareValue = await dataPackageView.GetTextAsync();
                }
                else if (dataPackageView.IsUrlMessage())
                {
                    IsUrlRequest = true;
                    var foundUri = await dataPackageView.GetUriAsync();

                    UrlShareValue = foundUri.AbsoluteUri;
                }
                else if (dataPackageView.IsStorageItemsMessage())
                {
                    IsStorageRequest = true;
                    var storageItems = await dataPackageView.GetStorageItemsAsync();
                    if ( storageItems.Any())
                    {
                        var storageItem = storageItems.First();
                        if ( storageItem.IsOfType(StorageItemTypes.File))
                        {
                            StorageFileName = storageItem.Name;
                            var thumbNail = dataPackageView.Properties.Thumbnail;
                            var thumbnailStream = await thumbNail.OpenReadAsync();

                            ImageShareValue = new BitmapImage();
                            ImageShareValue.SetSource(thumbnailStream);
                        }
                    }
                }
                else if (dataPackageView.IsImageMessage())
                {
                    IsImageRequest = true;
                    var imageRecieved = await dataPackageView.GetBitmapAsync();
                    var imageStream = await imageRecieved.OpenReadAsync();

                    ImageShareValue = new BitmapImage();
                    ImageShareValue.SetSource(imageStream);
                }
            }
            catch (Exception e)
            {
                shareOperation.ReportError(e.Message);               
                RequestDescription = e.Message;
            }
            

            shareOperation.ReportDataRetrieved();
        }


        private void SaveContent()
        {
            var quickLink = new QuickLink
                                {
                                    Id = "LL.ShareTarge",
                                    Title = "Share Target"
                                };

            _shareOperation.ReportCompleted(quickLink);
        }

        private string _textShareValue;
        public string TextShareValue
        {
            get { return _textShareValue; }
            set
            {
                _textShareValue = value;
                OnPropertyChanged("TextShareValue");
            }
        }

        private string _urlShareValue;
        public string UrlShareValue
        {
            get { return _urlShareValue; }
            set
            {
                _urlShareValue = value;
                OnPropertyChanged("UrlShareValue");
            }
        }
        
        private BitmapImage _imageShareValue;
        public BitmapImage ImageShareValue
        {
            get { return _imageShareValue; }
            set
            {
                _imageShareValue = value;
                OnPropertyChanged("ImageShareValue");
            }
        }

        private bool _isTextRequest;
        public bool IsTextRequest
        {
            get { return _isTextRequest; }
            set
            {
                _isTextRequest = value;
                OnPropertyChanged("IsTextRequest");
            }
        }

        private bool _isUrlRequest;
        public bool IsUrlRequest
        {
            get { return _isUrlRequest; }
            set
            {
                _isUrlRequest = value;
                OnPropertyChanged("IsUrlRequest");
            }
        }

        private bool _isImageRequest;
        public bool IsImageRequest
        {
            get { return _isImageRequest; }
            set
            {
                _isImageRequest = value;
                OnPropertyChanged("IsImageRequest");
            }
        }

        private bool _isStorageRequest;
        public bool IsStorageRequest
        {
            get { return _isStorageRequest; }
            set
            {
                _isStorageRequest = value;
                OnPropertyChanged("IsStorageRequest");
            }
        }

        public string StorageFileName
        {
            get { return _storageFileName; }
            set
            {
                _storageFileName = value;
                OnPropertyChanged("StorageFileName");
            }
        }

        private string _requestTitle;
        public string RequestTitle
        {
            get { return _requestTitle; }
            set { _requestTitle = value; OnPropertyChanged("RequestTitle"); }
        }

        private string _requestDescription;
        public string RequestDescription
        {
            get { return _requestDescription; }
            set { _requestDescription = value; OnPropertyChanged("RequestDescription"); }
        }

        private RelayCommand _saveShareContentCommand;
        private string _storageFileName;

        public RelayCommand SaveShareContentCommand
        {
            get { return _saveShareContentCommand ?? ( _saveShareContentCommand = new RelayCommand(SaveContent) ); }
        }

    }
}
