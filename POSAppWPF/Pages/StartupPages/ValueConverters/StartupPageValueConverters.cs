
using POSAppCore;
using System.Globalization;
using System;

namespace POSAppWPF
{
    public class StartupPageValueConverters : BaseValueConverter<StartupPageValueConverters>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((StartupPageDataModel)value)
			{
				case StartupPageDataModel.SignIn: return new SigninPage();
				case StartupPageDataModel.Updates: return new SystemUpdatePage();
				case StartupPageDataModel.ForgotPassword: return new ForgotPassordPage();

				//
				//case StartupPageDataModel.ForgotPassword: return new ForgotPasswordPageView();
				//case StartupPageDataModel.VerificationCode: return new VerificationCodePageView();
				//case StartupPageDataModel.ReEnterPassword: return new ReEnterPasswordPageView();
				default: return null;
			}
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
