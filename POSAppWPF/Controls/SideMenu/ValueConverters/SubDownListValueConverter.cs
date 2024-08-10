using System.Globalization;
using System;

namespace POSAppWPF
{
	public class SubDownListValueConverter : BaseMultiValueConverter<SubDownListValueConverter>
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var subMenuIsOpen = (bool)values[0];
			var sideMenuIsVisible = (bool)values[1];
			return subMenuIsOpen && sideMenuIsVisible;
		}

		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
