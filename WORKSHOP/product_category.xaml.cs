using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WORKSHOP
{
    public partial class product_category : Window
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public product_category()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(connectionString:"Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=1076;");
            con.Open();
            string sql = ("SELECT * FROM public.\"Product\"");
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            adapter.Fill(ds);
            dt = ds.Tables[0];
            Products_DG.ItemsSource = dt.DefaultView;
            con.Close();
        }
    }
}
