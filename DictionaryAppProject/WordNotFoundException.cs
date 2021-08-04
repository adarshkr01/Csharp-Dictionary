using System;

namespace DictionaryAppProject
{
    public class WordNotFoundException : Exception
    {
        public WordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
