using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.VisualTree; 
using System;

namespace MovieCatalogApp
{
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void SignUpClicked(object? sender, RoutedEventArgs e)
        {
            try
            {
                var username = this.FindControl<TextBox>("UsernameBox")?.Text;
                var password = this.FindControl<TextBox>("PasswordBox")?.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    // Optionally show a user-friendly error message here
                    return;
                }

                var mainWindow = Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop
                    ? desktop.MainWindow as MainWindow
                    : null;

                if (mainWindow?.DbService == null || mainWindow.MainContent == null)
                {
                    // Handle null references as needed
                    return;
                }

                mainWindow.DbService.AddUser(username, password);
                mainWindow.MainContent.Content = new HomePage(username);
            }
            catch (Exception)
            {
                // Optionally log or handle exception
            }
        }


        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
        // Find the main window
        var mainWindow = this.VisualRoot as MainWindow;
        if (mainWindow != null)
        {
            // Replace MainContent with Welcome page UserControl
            mainWindow.MainContent.Content = new WelcomePage();
        }
        }
    }
}