using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MovieCatalogApp.Services
{
    public class Movie
    {
        public string Title { get; set; } = "Unknown";
        public string PosterPath { get; set; } = "";
    }

    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey;

        public TmdbService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://api.themoviedb.org/3/")
            };

            var json = File.ReadAllText("appsettings.json");
            using var doc = JsonDocument.Parse(json);
            apiKey = doc.RootElement
                        .GetProperty("TMDb")
                        .GetProperty("ApiKey")
                        .GetString() ?? "";
        }

        private async Task<List<Movie>> GetMoviesAsync(string endpoint)
        {
            var movies = new List<Movie>();

            try
            {
                var response = await _httpClient.GetAsync($"{endpoint}?api_key={apiKey}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(content);
                var results = doc.RootElement.GetProperty("results");

                foreach (var movieElement in results.EnumerateArray())
                {
                    movies.Add(new Movie
                    {
                        Title = movieElement.GetProperty("title").GetString() ?? "Unknown",
                        PosterPath = movieElement.GetProperty("poster_path").GetString() ?? ""
                    });
                }
            }
            catch
            {
                // Optionally log or handle errors
            }

            return movies;
        }

        public Task<List<Movie>> GetTrendingMoviesAsync()
        {
            return GetMoviesAsync("trending/movie/week");
        }

        public Task<List<Movie>> GetNowPlayingMoviesAsync()
        {
            return GetMoviesAsync("movie/now_playing");
        }
    }
}
