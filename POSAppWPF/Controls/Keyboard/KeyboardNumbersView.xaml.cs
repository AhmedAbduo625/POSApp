using POSAppCore;
using System.Windows.Controls;

namespace POSAppWPF
{
	/// <summary>
	/// Interaction logic for KeyboardNumbersView.xaml
	/// </summary>
	public partial class KeyboardNumbersView : UserControl
	{
		public KeyboardNumbersView()
		{
			InitializeComponent();
			DataContext = IoC.KeyboardNumbersManager;
		}
	}
}
