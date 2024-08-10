using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace POSAppWPF
{
    public abstract class BaseMultiValueConverter<Child> : MarkupExtension, IMultiValueConverter where Child : class, new()
    {
        private static Child _converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter is null)
                _converter = new Child();

            return _converter;
        }

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
    }
}
