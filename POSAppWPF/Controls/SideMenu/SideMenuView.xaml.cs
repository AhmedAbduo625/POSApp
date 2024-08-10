
using POSAppCore;
using System.Windows.Controls;


namespace POSAppWPF
{
	/// <summary>
	/// Interaction logic for SideMenuView.xaml
	/// </summary>
	public partial class SideMenuView : UserControl
	{
		public SideMenuView()
		{
			InitializeComponent();
			DataContext = new SideMenuViewModel();
		}
	}
}
