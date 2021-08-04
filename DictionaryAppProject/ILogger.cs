namespace DictionaryAppProject
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogError(string message);
    }
}
