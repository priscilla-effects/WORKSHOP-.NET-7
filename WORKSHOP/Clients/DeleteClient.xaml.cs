﻿using Npgsql;
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

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM public.\"Client\" WHERE c_id = @id;";
                    cmd.Parameters.AddWithValue("id", Int32.Parse(number.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка удалена успешно.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления строки.");
            }
        }

        private void Limits_id(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ClientsList ClientsList = new();
            ClientsList.Show();
            Close();
        }
    }
}
