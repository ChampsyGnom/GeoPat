
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
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
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using Emash.GeoPatNet.Presentation.Infrastructure.Services;


namespace Emash.GeoPatNet.Presentation.Implementation.Views
{
    /// <summary>
    /// Logique d'interaction pour SplashView.xaml
    /// </summary>
    public partial class SplashView : Window
    {
        public SplashView()
        {
            this.DataContext = ServiceLocator.Current.GetInstance<ISplashService>();
            InitializeComponent();
            
        }

        
    }
}
