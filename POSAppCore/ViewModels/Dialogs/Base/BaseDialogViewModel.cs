

using System.Windows.Input;

namespace POSAppCore
{
	public class BaseDialogViewModel : BaseViewModel
	{
		#region PUBLIC PROPERTIES
		public string Title { get; set; }
		public bool CanResize { get; set; } = true;
		public double WindowMinimumWidth { get; set; } = 200;
		public double WindowMinimumHeight { get; set; } = 100;

		#endregion

		public ICommand CloseCommand { get; set; }

		#region CONSTUCTOR
		public BaseDialogViewModel()
		{

		}
		#endregion
	}
}
