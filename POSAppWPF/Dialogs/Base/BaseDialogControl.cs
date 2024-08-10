using POSAppCore;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace POSAppWPF
{
    public class BaseDialogControl : UserControl
	{
		#region PRIVATE MEMBERS

		private DialogWindow mDialogWindow;

		#endregion

		#region CONSTRUCTOR
		public BaseDialogControl()
		{
			mDialogWindow = new DialogWindow();
			mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);
		}
		#endregion

		#region METHODS
		public Task ShowControl<T>(T viewModel) where T : BaseDialogViewModel
		{
			var tcs = new TaskCompletionSource<bool>();

			Application.Current.Dispatcher.Invoke(() =>
			{
				/* CONTROL SECTION */
				this.DataContext = viewModel;

				/* WINDOW SECTION */
				mDialogWindow.ViewModel.WindowMinimumWidth = viewModel.WindowMinimumWidth;
				mDialogWindow.ViewModel.WindowMinimumHeight = viewModel.WindowMinimumHeight;

				mDialogWindow.ViewModel.Title = viewModel.Title;
				mDialogWindow.ViewModel.CanResize = viewModel.CanResize;

				viewModel.CloseCommand = new RelayCommand((args) =>
				{
					mDialogWindow.Close();
				});

				mDialogWindow.Owner = Application.Current.MainWindow;

				mDialogWindow.Content = this;				
				mDialogWindow.ShowDialog();
			});

			return tcs.Task;
		}
		#endregion
	}
}
