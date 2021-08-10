using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public interface IAPIRunner
    {
        Task GetMeanings(string word);
        Task GetSynonyms(string word);
        Task GetAntonyms(string word);
        Task GetAll(string word);
    }
}
