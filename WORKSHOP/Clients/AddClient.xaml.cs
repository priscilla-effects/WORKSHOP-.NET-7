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

namespace WORKSHOP
{
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        readonly string sql_product = "INSERT INTO public.\"Client\" (c_fio, c_address, c_number) VALUES (@value1, @value2, @value3)";
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand(sql_product, con);
                    cmd.Parameters.AddWithValue("value1", fio.Text);
                    cmd.Parameters.AddWithValue("value2", address.Text);
                    cmd.Parameters.AddWithValue("value3", number.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка добавлена успешно.");

                ClientsList ClientsList = new();
                ClientsList.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Ошибка добавления строки.");
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ClientsList ClientsList = new();
            ClientsList.Show();
            Close();
        }
    }
}
