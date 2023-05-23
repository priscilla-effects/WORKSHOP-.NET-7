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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace WORKSHOP
{
    public partial class EditClient : Window
    {
        public EditClient()
        {
            InitializeComponent();
        }

        private void Limit_id(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        readonly string sql_product = "UPDATE public.\"Client\" SET c_fio = @value1, c_address = @value2, c_phone = @value3 WHERE c_id = @value4";
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand(sql_product, con);
                    cmd.Parameters.AddWithValue("value1", fio.Text);
                    cmd.Parameters.AddWithValue("value2", address.Text);
                    cmd.Parameters.AddWithValue("value3", phone.Text);
                    cmd.Parameters.AddWithValue("value4", ID_num.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка отредактирована успешно.");

                ProductCategory ProductCategory = new();
                ProductCategory.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка редактирования.");
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
