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
using Emash.GeoPatNet.Infrastructure.ViewModels;


namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour DataImportView.xaml
    /// </summary>
    public partial class DataImportView : UserControl
    {
        public DataImportView(IDataImportViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGrid.ScrollIntoView(dataGrid.SelectedItem);
        }
    }
}
