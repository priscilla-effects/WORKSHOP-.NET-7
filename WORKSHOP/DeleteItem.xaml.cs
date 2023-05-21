using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using System.Collections.Generic;
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

namespace WORKSHOP
{
    public partial class DeleteItem : Window
    {
        public DeleteItem()
        {
            InitializeComponent();
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = MyRegex();
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString:"Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;"))
                {
                    con.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = con;
                        command.CommandText = $"DELETE FROM public.\"Product\" WHERE p_id = {numberTextBox.Text};";
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Row deleted successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show($"Error deleting row.");
            }

            Close();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }

        [GeneratedRegex("[^1-9]+")]
        private static partial Regex MyRegex();
    }
}
