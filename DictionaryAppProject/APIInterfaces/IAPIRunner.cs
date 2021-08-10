using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public interface IAPIRunner
    {
        Task<List<Root>> MakeCalls(string word);
        Task GetMeanings(List<Root> parsedData);
        Task GetSynonyms(List<Root> parsedData);
        Task GetAntonyms(List<Root> parsedData);
        Task GetAll(List<Root> parsedData);
    }
}
