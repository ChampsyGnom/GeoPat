using Emash.GeoPatNet.App.Utilisateur.ViewModels;
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

namespace Emash.GeoPatNet.App.Utilisateur.Views
{
    /// <summary>
    /// Logique d'interaction pour ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : UserControl
    {
        public ConfigurationView(ConfigurationViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();

        }
    }
}
