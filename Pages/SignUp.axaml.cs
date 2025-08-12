using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

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
            // Handle login logic here
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