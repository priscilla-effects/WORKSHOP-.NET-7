﻿using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WORKSHOP
{
    public partial class EditItem : Window
    {
        public EditItem()
        {
            InitializeComponent();
        }

        private void Price(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Quantity(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Limit_id(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        readonly string sql_product = "UPDATE public.\"Product\" SET p_brand = @value1, p_name = @value2, p_description = @value3, p_price = @value4, p_quantity = @value5, p_category = @value6 WHERE p_id = @value7";
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(conString))
                {
                    con.Open();
                    using NpgsqlCommand cmd = new NpgsqlCommand(sql_product, con);
                    cmd.Parameters.AddWithValue("value1", brand.Text);
                    cmd.Parameters.AddWithValue("value2", name.Text);
                    cmd.Parameters.AddWithValue("value3", description.Text);
                    cmd.Parameters.AddWithValue("value4", Int32.Parse(price.Text));
                    cmd.Parameters.AddWithValue("value5", Int32.Parse(quantity.Text));
                    cmd.Parameters.AddWithValue("value6", category.Text);
                    cmd.Parameters.AddWithValue("value7", Int32.Parse(number.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Строка отредактирована успешно.");

                ProductCategory ProductCategory = new();
                ProductCategory.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка редактирования строки.");
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }
    }
}
