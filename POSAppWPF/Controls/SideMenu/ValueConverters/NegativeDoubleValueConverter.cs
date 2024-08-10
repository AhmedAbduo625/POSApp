using System.Globalization;
using System;

namespace POSAppWPF
{
	public class NegativeDoubleValueConverter : BaseValueConverter<NegativeDoubleValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (double)value * -1;

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
