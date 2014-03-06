using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour GenericDataFormView.xaml
    /// </summary>
    public partial class GenericDataFormView : UserControl
    {

        public Boolean ShowDataToolBar
        {
            get { return (Boolean)GetValue(ShowDataToolBarProperty); }
            set { SetValue(ShowDataToolBarProperty, value); }
        }

        public static readonly DependencyProperty ShowDataToolBarProperty = DependencyProperty.Register("ShowDataToolBar", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));






        public Boolean ShowRecordPosition
        {
            get { return (Boolean)GetValue(ShowRecordPositionProperty); }
            set { SetValue(ShowRecordPositionProperty, value); }
        }

        public static readonly DependencyProperty ShowRecordPositionProperty =  DependencyProperty.Register("ShowRecordPosition", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));




        public Boolean ShowSlider
        {
            get { return (Boolean)GetValue(ShowSliderProperty); }
            set { SetValue(ShowSliderProperty, value); }
        }

        public static readonly DependencyProperty ShowSliderProperty =  DependencyProperty.Register("ShowSlider", typeof(Boolean), typeof(GenericDataFormView), new PropertyMetadata(true));



        
        public GenericDataFormView()
        {
            InitializeComponent();
            
           
            

        }

      
    }
}
