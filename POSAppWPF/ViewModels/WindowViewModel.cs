using POSAppCore;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Effects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POSAppWPF
{
    public class WindowViewModel : BaseViewModel
    {
        #region PRIVATE MEMEBERS

        private Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadius = 10;
		private bool _isUserSettingsOpened = false;

		#endregion

		#region PUBLIC PROPERTIES

		public bool IsOverlay { get; set; } = false;
        public bool CanResize { get; set; } = true;



        public bool Borderless { get => _window.WindowState == WindowState.Maximized; }
        public int ResizeBorder { get => Borderless ? 0 : 6; }
        public Thickness ResizeBorderThickness { get => new Thickness(ResizeBorder + OuterMarginSize); }

        public int OuterMarginSize { get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize; }
        public Thickness OuterMarginSizeThickness { get => new Thickness(OuterMarginSize); }

        public int WindowRadius { get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius; }
        public CornerRadius WindowCornerRadius { get => new CornerRadius(WindowRadius); }

        public int CaptionHeight { get; set; } = 36;
        public GridLength CaptionHeightGridLength { get => new GridLength(CaptionHeight + ResizeBorder); }

        public string MaximizeButtonTooltip { get => _window.WindowState == WindowState.Maximized ? "Restore Down" : "Maximize"; }

		public bool IsUserSettingsOpened
		{
			get => _isUserSettingsOpened;
			set => SetProperty(ref _isUserSettingsOpened, nameof(IsUserSettingsOpened), value);
		}

		#endregion

		#region ICONS

		public Icons AppLogoIcon { get; set; } = Icons.AppLogoIcon;
        public Icons CloseIcon { get; set; } = Icons.CloseIcon;
        public Icons MaximizeIcon { get; set; } = Icons.MaximizeIcon;
        public Icons MinimizeIcon { get; set; } = Icons.MinimizeIcon;

        #endregion

        #region COMMANDS
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
		public ICommand OpenUserSettingsCommand { get; set; }
		public ICommand ProfileCommand { get; set; }
		public ICommand LogOutCommand { get; set; }

		#endregion

		#region CONSTRUCTOR

		public WindowViewModel(Window window)
        {
            _window = window;
            _window.StateChanged += (sender, e) =>
            {
                /*NOTIFY UI TO UPDATE ITS VLAUES*/
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(MaximizeButtonTooltip));
            };
            _window.Deactivated += (sender, e) =>
            {
                IsOverlay = true;
                _window.Effect = new BlurEffect() { Radius = 3 };
                OnPropertyChanged(nameof(IsOverlay));
            };
            _window.Activated += (sender, e) =>
            {
                IsOverlay = false;
                _window.Effect = null;
                OnPropertyChanged(nameof(IsOverlay));
            };

            /*Fix window resize issue*/
            _window.SourceInitialized += (sender, e) => new MaximizedWindow(window);

            MinimizeCommand = new RelayCommand((args) => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand((args) =>
            {
                //Note: This line solve the problem when we use size to content to be equal width and height just we need to restore it back to be manual to make maximizing process works fine
                _window.SizeToContent = SizeToContent.Manual;

                _window.WindowState ^= WindowState.Maximized;

			});
            CloseCommand = new RelayCommand((args) => _window.Close());
            MenuCommand = new RelayCommand((args) => SystemCommands.ShowSystemMenu(window, GetMosuePosition()));
			OpenUserSettingsCommand = new RelayCommand(OpenUserSettings);
			ProfileCommand = new RelayCommand(Profile);
			LogOutCommand = new RelayCommand(LogOut);
		}

		#endregion

		#region PRIVATE METHODS

		private void OpenUserSettings(object args)
		{
			IsUserSettingsOpened ^= true;
		}
		private void Profile(object args)
		{

		}
		private void LogOut(object args)
        {
			//IoC.AppSettings.WindowMinimumWidth = 850;
			//IoC.AppSettings.WindowMinimumHeight = 580;
			IoC.AppSettings.StartupPage = StartupPageDataModel.SignIn;
			IoC.AppSettings.ApplicationPage = ApplicationPageDataModel.Startup;
		}

		#endregion


		#region MOUSE POSITION

		private Point GetMosuePosition()
        {
            var position = Mouse.GetPosition(_window);
            return new Point(position.X + (Borderless ? 0 : _window.Left), position.Y + (Borderless ? 0 : _window.Top));
        }

        #endregion
    }
}
