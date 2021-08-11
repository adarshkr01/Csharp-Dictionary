using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public interface IAPIRequests
    {
        [Headers(
            new string[] { "Content-type: application/json" }    
        )]
        [Get("/{word}?key=eec5a096-c1d0-4257-b831-68ca027e54f4")]
        Task<List<Root>> GetData(string word);
    }
}
