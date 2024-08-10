using POSAppCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("es-US");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-US");

			//Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-EG");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-EG");

			Setup();

			Current.MainWindow = new MainWindow();
			Current.MainWindow.ShowDialog();
		}

		public void Setup()
		{
			IoC.ApplicationSetup();
			IoC.Kernel.Bind<ILocalizationManager>().ToConstant(new LocaliazationManager());
			IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
            IoC.Kernel.Bind<IAutoUpdateManager>().ToConstant(new AutoUpdateManager());
        }
	}
}
