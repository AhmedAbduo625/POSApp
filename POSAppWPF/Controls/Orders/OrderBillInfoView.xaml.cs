using POSAppCore;
using System.Windows.Controls;

namespace POSAppWPF
{
	/// <summary>
	/// Interaction logic for OrderBillInfoView.xaml
	/// </summary>
	public partial class OrderBillInfoView : UserControl
	{
		public OrderBillInfoView()
		{
			InitializeComponent();
			this.DataContext = new OrderBillInfoViewModel();
		}
	}
}
