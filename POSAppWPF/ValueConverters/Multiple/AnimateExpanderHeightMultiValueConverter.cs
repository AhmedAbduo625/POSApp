
using System;
using System.Globalization;

namespace POSAppWPF
{
    public class AnimateExpanderHeightMultiValueConverter : BaseMultiValueConverter<AnimateExpanderHeightMultiValueConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for(int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                    result *= (double)values[i];
            }
            return result;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
