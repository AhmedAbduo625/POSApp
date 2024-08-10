using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
    class BooleanToHiddenVisibilityValueConverter : BaseValueConverter<BooleanToHiddenVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is null)
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
            else
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
