using Npgsql;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace WORKSHOP
{
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        readonly string sql_client = "INSERT INTO public.\"Client\" " +
            "(c_fio, c_city, c_address, c_phone) " +
            "VALUES (@value1, @value2, @value3, @value4) RETURNING c_id;";
        readonly string sql_order = "INSERT INTO public.\"Order\" " +
            "(c_id, p_id, o_date) " +
            "VALUES (@value5, @value6, @value7);";
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(fio.Text)
                    || string.IsNullOrEmpty(city.Text)
                    || string.IsNullOrEmpty(address.Text)
                    || string.IsNullOrEmpty(phone_number.Text)
                    || string.IsNullOrEmpty(fio.Text)
                    || string.IsNullOrEmpty(product.Text)
                    || string.IsNullOrEmpty(date.Text)))
                {
                    using (NpgsqlConnection con = new NpgsqlConnection(conString))
                    {
                        con.Open();
                        using NpgsqlCommand cmd1 = new NpgsqlCommand(sql_client, con);
                        cmd1.Parameters.AddWithValue("value1", fio.Text);
                        cmd1.Parameters.AddWithValue("value2", city.Text);
                        cmd1.Parameters.AddWithValue("value3", address.Text);
                        cmd1.Parameters.AddWithValue("value4", phone_number.Text);
                        int id = Convert.ToInt32(cmd1.ExecuteScalar());

                        using NpgsqlCommand cmd2 = new NpgsqlCommand(sql_order, con);
                        cmd2.Parameters.AddWithValue("value5", id);
                        cmd2.Parameters.AddWithValue("value6", Int32.Parse(product.Text));
                        cmd2.Parameters.AddWithValue("value7", date.Text);

                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Строка добавлена успешно.");
                    OrderClient OrderClient = new();
                    OrderClient.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Ошибка добавления строки.");
            }
        }

        private void Product(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            date.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            OrderClient OrderClient = new();
            OrderClient.Show();
            Close();
        }
    }
}
