using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace WORKSHOP
{
    public partial class DeleteOrder : Window
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new();
                    cmd.Connection = con;
                    cmd.CommandText = $"DELETE FROM public.\"Order\" WHERE o_id = {numberTextBox.Text};";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка удалена успешно.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления строки.");
            }
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            OrderClient OrderClient = new();
            OrderClient.Show();
            Close();
        }
    }
}
