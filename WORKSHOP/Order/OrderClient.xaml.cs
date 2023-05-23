using Npgsql;
using System.Data;
using System.Windows;

namespace WORKSHOP
{
    public partial class OrderClient : Window
    {
        private readonly DataSet ds = new();
        private readonly DataTable dt = new();
        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;";
        readonly string sql_order = ("SELECT * FROM public.\"Order\"");
        public OrderClient()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(conString);
            con.Open();
            NpgsqlDataAdapter adapter = new(sql_order, con);
            ds.Reset();
            adapter.Fill(ds);
            dt = ds.Tables[0];
            Order_DG.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddOrder AddOrder = new();
            AddOrder.Show();
            Close();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            DeleteOrder DeleteOrder = new();
            DeleteOrder.Show();
            Close();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new();
            MainWindow.Show();
            Close();
        }
    }
}
