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
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.ComponentModel;

namespace Emash.GeoPatNet.Presentation.Views
{
    /// <summary>
    /// Logique d'interaction pour GenericDataGridView.xaml
    /// </summary>
    public partial class GenericDataGridView : UserControl
    {
       


        public GenericDataGridView()
        {
           
            InitializeComponent();
            
            this.dataToolBar.GotFocus += dataToolBar_GotFocus;
            this.dataToolBar.cancelButton.Click += cancelButton_Click;
            this.dataToolBar.commitbutton.Click += commitbutton_Click;
          

            
        }

       

        

        void commitbutton_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.genericDataGrid.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.genericDataGrid.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

        void dataToolBar_GotFocus(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
            this.genericDataGrid.dataGrid.CommitEdit();
            this.dataToolBar.Focus();
        }

       
       
    }
}
