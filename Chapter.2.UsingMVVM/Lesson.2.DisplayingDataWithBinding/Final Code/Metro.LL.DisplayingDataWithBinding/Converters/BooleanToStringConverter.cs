using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Metro.LL.DisplayingDataWithBinding.Converters
{
    public class BooleanToStringConverter : IValueConverter
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }

        public BooleanToStringConverter()
        {
            TrueValue = "Yes";
            FalseValue = "No";
        }

        public object Convert(object value, string typeName, object parameter, string language)
        {
            if (value == null) { return FalseValue; }

            bool asBool;
            bool.TryParse(value.ToString(), out asBool);

            return asBool ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, string typeName, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
