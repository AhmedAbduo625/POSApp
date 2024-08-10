
namespace POSAppCore
{
	public class SideMenuItemDesignModel : SideMenuItemViewModel
	{
		public static SideMenuItemDesignModel Instance => new SideMenuItemDesignModel();

		public SideMenuItemDesignModel()
		{
			ButtonContent = "Patients";
			ButtonIcon = Icons.UsersIcon;
			Children = new List<SideMenuItemViewModel>()
			{
				new SideMenuItemViewModel() {ButtonContent = "New Patient"},
				new SideMenuItemViewModel() {ButtonContent = "Display Pateints"},
			};
		}
	}
}
