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
using Emash.GeoPatNet.Presentation.Adapters;

namespace Emash.GeoPatNet.Presentation.Controls
{
    /// <summary>
    /// Logique d'interaction pour SelectDirectoryBox.xaml
    /// </summary>
    public partial class SelectDirectoryBox : UserControl
    {
        // Dependency Property
        public static readonly DependencyProperty SelectedDirectoryProperty =
             DependencyProperty.Register("SelectedDirectory", typeof(String),
             typeof(SelectDirectoryBox), new FrameworkPropertyMetadata(null));

        // .NET Property wrapper
        public String SelectedDirectory
        {
            get { return (String)GetValue(SelectedDirectoryProperty); }
            set { SetValue(SelectedDirectoryProperty, value); }
        }
 
        public SelectDirectoryBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            Window window = FindAncestor<Window>(this);
            System.Windows.Forms.DialogResult result =  dialog.ShowDialog(new Win32WindowAdapter(window));
            if (result == System.Windows.Forms.DialogResult.OK)
            {this.SelectedDirectory = dialog.SelectedPath;}
        }

        private static T FindAncestor<T>(DependencyObject dependencyObject)  where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject); 
            if (parent == null) return null; 
            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }
    }
}
