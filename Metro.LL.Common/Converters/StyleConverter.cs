using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Metro.LL.Common.Converters
{
    public class StyleConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            if ( value == null || string.IsNullOrEmpty(value.ToString() )) { return null; }

            var foundStyle = Application.Current.Resources[value] as Style;

            return foundStyle;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
