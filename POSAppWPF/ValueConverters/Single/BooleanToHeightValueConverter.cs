using System.Globalization;
using System;

namespace POSAppWPF
{
	public class BooleanToHeightValueConverter : BaseValueConverter<BooleanToHeightValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var parameters = ((string)parameter).Split('|');

			if ((bool)value)
				return double.Parse(parameters[0]);
			else
				return double.Parse(parameters[1]);
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
