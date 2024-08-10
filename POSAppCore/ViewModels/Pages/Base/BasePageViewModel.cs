
namespace POSAppCore
{
    public class BasePageViewModel : BaseViewModel
    {
        private bool _logoIsLoading = true;

        #region PUBLIC MEMBERS
        public Uri PageLogoPath { get; set; }
        public bool LogoIsLoading
		{
            get => _logoIsLoading;
            set => SetProperty(ref _logoIsLoading, nameof(LogoIsLoading), value);
        }
        #endregion
    }
}
