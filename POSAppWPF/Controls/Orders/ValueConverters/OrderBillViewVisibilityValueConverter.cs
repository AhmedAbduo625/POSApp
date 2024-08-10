
using POSAppCore;
using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
    class OrderBillViewVisibilityValueConverter : BaseValueConverter<OrderBillViewVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OrderDetailsDataModel commingParameter;
            Enum.TryParse((string)parameter, out commingParameter);

            if ((OrderDetailsDataModel)value == commingParameter)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
