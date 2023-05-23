using System.Windows;

namespace WORKSHOP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Order(object sender, RoutedEventArgs e)
        {
            OrderClient OrderClient = new();
            OrderClient.Show();
            Close();
        }

        private void Button_Supply(object sender, RoutedEventArgs e)
        {
            SupplierSupply SupplierSupply = new();
            SupplierSupply.Show();
            Close();
        }

        private void Button_Product(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }

        private void Button_Clients(object sender, RoutedEventArgs e)
        {
            ClientsList ClientsList = new();
            ClientsList.Show();
            Close();
        }
    }
}
