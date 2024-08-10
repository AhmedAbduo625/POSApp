using System.Windows.Input;

namespace POSAppCore
{
    public class StartupPageViewModel : BasePageViewModel
    {

        #region PRIVATE MEMEBERS
        private StartupPageDataModel _activePage = StartupPageDataModel.SignIn;
        private bool _isLangPopupShown;
        #endregion

        #region PUBLIC PROPERTIES
        public StartupPageDataModel ActivePage
        {
            get => _activePage;
            set => SetProperty(ref _activePage, nameof(ActivePage), value);
        }
		public bool IsLangPopupShown
		{
			get => _isLangPopupShown;
			set => SetProperty(ref _isLangPopupShown, nameof(IsLangPopupShown), value);
		}
		#endregion

		#region ICONS
		public Icons LanguageIcon { get; set; } = Icons.LanguageIcon;
		#endregion

		#region COMMANDS
		public ICommand SignUpCommand { get; set; }
        public ICommand SignInCommand { get; set; }
		public ICommand UpdatesCommand { get; set; }
		public ICommand ShowLangPopupCommand { get; set; }
        public ICommand ArabicLangCommand { get; set; }
		public ICommand EnglishLangCommand { get; set; }
		

		#endregion

		#region CONSTRUCTOR
		public StartupPageViewModel()
        {
            SignUpCommand = new RelayCommand(SignUp);
            SignInCommand = new RelayCommand(SignIn);
			UpdatesCommand = new RelayCommand(Updates);
			ShowLangPopupCommand = new RelayCommand(ShowLangPopup);
			ArabicLangCommand = new RelayCommand(ArabicLang);
			EnglishLangCommand = new RelayCommand(EnglishLang);
		}
        #endregion

        #region PRIVATE METHODS

        private void SignIn(object args) => IoC.AppSettings.StartupPage = StartupPageDataModel.SignIn;
		private void SignUp(object args) => IoC.AppSettings.StartupPage = StartupPageDataModel.SignUp;
		private void Updates(object args) => IoC.AppSettings.StartupPage = StartupPageDataModel.Updates;
		private void ShowLangPopup(object args) => IsLangPopupShown ^= true;
		private void ArabicLang(object args) => IoC.AppSettings.UpdateApplicationLanguage("ar-EG");
		private void EnglishLang(object args) => IoC.AppSettings.UpdateApplicationLanguage("en-US");

		#endregion

		#region PUBLIC METHODS

		#endregion

	}
}
