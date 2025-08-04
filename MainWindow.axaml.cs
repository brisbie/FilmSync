using Avalonia.Controls;
using MovieCatalogApp.Services;

namespace MovieCatalogApp;

public partial class MainWindow : Window
{
    private readonly DatabaseService dbService;
    public MainWindow()
    {
        InitializeComponent();

        //Start database
        dbService = new DatabaseService();

        // Add a test user 
        dbService.AddUser("evan", "1234");
    }
}