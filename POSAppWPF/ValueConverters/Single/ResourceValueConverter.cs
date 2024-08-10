using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
    public class ResourceValueConverter : BaseValueConverter<ResourceValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Application.Current.FindResource(value.ToString());

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
