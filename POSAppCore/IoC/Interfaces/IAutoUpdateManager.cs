namespace POSAppCore
{
    public interface IAutoUpdateManager
    {
        Task InitRepositoryAsync();
        Task<bool> CheckForUpdateAsync();
        Task UpdateAppAsync();
    }
}
