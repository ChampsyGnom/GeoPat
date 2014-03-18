using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Commands;

namespace Emash.GeoPatNet.Infrastructure.Behaviors
{
    public  class DataGridCellEditEndingBehavior : Behavior<DataGrid>
    {
        public DelegateCommand CellEditEndingCommand
        {
            get { return (DelegateCommand)GetValue(CellEditEndingCommandProperty); }
            set { SetValue(CellEditEndingCommandProperty, value); }
        }

        public static readonly DependencyProperty CellEditEndingCommandProperty =
            DependencyProperty.Register("CellEditEndingCommand", typeof(DelegateCommand), typeof(DataGridCellEditEndingBehavior), new PropertyMetadata(null));

       

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CellEditEnding += AssociatedObject_CellEditEnding;
        }

        void AssociatedObject_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (this.CellEditEndingCommand != null)
            {this.CellEditEndingCommand.Execute();}
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CellEditEnding -= AssociatedObject_CellEditEnding;
            base.OnDetaching();
        }
    }
}
