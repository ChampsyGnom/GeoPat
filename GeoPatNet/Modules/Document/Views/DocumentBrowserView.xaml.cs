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

namespace Emash.GeoPatNet.Modules.Document.Views
{
    /// <summary>
    /// Logique d'interaction pour DocumentBrowserView.xaml
    /// </summary>
    public partial class DocumentBrowserView : UserControl
    {
        public DocumentBrowserView()
        {
            InitializeComponent();
        }

        private void ContentControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                Console.WriteLine(files);
            }
        }
    }
}
