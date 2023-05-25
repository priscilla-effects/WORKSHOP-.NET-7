using Npgsql;
using System.Data;
using System.Windows;

namespace WORKSHOP
{
    public partial class Warehouse : Window
    {
        private readonly DataSet ds1 = new();
        private readonly DataTable dt1 = new();
        private readonly DataSet ds2 = new();
        private readonly DataTable dt2 = new();
        readonly string conString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;Include Error Detail=true;";
        readonly string sql_supply = ("SELECT * FROM public.\"Warehouse\" " +
                "LEFT JOIN public.\"Supply\" ON public.\"Warehouse\".sp_id = public.\"Supply\".sp_id;");
        readonly string sql_product = ("SELECT * FROM public.\"Warehouse\" " +
                "LEFT JOIN public.\"Product\" ON public.\"Warehouse\".p_id = public.\"Product\".p_id;");
        public Warehouse()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(conString);
            con.Open();
            NpgsqlDataAdapter adapter1 = new(sql_supply, con);
            ds1.Reset();
            adapter1.Fill(ds1);
            dt1 = ds1.Tables[0];
            Supply_DG.ItemsSource = dt1.DefaultView;

            NpgsqlDataAdapter adapter2 = new(sql_product, con);
            ds2.Reset();
            adapter2.Fill(ds2);
            dt2 = ds2.Tables[0];
            Product_DG.ItemsSource = dt2.DefaultView;
            con.Close();
        }

        private void Button_Supply(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Supplier(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindows = new();
            MainWindows.Show();
            Close();
        }
    }
}
