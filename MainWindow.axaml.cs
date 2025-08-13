using Avalonia.Controls;
using MovieCatalogApp.Services;
using Avalonia.Interactivity;


namespace MovieCatalogApp;

public partial class MainWindow : Window
{
    private readonly DatabaseService dbService;

    public DatabaseService DbService => dbService;

    public MainWindow()
    {
        InitializeComponent();

        MainContent.Content = new WelcomePage();

        //Start database
        dbService = new DatabaseService();

        // Add a test user 
        dbService.AddUser("evan", "1234");


    }

    private void OnLoginClicked(object sender, RoutedEventArgs e)
    {
        // Get the parent Window of this control
        if (this.VisualRoot is Window window)
        {
            // Cast it to your MainWindow so you can access MainContent
            if (window is MainWindow mainWindow)
            {
                // Replace MainContent's content with LoginPage UserControl
                mainWindow.MainContent.Content = new Login();
            }
        }
    }

    private void OnSignUpClicked(object sender, RoutedEventArgs e)
{
    // Get the parent Window of this control
    if (this.VisualRoot is Window window)
    {
        // Cast it to your MainWindow so you can access MainContent
        if (window is MainWindow mainWindow)
        {
            // Replace MainContent's content with SignUpPage UserControl
            mainWindow.MainContent.Content = new SignUp();
        }
    }
}

}