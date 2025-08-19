using Avalonia.Media.Imaging;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;
using System.IO;

namespace MovieCatalogApp.Models
{
    public class Movie : INotifyPropertyChanged
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public string Title { get; set; } = "Unknown";
        public string PosterFullPath { get; set; } = "";

        private Bitmap? posterBitmap;
        public Bitmap? PosterBitmap
        {
            get => posterBitmap;
            private set
            {
                posterBitmap = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadPosterAsync()
        {
            if (string.IsNullOrEmpty(PosterFullPath))
                return;

            try
            {
                Console.WriteLine($"Loading poster for '{Title}' from URL: {PosterFullPath}");

                // Read the HTTP response into a byte array
                var bytes = await _httpClient.GetByteArrayAsync(PosterFullPath);

                // Use a MemoryStream so Bitmap can decode it
                using var ms = new MemoryStream(bytes);
                PosterBitmap = await Task.Run(() => Bitmap.DecodeToWidth(ms, 100));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error loading poster for '{Title}': {ex.Message}");
                PosterBitmap = null;
            }
            catch
            {
                Console.WriteLine($"Unknown error loading poster for '{Title}'");
                PosterBitmap = null;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
