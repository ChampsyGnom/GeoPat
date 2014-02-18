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
using System.Windows.Shapes;

namespace Emash.GeoPatNet.Generator.Views
{
    /// <summary>
    /// Logique d'interaction pour GeneratorSqlPostgreView.xaml
    /// </summary>
    public partial class GeneratorSqlPostgreView : Window
    {
       

        public GeneratorSqlPostgreView(ViewModels.GeneratorSqlPostgreViewModel vm)
        {
            // TODO: Complete member initialization
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
