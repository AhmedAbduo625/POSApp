using POSAppCore;
using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
    public class ApplicationPageToCollapsedVisibilityValueConverter : BaseValueConverter<ApplicationPageToCollapsedVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ApplicationPageDataModel)value == ApplicationPageDataModel.Startup ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
