using POSAppCore;
using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
    public class ApplicationPageToResizeModeValueConverter : BaseValueConverter<ApplicationPageToResizeModeValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ApplicationPageDataModel)value == ApplicationPageDataModel.Startup ? ResizeMode.NoResize : ResizeMode.CanResize;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
