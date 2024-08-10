using System.Windows;


namespace POSAppWPF
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
		#region PRIVATE MEMEBERS

		private DialogWindowViewModel? _viewModel;

		#endregion

		#region PUBLIC PROPERTIES

		public DialogWindowViewModel? ViewModel
		{
			get => _viewModel;
			set
			{
				if (_viewModel is null)
				{
					_viewModel = value;
					DataContext = value;
				}
			}
		}

		#endregion

		public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
