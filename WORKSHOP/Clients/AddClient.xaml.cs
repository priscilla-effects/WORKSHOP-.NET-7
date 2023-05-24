using Npgsql;
using System;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WORKSHOP
{
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        readonly string sql_client = "INSERT INTO public.\"Client\" " +
            "(c_fio, c_city, c_address, c_phone) " +
            "VALUES (@value1, @value2, @value3, @value4);";
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(fio.Text)
                    || string.IsNullOrEmpty(city.Text)
                    || string.IsNullOrEmpty(address.Text) 
                    || string.IsNullOrEmpty(phone_number.Text)))
                {
                    using (NpgsqlConnection con = new NpgsqlConnection(conString))
                    {
                        con.Open();
                        using NpgsqlCommand cmd = new NpgsqlCommand(sql_client, con);
                        cmd.Parameters.AddWithValue("value1", fio.Text);
                        cmd.Parameters.AddWithValue("value2", city.Text);
                        cmd.Parameters.AddWithValue("value3", address.Text);
                        cmd.Parameters.AddWithValue("value4", phone_number.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Строка добавлена успешно.");
                    ClientsList ClientsList = new();
                    ClientsList.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните данные.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления строки.");
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
