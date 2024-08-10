using POSAppCore;
using System;
using System.Globalization;

namespace POSAppWPF
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPageDataModel)value)
            {
                case ApplicationPageDataModel.Startup: return new StartupPageView();
                case ApplicationPageDataModel.Main: return new ApplicationPage();
                default: return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
