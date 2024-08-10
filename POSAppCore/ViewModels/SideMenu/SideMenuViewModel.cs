
using System.Windows.Input;

namespace POSAppCore
{
	public class SideMenuViewModel : BaseViewModel
	{
		#region ICONS
		public Icons ExpandAndCollapseIcon { get; set; } = Icons.ExpandAndCollapseIcon;
		public Icons AppLogoIcon { get; set; } = Icons.AppLogoIcon;
		#endregion

		public List<SideMenuItemViewModel> Buttons { get; set; }

		#region COMMANDS
		public ICommand OpenAndCloseMenuCommand { get; set; }
		#endregion

		#region CONSTRUCOTR
		public SideMenuViewModel()
		{
			Buttons = new List<SideMenuItemViewModel>()
			{
				new SideMenuItemViewModel()
				{
					ButtonContent = "Home",
					ButtonIcon = Icons.HomeIcon,
					Children = new List<SideMenuItemViewModel>
					{
						new SideMenuItemViewModel()
						{
							ButtonContent= "Home",
							ButtonChildClickedCommand = new RelayCommand(args => IoC.AppSettings.MainPagePage = MainPageDataModel.Home)
						}
					},
					ButtonClickedCommand = new RelayCommand(args => IoC.AppSettings.MainPagePage = MainPageDataModel.Home)
				},
				new SideMenuItemViewModel()
				{
					ButtonContent = "Orders",
					ButtonIcon = Icons.CartIcon,
					Children = new List<SideMenuItemViewModel>
					{
						new SideMenuItemViewModel()
						{
							ButtonContent = "New Order"
						},
						new SideMenuItemViewModel()
						{
							ButtonContent = "Lobby",
							//ButtonChildClickedCommand = new RelayCommand(args => IoC.AppSettings.MainPagePage = MainPageDataModel.Patients)
						},
						new SideMenuItemViewModel()
						{
							ButtonContent = "Delivery",
							//ButtonChildClickedCommand = new RelayCommand(args => IoC.AppSettings.MainPagePage = MainPageDataModel.Patients)
						}
					}
				},

			};

			OpenAndCloseMenuCommand = new RelayCommand(OpenAndCloseMenu);
		}
		#endregion

		#region PRIVATE METHODS
		private void OpenAndCloseMenu(object args) => IoC.AppSettings.IsSideMenueVisible ^= true;
		#endregion
	}
}
