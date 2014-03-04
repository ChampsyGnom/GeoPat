using Emash.GeoPatNet.Infrastructure.Views;
using Microsoft.Windows.Controls.Ribbon;
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
using Emash.GeoPatNet.App.Referentiel.ViewModels;

namespace Emash.GeoPatNet.App.Referentiel.Views
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : RibbonWindow, IMainView
    {
        public MainView(MainViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
