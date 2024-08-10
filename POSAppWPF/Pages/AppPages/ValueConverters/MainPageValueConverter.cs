using POSAppCore;
using System.Globalization;
using System;

namespace POSAppWPF
{
	public class MainPageValueConverter : BaseValueConverter<MainPageValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((MainPageDataModel)value)
			{
				case MainPageDataModel.NewOrder: return new NewOrderPage();
				//case MainPageDataModel.Patients: return new PatientsPageView();
				default: return null;
			}
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
