using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MovieCatalogApp
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            // Access the parent window and swap content
            if (this.VisualRoot is Window window && window is MainWindow mainWindow)
            {
                mainWindow.MainContent.Content = new Login(); // Login UserControl
            }
        }
        private void OnSignUpClicked(object sender, RoutedEventArgs e)
        {
            // Access the parent window and swap content
            if (this.VisualRoot is Window window && window is MainWindow mainWindow)
            {
                mainWindow.MainContent.Content = new SignUp(); // Signup UserControl
            }
        }

    }
}
