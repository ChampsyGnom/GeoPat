using Emash.GeoPatNet.Presentation.Implentation.Events;
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

namespace Emash.GeoPatNet.Presentation.Implentation.Views
{
    /// <summary>
    /// Logique d'interaction pour SplashView.xaml
    /// </summary>
    public partial class SplashView : Window
    {
        public SplashView()
        {
            InitializeComponent();
            ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<SplashEvent>().Subscribe(OnSplashEvent);
        }

        private void OnSplashEvent(String message)
        {
            this.Dispatcher.Invoke(new Action(delegate() {
                txtMessage.Text = message;
            }));
            
        }
    }
}
