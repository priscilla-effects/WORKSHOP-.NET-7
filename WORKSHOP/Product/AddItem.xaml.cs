﻿using Npgsql;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace WORKSHOP
{
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
        }

        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        readonly string sql_product = "INSERT INTO public.\"Product\" " +
            "(p_brand, p_name, p_description, p_price, p_quantity, p_category) " +
            "VALUES (@value1, @value2, @value3, @value4, @value5, @value6);";
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(brand.Text) 
                    || string.IsNullOrEmpty(name.Text) 
                    || string.IsNullOrEmpty(description.Text) 
                    || string.IsNullOrEmpty(price.Text)
                    || string.IsNullOrEmpty(quantity.Text)
                    || string.IsNullOrEmpty(category.Text)))
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
                        cmd.Parameters.AddWithValue("value6", (category.Text));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Строка добавлена успешно.");
                    ProductCategory ProductCategory = new();
                    ProductCategory.Show();
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

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }
    }
}
