using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZSTIE.Utilities
{
    class IntegerToBooleanConverter : IValueConverter
    {

        public object Convert(object value,
            Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value.Equals(int.Parse((string)parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return int.Parse((string)parameter);
            else
                return Binding.DoNothing;
        }
    }
}
