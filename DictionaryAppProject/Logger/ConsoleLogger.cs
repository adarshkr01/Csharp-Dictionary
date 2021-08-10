using System;

namespace DictionaryAppProject
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("\n" + message);
        }
        public void LogError(string message)
        {
            Console.WriteLine("\nError:\n" + message);
        }

    }
}
