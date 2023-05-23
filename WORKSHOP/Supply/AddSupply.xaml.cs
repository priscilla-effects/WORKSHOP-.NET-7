using System.Windows;

namespace WORKSHOP
{
    public partial class AddSupply : Window
    {
        public AddSupply()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new();
            MainWindow.Show();
            Close();
        }
    }
}
