
namespace POSAppCore
{
    public sealed class Locator
    {
        public static Locator Intsnace { get; set; } = new Locator();
        public ApplicationSettingsViewModel AppSettings => IoC.AppSettings;
		public KeyboardNumbersViewModel KeyboardNumbersManager => IoC.KeyboardNumbersManager;
	}
}
