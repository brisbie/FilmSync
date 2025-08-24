using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace MovieCatalogApp.Pages;

public partial class RecommendationPage : UserControl
{
    private readonly string _username;
    public RecommendationPage(string username)
    {
        InitializeComponent();

        var welcomeText = this.FindControl<TextBlock>("WelcomeText");
        if (welcomeText != null)
            welcomeText.Text = $"Welcome, {username ?? "Guest"}!";

    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void OnHomeClicked(object sender, RoutedEventArgs e)
    {
        // Get the parent window
        if (this.VisualRoot is MainWindow mainWindow)
        {
            // Swap content back to HomePage using the stored username
            mainWindow.MainContent.Content = new HomePage(mainWindow.CurrentUsername);
        }
    }

}
