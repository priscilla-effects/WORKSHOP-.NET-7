using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WORKSHOP
{
    public partial class ProductCategory : Window
    {
        private readonly DataSet ds = new();
        private readonly DataTable dt = new();
        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        public ProductCategory()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(conString);
            con.Open();
            string sql = ("SELECT * FROM public.\"Product\"");
            NpgsqlDataAdapter adapter = new(sql, con);
            ds.Reset();
            adapter.Fill(ds);
            dt = ds.Tables[0];
            Products_DG.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddItem AddItem = new();
            AddItem.Show();
            Close();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            DeleteItem DeleteItem = new();
            DeleteItem.Show();
            Close();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            EditItem EditItem = new();
            EditItem.Show();
            Close();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new();
            MainWindow.Show();
            Close();
        }
    }
}
