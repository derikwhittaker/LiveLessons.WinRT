using System;
using System.Collections.Generic;
using LL.SearchContracts.DataModel;
using LL.SearchContracts.ViewModels;
using Metro.LL.Common;
using Windows.UI.Xaml.Controls;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace LL.SearchContracts.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class SearchResultsPage : LL.SearchContracts.Common.LayoutAwarePage
    {
        public SearchResultsPage()
        {
            this.InitializeComponent();

            DataContext = new SearchResultsViewModel();
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
            // TODO: Assign a bindable collection of items to this.DefaultViewModel["Items"]
        }

        private void SearchResultsItemClicked(object sender, ItemClickEventArgs e)
        {
            var selectedItemId = ((SearchItemModel)e.ClickedItem).Id;
            var detailsPage = new DetailsPage();
            ((DetailsViewModel)detailsPage.DataContext).SetSelectedItem(selectedItemId);
            
            WindowManager.NavigateTo(detailsPage);
        }
    }
}
