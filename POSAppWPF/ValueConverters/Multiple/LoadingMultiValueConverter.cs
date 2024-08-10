using System;
using System.Globalization;

namespace POSAppWPF
{
	public class LoadingMultiValueConverter : BaseMultiValueConverter<LoadingMultiValueConverter>
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			bool loadingLogo = (bool)values[0];
			bool loadingProcess = (bool)values[1];

			return loadingLogo || loadingProcess;
		}

		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
