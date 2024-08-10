
using System.Windows.Input;

namespace POSAppCore
{
	public class CustomMessageBoxDialogViewModel : BaseDialogViewModel
	{
		#region PUBLIC PROPERTIES
		public string Message { get; set; }
		public string OkText { get; set; }
        public string RejectText { get; set; }
        #endregion

        #region COMMANDS
        public ICommand OkCommand { get; set; }
		public ICommand RejectCommand { get; set; }
		#endregion

		#region CONSTRUCTOR
		public CustomMessageBoxDialogViewModel()
		{

		}
		#endregion
	}
}
