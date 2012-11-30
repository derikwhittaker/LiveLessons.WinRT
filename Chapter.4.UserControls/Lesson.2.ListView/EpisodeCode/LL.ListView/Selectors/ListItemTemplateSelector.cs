using LL.ListView.DataModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LL.ListView.Selectors
{
    public class ListItemTemplateSelector : DataTemplateSelector 
    {

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var asItem = item as Item;

            if ( asItem.ItemType == 1 )
            {
                return ImageLeftTemplate;
            }
            else
            {
                return ImageRightTemplate;
            }
        }

        public DataTemplate ImageLeftTemplate { get; set; }

        public DataTemplate ImageRightTemplate { get; set; }
    }
}
