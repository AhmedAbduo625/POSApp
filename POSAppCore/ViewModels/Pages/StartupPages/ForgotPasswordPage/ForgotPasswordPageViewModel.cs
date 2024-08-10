

using System.Windows.Input;

namespace POSAppCore
{
	public class ForgotPasswordPageViewModel : BasePageViewModel
	{
		#region PRIVATE MEMEBERS

		#endregion

		#region PUBLIC PROPERTIES

		#endregion

		#region ICONS

		#endregion

		#region COMMANDS
		//public ICommand ForgotPasswordCommand { get; set; }
		//public ICommand LoginCommand { get; set; }
		#endregion

		#region CONSTRUCTOR
		public ForgotPasswordPageViewModel()
		{
			//ForgotPasswordCommand = new RelayCommand(ForgotPassword);
			//LoginCommand = new RelayCommand(Login);
			PageLogoPath = new Uri("pack://application:,,,/../../../Assets/Svgs/forgot-password-page.svg");
		}
		#endregion

		#region PRIVATE METHODS
		//private void ForgotPassword(object args) => IoC.AppSettings.StartupPage = StartupPageDataModel.ForgotPassword;
		//private void Login(object args) => IoC.AppSettings.ApplicationPage = ApplicationPageDataModel.Main;
		#endregion

		#region PUBLIC METHODS

		#endregion
	}
}
