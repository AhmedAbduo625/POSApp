

using System.Windows.Input;

namespace POSAppCore
{
	public class SideMenuItemViewModel : BaseViewModel
	{
		#region PRIVATE MEMEBERS

		private bool _isSubDownListOpen = false;
		private bool _isLeftItemHover = false;
		private bool _isRightItemHover = false;

		#endregion

		#region PUBLIC PROPERTIES

		public string ButtonContent { get; set; }
		public Icons ButtonIcon { get; set; }
		public int ButtonPosition { get; set; }
		public List<SideMenuItemViewModel> Children { get; set; }

		public bool IsSubDownListOpen
		{
			get => _isSubDownListOpen;
			set => SetProperty(ref _isSubDownListOpen, nameof(IsSubDownListOpen), value);
		}

		public bool IsHover => IsLeftItemHover || IsRightItemHover;
		public bool IsLeftItemHover
		{
			get => _isLeftItemHover;
			set => SetProperty(ref _isLeftItemHover, nameof(IsLeftItemHover), value);
		}
		public bool IsRightItemHover
		{
			get => _isRightItemHover;
			set => SetProperty(ref _isRightItemHover, nameof(IsRightItemHover), value);
		}

		public bool HasSingleChildren { get => Children.Count == 1; }

		#endregion

		#region COMMANDS
		public ICommand ButtonClickedCommand { get; set; }
		public ICommand ButtonChildClickedCommand { get; set; }
		#endregion

		#region CONSTRUCTOR
		public SideMenuItemViewModel()
		{
			ButtonClickedCommand = new RelayCommand(ButtonClicked);
		}
		#endregion

		#region PRIVATE METHODS
		private void ButtonClicked(object args)
		{
			if (IoC.AppSettings.IsSideMenueVisible)
				IsSubDownListOpen ^= true;
		}
		#endregion
	}
}
