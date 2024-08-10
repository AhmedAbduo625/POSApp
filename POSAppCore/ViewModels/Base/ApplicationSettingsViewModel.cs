
namespace POSAppCore
{
    public class ApplicationSettingsViewModel : BaseViewModel
    {
        #region PRIVATE MEMEBERS

        private ApplicationPageDataModel _applicationPage = ApplicationPageDataModel.Startup;
        private StartupPageDataModel _startupPage = StartupPageDataModel.SignIn;
        private MainPageDataModel _mainPagePage = MainPageDataModel.NewOrder;
        private bool _isSideMenueVisible = false;
        private double _windowMinimumWidth = 850;
        private double _windowMinimumHeight = 580;
		#endregion

		#region PUBLIC PROPERTIES

		public ApplicationPageDataModel ApplicationPage
        {
            get => _applicationPage;
            set
            {
                SetProperty(ref _applicationPage, nameof(ApplicationPage), value);
            }
        }
        public StartupPageDataModel StartupPage
        {
            get => _startupPage;
            set
            {
                SetProperty(ref _startupPage, nameof(StartupPage), value);
            }
        }
        public MainPageDataModel MainPagePage
        {
            get => _mainPagePage;
            set
            {
                SetProperty(ref _mainPagePage, nameof(MainPagePage), value);
            }
        }
        public bool IsSideMenueVisible
        {
            get => _isSideMenueVisible;
            set
            {
                SetProperty(ref _isSideMenueVisible, nameof(IsSideMenueVisible), value);
            }
        }
		

		public double WindowMinimumWidth
		{
			get => _windowMinimumWidth;
			set
			{
				SetProperty(ref _windowMinimumWidth, nameof(WindowMinimumWidth), value);
			}
		}
		public double WindowMinimumHeight
		{
			get => _windowMinimumHeight;
			set
			{
				SetProperty(ref _windowMinimumHeight, nameof(WindowMinimumHeight), value);
			}
		}


		/* User Settings */
		public string Token { get; set; }

        #endregion

        #region PUBLIC METHODS

        public void UpdateApplicationLanguage(string language) => IoC.LocalizationManger.Manage(language);

        #endregion
    }
}
