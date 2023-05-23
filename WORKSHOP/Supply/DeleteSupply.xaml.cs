using Npgsql;
using System;
using System.Windows;

namespace WORKSHOP
{
    public partial class DeleteSupply : Window
    {
        public DeleteSupply()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"DELETE FROM public.\"Supply\" WHERE sp_id = {numberTextBox.Text};";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка удалена успешно.");

                SupplierSupply SupplierSupply = new();
                SupplierSupply.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления строки.");
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            SupplierSupply SupplierSupply = new();
            SupplierSupply.Show();
            Close();
        }
    }
}
