using System.Threading.Tasks;

namespace DictionaryAppProject
{
    class Program
    {
        async static Task Main(string[] args)
        {
            EnglishValidator validator = new EnglishValidator();
            ConsoleLogger logger = new ConsoleLogger();
            APIRequests apiRequests = new APIRequests();

            APIRunner apiRunner = new APIRunner(apiRequests, logger);

            DictionaryProcessor dictionaryProcessor = new DictionaryProcessor(validator, logger, apiRunner);
            await dictionaryProcessor.Process();
        }
    }
}
