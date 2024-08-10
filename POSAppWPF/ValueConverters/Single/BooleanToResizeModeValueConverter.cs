using System.Globalization;
using System.Windows;
using System;

namespace POSAppWPF
{
	public class BooleanToResizeModeValueConverter : BaseValueConverter<BooleanToResizeModeValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return ResizeMode.CanResize;
			else
				return ResizeMode.NoResize;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
