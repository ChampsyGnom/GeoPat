﻿using Emash.GeoPatNet.Infrastructure.ViewModels;
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
    /// Logique d'interaction pour ProviderConfigurationVew.xaml
    /// </summary>
    public partial class ProviderConfigurationVew : UserControl
    {
        public ProviderConfigurationVew(IProviderConfigurationViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }

        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.FindParentControl<Window>().DialogResult = true;
            this.FindParentControl<Window>().Close();
        }
    }
}
