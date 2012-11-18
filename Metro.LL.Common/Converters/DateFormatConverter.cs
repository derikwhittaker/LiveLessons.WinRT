using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Metro.LL.Common.Converters
{
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            if (value == null) { return ""; }
            DateTime asDateTime;

            if (DateTime.TryParse(value.ToString(), out asDateTime))
            {
                if ( parameter != null && !string.IsNullOrEmpty(parameter.ToString()))
                {
                    return asDateTime.ToString(parameter.ToString());
                }

                return asDateTime.ToString("MM/dd/yyyy");
            }
            
            return value.ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
