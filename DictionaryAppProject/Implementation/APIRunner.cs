using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public class APIRunner : IAPIRunner
    {
        private Dictionary<string, List<Root>> _cache = new Dictionary<string, List<Root>>();
        List<Root> _parsedData;
        private IAPIRequests _apiRequests;
        private ILogger _logger;

        public APIRunner(IAPIRequests apiRequestObject, ILogger logger)
        {
            APIInitializer.InitializeClient();
            _apiRequests = apiRequestObject;
            _logger = logger;
        }

        public async Task MakeCalls(string word)
        {
            if (_cache.ContainsKey(word))
            {
                _parsedData = _cache[word];
            }
            else
            {
                _parsedData = await _apiRequests.GetData(word);
                _cache.Add(word, _parsedData);
            }
        }

        public void GetMeanings()
        {
            var parsedData = _parsedData;

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

        public void GetSynonyms()
        {
            var parsedData = _parsedData;
            bool synonymFlag = false;

            _logger.LogMessage("\n************************\n\tSynonyms\n************************");

            if (parsedData.Count == 0)
            {
                _logger.LogError("Sorry, nothing was found");
                return;
            }

            foreach (Root data in parsedData)
            {
                Meta meta = data.meta;

                if (meta.syns.Count == 0 && synonymFlag == false)
                {
                    _logger.LogError("Sorry, no synonyms were found");
                    return;
                }

                synonymFlag = true;

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

        public void GetAntonyms()
        {
            var parsedData = _parsedData;
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

        public void GetAll()
        {
            GetMeanings();
            GetSynonyms();
            GetAntonyms();
        }
    }
}
