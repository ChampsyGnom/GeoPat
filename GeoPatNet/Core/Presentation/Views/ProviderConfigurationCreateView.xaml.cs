using Emash.GeoPatNet.Infrastructure.ViewModels;
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

namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour ProviderConfigurationCreateView.xaml
    /// </summary>
    public partial class ProviderConfigurationCreateView : UserControl
    {
        public ProviderConfigurationCreateView(IProviderConfigurationCreateViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
