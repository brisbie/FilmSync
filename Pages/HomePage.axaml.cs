using Avalonia.Controls;
using MovieCatalogApp.Models;
using MovieCatalogApp.Services;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieCatalogApp.Pages;
using Avalonia.Interactivity;

namespace MovieCatalogApp
{
    public partial class HomePage : UserControl
    {

        private readonly TmdbService _tmdbService;
        private readonly ObservableCollection<Movie> trendingMovies = new ObservableCollection<Movie>();

        public HomePage(string username)
        {
            InitializeComponent();

            _tmdbService = new TmdbService();

            var welcomeText = this.FindControl<TextBlock>("WelcomeText");
            if (welcomeText != null)
                welcomeText.Text = $"Welcome, {username ?? "Guest"}!";

            LoadTrendingMovies();
        }
        private async void LoadTrendingMovies()
        {
            var trendingList = this.FindControl<ItemsControl>("TrendingList");
            if (trendingList != null)
            {
                var movies = await _tmdbService.GetTrendingMoviesAsync();

                // Load poster bitmaps
                foreach (var movie in movies)
                    await movie.LoadPosterAsync();

                trendingList.ItemsSource = movies; // now set ItemsSource
            }
        }

        private void OnBrowseClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Browse button clicked");

            if (this.VisualRoot is MainWindow mainWindow)
            {
                // Pass the username to BrowsePage
                mainWindow.MainContent.Content = new BrowsePage(mainWindow.CurrentUsername);
            }
        }

        private void OnCollectionClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Collection button clicked");

            if (this.VisualRoot is MainWindow mainWindow)
            {
                // Pass the username to Collection Page
                mainWindow.MainContent.Content = new CollectionPage(mainWindow.CurrentUsername);
            }
        }

        private void OnDiaryClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Diary button clicked");

            if (this.VisualRoot is MainWindow mainWindow)
            {
                // Pass the username to Diary Page
                mainWindow.MainContent.Content = new DiaryPage(mainWindow.CurrentUsername);
            }
        }
    }
}
