using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public interface IAPIRequests
    {
        Task<List<Root>> GetData(string word);
    }
}
