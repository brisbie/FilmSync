using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using MovieCatalogApp.Services;
using System;

namespace MovieCatalogApp
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void LoginClicked(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine("LoginClicked triggered");

            var usernameBox = this.FindControl<TextBox>("UsernameBox");
            var passwordBox = this.FindControl<TextBox>("PasswordBox");

            if (usernameBox == null || passwordBox == null)
            {
                Console.WriteLine("UsernameBox or PasswordBox not found");
                return;
            }

            var username = usernameBox.Text;
            var password = passwordBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Empty username or password");
                return;
            }

            var mainWindow = this.VisualRoot as MainWindow;
            if (mainWindow == null)
            {
                Console.WriteLine("mainWindow is null");
                return;
            }

            if (mainWindow.DbService == null)
            {
                Console.WriteLine("DbService is null");
                return;
            }

            // Validate user, e.g. (you need a ValidateUser method)
            bool validUser = mainWindow.DbService.ValidateUser(username, password);
            
            if (validUser)
            {
                mainWindow.MainContent.Content = new HomePage(username);
            }
            else
            {
                // Show error message on UI  FIGURE THIS OUT 
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
