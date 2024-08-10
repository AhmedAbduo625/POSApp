
using System.Windows.Input;

namespace POSAppCore
{
	public class SsytemUpdatePageViewModel : BasePageViewModel
	{
        #region PRIVATE MEMEBERS
        private bool _isLoading;
        private bool _isUpdateEnabled;
        private bool _onUpdatingMode = false;
        #endregion

        #region PUBLIC PROPERTIES

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, nameof(IsLoading), value);
        }
        public bool OnUpdatingMode
        {
            get => _onUpdatingMode;
            set => SetProperty(ref _onUpdatingMode, nameof(OnUpdatingMode), value);
        }
        public bool IsUpdateEnabled
        {
            get => _isUpdateEnabled;
            set => SetProperty(ref _isUpdateEnabled, nameof(IsUpdateEnabled), value);
        }

        #endregion

        #region ICONS

        #endregion

        #region COMMANDS
        public ICommand CheckForUpdatesCommand { get; set; }
        public ICommand UpdateAppCommand { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SsytemUpdatePageViewModel()
		{
			PageLogoPath = new Uri("pack://application:,,,/../../../Assets/Svgs/update-page-logo.svg");
            CheckForUpdatesCommand = new RelayCommand(async (args) => await CheckForUpdates(args));
            UpdateAppCommand = new RelayCommand(async (args) => await UpdateApp(args));
            InitUpdatesRepository();
        }
        #endregion

        #region PRIVATE METHODS
        private async Task InitUpdatesRepository()
        {
            await RunCommand(() => this.IsLoading, async () =>
            {
                //await Task.Delay(2000);
                await IoC.AutoUpdateManager.InitRepositoryAsync();
                IsUpdateEnabled = true;
            });
        }
        private async Task CheckForUpdates(object args)
        {
            bool HasUpdates = false;

            await RunCommand(() => this.IsLoading, async () =>
            {
                await Task.Delay(2000);
                //HasUpdates = false;
                HasUpdates = await IoC.AutoUpdateManager.CheckForUpdateAsync();
                if (HasUpdates)
                {
                    IoC.UI.ShowCustomMessageBoxDialog(new CustomMessageBoxDialogViewModel() { Message = "New update is available" });
                    OnUpdatingMode = true;
                }
                else
                {
                    IoC.UI.ShowCustomMessageBoxDialog(new CustomMessageBoxDialogViewModel() { Message = "Your application is up to date" });
                }
            });

        }
        private async Task UpdateApp(object args)
        {
            await RunCommand(() => this.IsLoading, async () =>
            {
                //await Task.Delay(2000);
                await IoC.AutoUpdateManager.UpdateAppAsync();
                IoC.UI.ShowCustomMessageBoxDialog(new CustomMessageBoxDialogViewModel() { Message = "Application is updated successfully" });
                OnUpdatingMode = false;
            });
        }

        #endregion

        #region PUBLIC METHODS

        #endregion
    }
}
