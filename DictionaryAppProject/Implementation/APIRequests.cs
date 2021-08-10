using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public class APIRequests : IAPIRequests
    {
        private string _apiUrl = "https://www.dictionaryapi.com/api/v3/references/thesaurus/json/";
        private string _apiKey = "eec5a096-c1d0-4257-b831-68ca027e54f4";

        public async Task<List<Root>> GetData(string word)
        {
            string url = _apiUrl + word + "?key=" + _apiKey;

            using (HttpResponseMessage response = await APIInitializer.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    List<Root> myDeserializedClass = null;
                    try
                    {
                        myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(str);
                    } 
                    catch(Exception ex)
                    {
                        throw new WordNotFoundException("Sorry, the word you are looking for could not be found.", ex);
                    }

                    return myDeserializedClass;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
