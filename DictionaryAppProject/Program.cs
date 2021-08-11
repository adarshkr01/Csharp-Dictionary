using System.Threading.Tasks;

namespace DictionaryAppProject
{
    class Program
    {
        async static Task Main(string[] args)
        {
            EnglishValidator validator = new EnglishValidator();
            ConsoleLogger logger = new ConsoleLogger();

            APIRunner apiRunner = new APIRunner(logger);

            DictionaryProcessor dictionaryProcessor = new DictionaryProcessor(validator, logger, apiRunner);
            await dictionaryProcessor.Process();
        }
    }
}
