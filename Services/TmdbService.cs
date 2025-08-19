using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MovieCatalogApp.Models;
using System;

namespace MovieCatalogApp.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey;

        public TmdbService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/")
            };

            // Read the API key safely
            try
            {
                var json = File.ReadAllText("appsettings.json");
                using var doc = JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("TMDb", out var tmdbElement) &&
                    tmdbElement.TryGetProperty("ApiKey", out var keyElement))
                {
                    apiKey = keyElement.GetString() ?? throw new Exception("API key is empty.");
                }
                else
                {
                    throw new Exception("TMDb.ApiKey not found in appsettings.json");
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("appsettings.json file not found.");
            }
            catch (JsonException)
            {
                throw new Exception("Invalid JSON in appsettings.json");
            }
        }

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var response = await _httpClient.GetStringAsync($"trending/movie/week?api_key={apiKey}");
            var json = JObject.Parse(response);
            var results = json["results"];

            var movies = new List<Movie>();
            foreach (var movie in results)
            {
                string posterPath = movie["poster_path"]?.ToString() ?? "";
                var m = new Movie
                {
                    Title = movie["title"]?.ToString() ?? "Unknown",
                    PosterFullPath = $"https://image.tmdb.org/t/p/w500{posterPath}"
                };
                await m.LoadPosterAsync();
                movies.Add(m);
            }

            return movies;
        }


    }
}
