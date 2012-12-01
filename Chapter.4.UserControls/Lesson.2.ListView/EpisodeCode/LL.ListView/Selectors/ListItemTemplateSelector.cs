using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LL.ListView.DataModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LL.ListView.Selectors
{
    public class ListItemTemplateSelector : DataTemplateSelector
    {
        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var asItem = item as Item;

            if ( asItem.ItemType == 1)
            {
                return ImageLeftTemplate;
            }

            return ImageRightTemplate;
        }

        public DataTemplate ImageLeftTemplate { get; set; }
        public DataTemplate ImageRightTemplate { get; set; }
    }
}
