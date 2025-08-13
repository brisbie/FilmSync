using Avalonia.Controls;

using System;

namespace MovieCatalogApp
{
    public partial class HomePage : UserControl
    {
        public HomePage(string username)
        {
            InitializeComponent(); // Make sure this is the first thing called

            // Then use username safely
            if (string.IsNullOrEmpty(username))
            {
                username = "Guest";
            }

            // Example: maybe you have a TextBlock named "WelcomeText"
            // Make sure you use FindControl and null-check it
            var welcomeText = this.FindControl<TextBlock>("WelcomeText");
            if (welcomeText != null)
            {
                welcomeText.Text = $"Welcome, {username}!";
            }
            else
            {
                Console.WriteLine("WelcomeText control not found.");
            }
        }
    }
}

