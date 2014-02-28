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
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Emash.GeoPatNet.Presentation.Implementation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataPropertyGrid.xaml
    /// </summary>
    public partial class GenericDataPropertyGridView : UserControl
    {
        public GenericDataPropertyGridView()
        {
            InitializeComponent();
            
        }

        private void propertyGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(e);
          //  PropertyItem uitem = 


        }
    }
}
