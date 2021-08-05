using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public class APIRunner : IAPIRunner
    {
        private string _word = "";
        private List<Root> _parsedData;
        private IAPIRequests _apiRequests;
        private ILogger _logger;

        public APIRunner(IAPIRequests apiRequestObject, ILogger logger)
        {
            APIInitializer.InitializeClient();
            _apiRequests = apiRequestObject;
            _logger = logger;
        }

        public async Task<List<Root>> MakeCalls(string word)
        {
            List<Root> parsedData;
            if (word.Equals(_word))
            {
                parsedData = _parsedData;
            }
            else
            {
                parsedData = await _apiRequests.GetData(word);
            }
            return parsedData;
        }

        public async Task GetMeanings(string word)
        {
            var parsedData = await MakeCalls(word);

            _logger.LogMessage("\n************************\n\tMeanings\n************************");

            if(parsedData.Count == 0)
            {
                _logger.LogError("Sorry, could not find any meaning of the word");
                return;
            }

            foreach (Root data in parsedData)
            {
                _logger.LogMessage("\n<" + data.fl + ">");
                foreach (string def in data.shortdef)
                {
                    _logger.LogMessage(def);
                }
            }
        }

        public async Task GetSynonyms(string word)
        {
            var parsedData = await MakeCalls(word);

            _logger.LogMessage("\n************************\n\tSynonyms\n************************");

            if (parsedData.Count == 0)
            {
                _logger.LogError("Sorry, nothing was found");
                return;
            }

            foreach (Root data in parsedData)
            {
                Meta meta = data.meta;

                if (meta.syns.Count == 0)
                {
                    _logger.LogError("Sorry, no synonyms were found");
                    return;
                }

                foreach (List<string> syns in meta.syns)
                {
                    foreach (string synonym in syns)
                    {
                        _logger.LogMessage(synonym);
                    }
                }
            }
            _logger.LogMessage("\n");
        }

        public async Task GetAntonyms(string word)
        {
            var parsedData = await MakeCalls(word);
            bool antonymFlag = false;

            _logger.LogMessage("\n************************\n\tAntonyms\n************************");

            if (parsedData.Count == 0)
            {
                _logger.LogError("Sorry, nothing was found");
                return;
            }

            foreach (Root data in parsedData)
            {
                Meta meta = data.meta;

                if (meta.ants.Count == 0 && antonymFlag == false)
                {
                    _logger.LogError("Sorry, no antonyms were found");
                    return;
                }
                antonymFlag = true;

                foreach (List<string> ants in meta.ants)
                {
                    foreach (string antonym in ants)
                    {
                        _logger.LogMessage(antonym);
                    }
                }
            }
            _logger.LogMessage("\n");

        }

        public async Task GetAll(string word)
        {
            await GetMeanings(word);
            await GetSynonyms(word);
            await GetAntonyms(word);
        }
    }
}
