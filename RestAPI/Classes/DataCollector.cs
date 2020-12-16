using Newtonsoft.Json;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Classes
{
    public class DataCollector
    {
        private static string  apiKey = "6d04798196304152a5ec79b72e7ae524";
        private static string Url = "http://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=" + apiKey;
        public async Task<List<Article>> GetData()
        {
           
            using (var _client = new HttpClient())
            {
                var result = await _client.GetAsync(Url);
                string resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<NewsModel>(resultContent);
                if (response.Status == "ok" && response.TotalResults > 0)
                {
                    var List = response.Articles.Take(15).ToList();
                    return List;
                }
                return new List<Article>();
            }
        }

        public async Task<List<Article>> GetFilteredNews(string authorName)
        {
           
            using (var _client = new HttpClient())
            {
                var result = await _client.GetAsync(Url);
                string resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<NewsModel>(resultContent);
                if (response.Status == "ok" && response.TotalResults > 0)
                {
                    var List = response.Articles.Where(x => (x.Author != null && x.Author.Trim().ToLower().Contains(authorName.Trim().ToLower()))).Take(15).ToList();
                    return List;
                }
                return new List<Article>();
            }
        }


    }
}
