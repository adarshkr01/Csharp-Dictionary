using System;
using System.Net.Http.Headers;
using System.Net.Http;

namespace DictionaryAppProject
{
    public static class APIInitializer
    {
        public static HttpClient ApiClient;
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.Timeout = TimeSpan.FromMinutes(5);
        }
    }
}
