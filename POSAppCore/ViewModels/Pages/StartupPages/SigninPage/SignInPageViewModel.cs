using System.Windows.Input;

namespace POSAppCore
{
    public class SignInPageViewModel : BasePageViewModel
    {
		#region PRIVATE MEMEBERS

		private string _email;
		private bool _isLoading;

		#endregion

		#region PUBLIC PROPERTIES
		public string Email
		{
			get => _email;
			set => SetProperty(ref _email, nameof(Email), value);
		}
		public bool IsLoading
		{
			get => _isLoading;
			set => SetProperty(ref _isLoading, nameof(IsLoading), value);
		}
		#endregion

		#region ICONS

		#endregion

		#region COMMANDS
		public ICommand ForgotPasswordCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SignInPageViewModel()
        {
			PageLogoPath = new Uri("pack://application:,,,/../../../Assets/Svgs/sign-page-logo.svg");
            ForgotPasswordCommand = new RelayCommand(ForgotPassword);
			LoginCommand = new RelayCommand(async (args) => await Login(args));
        }
        #endregion

        #region PRIVATE METHODS
        private void ForgotPassword(object args) => IoC.AppSettings.StartupPage = StartupPageDataModel.ForgotPassword;
		private async Task Login(object args)
		{
			await RunCommand(() => this.IsLoading, async () =>
			{
				//(args as IMappingPassword).SecurePassword.UnsecureString()
				var token = await IoC.AuthenticationService.Login("extra@mms.ps", "1700900600");

				if (token != null)
				{
					IoC.AppSettings.Token = token;
					IoC.AppSettings.ApplicationPage = ApplicationPageDataModel.Main;
					//IoC.AppSettings.WindowMinimumWidth = 1200;
					//IoC.AppSettings.WindowMinimumHeight = 700;

				}
				else
				{
					//Show error popup message...

				}
			});
		}

		#endregion

		#region PUBLIC METHODS

		#endregion

	}
}
