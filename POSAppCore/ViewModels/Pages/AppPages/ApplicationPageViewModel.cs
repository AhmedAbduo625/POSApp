using System.Windows.Input;

namespace POSAppCore
{
	public class ApplicationPageViewModel : BasePageViewModel
	{
		#region PRIVATE MEMEBERS
		private MainPageDataModel _activePage = MainPageDataModel.Home;
		#endregion

		#region PUBLIC PROPERTIES
		public MainPageDataModel ActivePage
		{
			get => _activePage;
			set => SetProperty(ref _activePage, nameof(ActivePage), value);
		}
		
		#endregion

		#region ICONS

		#endregion

		#region COMMANDS

		
        #endregion

        #region CONSTRUCTOR
        public ApplicationPageViewModel()
		{
			
		}
		#endregion

		#region PRIVATE METHODS


		#endregion

		#region PUBLIC METHODS

		#endregion
	}
}
