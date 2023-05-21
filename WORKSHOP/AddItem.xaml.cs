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
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = MyRegex();
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            ProductCategory ProductCategory = new();
            ProductCategory.Show();
            Close();
        }

        [GeneratedRegex("[^0-9]+")]
        private static partial Regex MyRegex();
    }
}
