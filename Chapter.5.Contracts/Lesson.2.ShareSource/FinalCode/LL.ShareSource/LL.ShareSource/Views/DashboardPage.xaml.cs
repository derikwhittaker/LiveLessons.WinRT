using System.Diagnostics;
using System.Threading.Tasks;
using LL.ShareSource.Data;

using System;
using System.Collections.Generic;
using LL.ShareSource.ViewModels;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace LL.ShareSource.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class DashbaordPage : LL.ShareSource.Common.LayoutAwarePage
    {
        public DashbaordPage()
        {
            this.InitializeComponent();
            DataContext = new DashboardViewModel();

            SetupDataTransfer();
        }

        private DataTransferManager _dataTransferManager;
        private void SetupDataTransfer()
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();

            _dataTransferManager.DataRequested +=  OnDataRequested;
            _dataTransferManager.TargetApplicationChosen += OnTargetApplicationChosen;            
        }

        void OnTargetApplicationChosen(DataTransferManager sender, TargetApplicationChosenEventArgs args)
        {
            
        }

        private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var vm = ((DashboardViewModel) DataContext);
            
            if ( vm.SelectedItem == null )
            {
                args.Request.FailWithDisplayText("Nothing was selected to shared.");    
            }
            else
            {
                try
                {
                    //var deferral = args.Request.GetDeferral();
                    
                    var dataPackage = args.Request.Data;
                    var propertySet = dataPackage.Properties;
                    propertySet.Title = vm.SelectedItem.Name;
                    propertySet.Description = vm.SelectedItem.ShortDescription;
                    

                    // sharing text
                    ShareText(dataPackage, vm.SelectedItem.Name);
                        
                    // sharing url
                    //ShareUrl(dataPackage, "http://www.devlicio.us");
                    
                    // share file
                    //await ShareImageAsFileAsync(vm, dataPackage, propertySet);

                    //deferral.Complete();
                    
                }
                catch( Exception e)
                {
                    var message = string.Format("Failed during a share {0}", e.Message);
                    args.Request.FailWithDisplayText(message);
                }
            }
        }

        private void ShareText(DataPackage dataPackage, string text)
        {
            dataPackage.SetText(text);
        }

        private void ShareUrl(DataPackage dataPackage, string url)
        {
            dataPackage.SetUri(new Uri(url));
        }

        private async Task ShareImageAsFileAsync(DashboardViewModel vm, DataPackage dataPackage, DataPackagePropertySet propertySet)
        {
            var cleanFileName = vm.SelectedItem.ImagePath.Replace(@"../Images/", "");

            var packageLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var imagesFolder = await packageLocation.GetFolderAsync("Images");
            var imageToShare = await imagesFolder.GetFileAsync(cleanFileName);
            var imageStreamRef = RandomAccessStreamReference.CreateFromFile(imageToShare);
            
            dataPackage.SetStorageItems(new List<IStorageItem> {imageToShare});
            propertySet.Thumbnail = imageStreamRef;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            this.DefaultViewModel["Items"] = sampleDataGroups;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
