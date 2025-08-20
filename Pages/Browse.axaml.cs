using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.VisualTree; 
using System;
namespace MovieCatalogApp.Pages;

public partial class BrowsePage : UserControl
{
      private readonly string _username;
    public BrowsePage(string username)
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
    

}
