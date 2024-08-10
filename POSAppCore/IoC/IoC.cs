
using Ninject;

namespace POSAppCore
{
    public static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();
        public static ApplicationSettingsViewModel AppSettings => Kernel.Get<ApplicationSettingsViewModel>();
		public static HttpClient HttpClient => Kernel.Get<HttpClient>();
        public static RequestHandler RequestHandler => Kernel.Get<RequestHandler>();

        /* Inject All services*/
		public static AuthenticationService AuthenticationService => Kernel.Get<AuthenticationService>();
		public static MenuServices MenuServices => Kernel.Get<MenuServices>();

		public static ILocalizationManager LocalizationManger => Kernel.Get<ILocalizationManager>();
		public static IUIManager UI => Kernel.Get<IUIManager>();
        public static IAutoUpdateManager AutoUpdateManager => Kernel.Get<IAutoUpdateManager>();

        public static KeyboardNumbersViewModel KeyboardNumbersManager => Kernel.Get<KeyboardNumbersViewModel>();

        public static void ApplicationSetup()
        {
            //inject app setting object ino the container
            Kernel.Bind<ApplicationSettingsViewModel>().ToConstant(new ApplicationSettingsViewModel());
			Kernel.Bind<HttpClient>().ToConstant(new HttpClient() { BaseAddress = new Uri("https://extra.hesabate.com/") });
			Kernel.Bind<RequestHandler>().ToConstant(new RequestHandler());
			Kernel.Bind<KeyboardNumbersViewModel>().ToConstant(new KeyboardNumbersViewModel());

			/*Assign all services*/
			Kernel.Bind<AuthenticationService>().ToConstant(new AuthenticationService());
			Kernel.Bind<MenuServices>().ToConstant(new MenuServices());
		}
    }
}
