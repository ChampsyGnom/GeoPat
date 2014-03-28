using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Emash.GeoPat.Data.DataContext context = new Emash.GeoPat.Data.DataContext(CreateConnection());
            context.Database.Initialize(false);
          
        }
        public System.Data.Common.DbConnection CreateConnection()
        {
            
            NpgsqlConnection connection = (NpgsqlConnection)NpgsqlFactory.Instance.CreateConnection();
            connection.ConnectionString = "HOST=127.0.0.1;PORT=5432;DATABASE=aio;USER ID=postgres;PASSWORD=Emash21;PRELOADREADER=true;Timeout=4";
            return connection;
           
        }
    }
}
