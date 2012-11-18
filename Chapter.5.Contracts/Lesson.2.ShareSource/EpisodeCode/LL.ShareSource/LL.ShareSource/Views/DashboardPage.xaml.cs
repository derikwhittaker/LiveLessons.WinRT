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

        private DataTransferManager _dataTransfer;
        private void SetupDataTransfer()
        {
            _dataTransfer = DataTransferManager.GetForCurrentView();

            _dataTransfer.DataRequested += OnDataRequested;
            _dataTransfer.TargetApplicationChosen += (sender, args) =>
                                                         {
                                                             var appName = args.ApplicationName;
                                                         };
        }

        private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var vm = ((DashboardViewModel) DataContext);
            if ( vm.SelectedItem == null)
            {
                args.Request.FailWithDisplayText("You have not selected an item to share");
            }
            else
            {
                var deferral = args.Request.GetDeferral();
                var dataPackage = args.Request.Data;
                var propertySet = dataPackage.Properties;

                propertySet.Title = vm.SelectedItem.Name;
                propertySet.Description = vm.SelectedItem.ShortDescription;
                
                //ShareText(dataPackage, vm.SelectedItem.Name);

                //ShareUrl(dataPackage, "http://www.espn.com");

                await ShareFileAsync(vm, dataPackage, propertySet);

                deferral.Complete();
            }
        }

        private async Task ShareFileAsync(DashboardViewModel vm, DataPackage dataPackage, DataPackagePropertySet propertySet)
        {
            var cleanFileName = vm.SelectedItem.ImagePath.Replace(@"../Images/", "");

            var packageLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var imagesFolder = await packageLocation.GetFolderAsync("Images");
            var imageToShare = await imagesFolder.GetFileAsync(cleanFileName);

            dataPackage.SetStorageItems(new List<IStorageItem>{imageToShare});

            var imageStreamRef = RandomAccessStreamReference.CreateFromFile(imageToShare);
            propertySet.Thumbnail = imageStreamRef;

        }

        private void ShareUrl(DataPackage dataPackage, string url)
        {
            Uri uri = new Uri(url);
            dataPackage.SetUri(uri);
        }

        private void ShareText(DataPackage dataPackage, string name)
        {
            dataPackage.SetText(name);
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
