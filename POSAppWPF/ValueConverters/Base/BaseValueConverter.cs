using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System;

namespace POSAppWPF
{
    public abstract class BaseValueConverter<Child> : MarkupExtension, IValueConverter where Child : class, new()
    {
        private static Child _converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter is null)
                _converter = new Child();

            return _converter;
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
