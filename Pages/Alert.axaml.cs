using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace MovieCatalogApp
{
    public partial class Alert : Window
    {
        public Alert()
        {
            InitializeComponent();
        }

        public Alert(string message) : this()
        {
            var msg = this.FindControl<TextBlock>("MessageText");
            if (msg != null)
                msg.Text = message;
        }

        private void Ok_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
