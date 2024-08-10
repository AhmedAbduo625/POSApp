
using POSAppCore;
using Squirrel;
using System;
using System.Threading.Tasks;

namespace POSAppWPF
{
    public class AutoUpdateManager : IAutoUpdateManager
    {
        UpdateManager UpdateManager;
        public string RepositoryPath { get => "https://github.com/AhmedAbduo625/POSApp"; }

        public async Task<bool> CheckForUpdateAsync()
        {
            var updateInfo = await UpdateManager.CheckForUpdate();
            return updateInfo.ReleasesToApply.Count > 0 ? true : false;
        }
        public async Task InitRepositoryAsync() => UpdateManager = await UpdateManager.GitHubUpdateManager(RepositoryPath);
        public async Task UpdateAppAsync() => await UpdateManager.UpdateApp();
    }
}
