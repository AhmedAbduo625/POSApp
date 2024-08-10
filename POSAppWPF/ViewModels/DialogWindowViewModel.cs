using System.Windows.Controls;
using System.Windows;

namespace POSAppWPF
{
    public class DialogWindowViewModel : WindowViewModel
	{
		#region PRIVATE MEMEBERS

		#endregion

		#region PUBLIC PROPERTIES
		public string? Title { get; set; }
		public Control? Content { get; set; }

		public double WindowMinimumWidth { get; set; } = 1500;
		public double WindowMinimumHeight { get; set; } = 1000;


		#endregion

		#region CONSTRUCTOR

		public DialogWindowViewModel(Window window) : base(window)
		{

		}

		#endregion
	}
}
