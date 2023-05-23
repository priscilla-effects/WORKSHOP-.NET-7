using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace WORKSHOP
{
    public partial class DeleteClient : Window
    {
        public DeleteClient()
        {
            InitializeComponent();
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
                    cmd.CommandText = $"DELETE FROM public.\"Client\" WHERE c_id = {numberTextBox.Text};";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка удалена успешно.");

                ClientsList ClientsList = new();
                ClientsList.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления строки.");
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
