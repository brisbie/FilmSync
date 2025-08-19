using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MovieCatalogApp.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "YOUR_API_KEY_HERE"; // Replace this!

        public TmdbService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://api.themoviedb.org/3/");
        }

        // Get Trending Movies
        public async Task<List<string>> GetTrendingMoviesAsync()
        {
            var response = await _httpClient.GetStringAsync($"trending/movie/week?api_key={_apiKey}");
            var json = JObject.Parse(response);
            var results = json["results"];

            var movies = new List<string>();
            foreach (var movie in results)
            {
                movies.Add(movie["title"]?.ToString() ?? "Unknown");
            }

            return movies;
        }

        // Get Recently Added / Now Playing Movies
        public async Task<List<string>> GetNowPlayingMoviesAsync()
        {
            var response = await _httpClient.GetStringAsync($"movie/now_playing?api_key={_apiKey}");
            var json = JObject.Parse(response);
            var results = json["results"];

            var movies = new List<string>();
            foreach (var movie in results)
            {
                movies.Add(movie["title"]?.ToString() ?? "Unknown");
            }

            return movies;
        }
    }
}
