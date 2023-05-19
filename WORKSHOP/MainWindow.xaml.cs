using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WORKSHOP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(connectionString: "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;");
            con.Open();
        }

        private void Button_Order(object sender, RoutedEventArgs e)
        {
            order_client order_client = new order_client();
            order_client.Show();
        }

        private void Button_Supply(object sender, RoutedEventArgs e)
        {
            supplier_supply supplier_supply = new supplier_supply();
            supplier_supply.Show();
        }

        private void Button_Product(object sender, RoutedEventArgs e)
        {
            product_category product_category = new product_category();
            product_category.Show();
        }
    }
}
