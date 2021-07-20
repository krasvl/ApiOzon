namespace ApiOzon.Data.LogLevelRepository
{
    public interface ILogLevelRepository
    {
        void GetLevelAsync(string levelName);
    }
}