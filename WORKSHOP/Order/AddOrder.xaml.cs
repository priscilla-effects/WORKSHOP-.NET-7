using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WORKSHOP
{
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void Product(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        readonly string sql_order = "INSERT INTO public.\"Order\" (c_id, p_id, o_date) VALUES (@value1, @value2, @value3)";
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand(sql_order, con);
                    cmd.Parameters.AddWithValue("value1", Int32.Parse(fio.Text));
                    cmd.Parameters.AddWithValue("value2", Int32.Parse(product.Text));
                    cmd.Parameters.AddWithValue("value3", date.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка добавлена успешно.");

                OrderClient OrderClient = new();
                OrderClient.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Ошибка добавления строки.");
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            OrderClient OrderClient = new();
            OrderClient.Show();
            Close();
        }
    }
}
