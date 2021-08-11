using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public interface IAPIRunner
    {
        Task MakeCalls(string word);
        void GetMeanings();
        void GetSynonyms();
        void GetAntonyms();
        void GetAll();
    }
}
