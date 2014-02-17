using Emash.GeoPatNet.Generator.ViewModels;
using Microsoft.Practices.Unity;
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

namespace Emash.GeoPatNet.Generator.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public IUnityContainer Container { get; private set; }

        public MainView(IUnityContainer container)
        {
            this.Container = container;
            this.DataContext = this.Container.Resolve<MainViewModel>();
            InitializeComponent();
        }
    }
}
