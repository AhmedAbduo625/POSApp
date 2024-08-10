using System;
using System.Globalization;
using System.Windows;

namespace POSAppWPF
{
	public class BooleanToResourceValueConverter : BaseValueConverter<BooleanToResourceValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var parameters = ((string)parameter).Split('|');
			return (bool)value ? Application.Current.FindResource(parameters[0]) : Application.Current.FindResource(parameters[1]);
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
