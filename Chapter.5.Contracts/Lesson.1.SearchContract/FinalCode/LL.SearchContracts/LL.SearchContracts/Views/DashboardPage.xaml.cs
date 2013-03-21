using LL.SearchContracts.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LL.SearchContracts.DataModel;
using LL.SearchContracts.ViewModels;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace LL.SearchContracts.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class DashboardPage : LL.SearchContracts.Common.LayoutAwarePage
    {
        public DashboardPage()
        {
            this.InitializeComponent();
            DataContext = new DashboardViewModel();
            SetupRealtimeSearchEvents();
        }

        private SearchPane _currentSearchPane;
        private void SetupRealtimeSearchEvents()
        {

            _currentSearchPane = SearchPane.GetForCurrentView();
            _currentSearchPane.QueryChanged += SearchPaneQueryChanged;
            _currentSearchPane.SuggestionsRequested += SearchPaneSuggestionsRequested;

            _currentSearchPane.PlaceholderText = "Search for Content";

        }

        void SearchPaneSuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            var vm = ((DashboardViewModel)DataContext);
            var suggestions = vm.SearchSuggestiongsAsync(args.QueryText);

            args.Request.SearchSuggestionCollection.AppendQuerySuggestions(suggestions.Result);
        }

        void SearchPaneQueryChanged(SearchPane sender, SearchPaneQueryChangedEventArgs args)
        {
            var vm = ((DashboardViewModel) DataContext);
            vm.PerformSearchAsync(args.QueryText);
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
            // removed contents as they are not needed
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var selectedItemId = ((SearchItemModel) e.ClickedItem).Id;           
            Frame.Navigate(typeof(DetailsPage), selectedItemId);            
        }
    }
}
