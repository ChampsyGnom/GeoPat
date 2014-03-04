
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
namespace Emash.GeoPatNet.Infrastructure.Behaviors
{
    
    public class DataGridContextMenuOpeningBehavior : Behavior<DataGrid>
    {
        #region SelectedItem Property

        public DelegateCommand<DataGridContextMenuOpeningBehaviorEventArg> Command
        {
            get { return (DelegateCommand<DataGridContextMenuOpeningBehaviorEventArg>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(DelegateCommand<DataGridContextMenuOpeningBehaviorEventArg>), typeof(DataGridContextMenuOpeningBehavior),new PropertyMetadata (null));

        
        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ContextMenuOpening += AssociatedObject_ContextMenuOpening;
        }



        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (this.AssociatedObject != null && this.AssociatedObject.ContextMenu != null && this.Command != null)
            {
                DataGridContextMenuOpeningBehaviorEventArg arg = new DataGridContextMenuOpeningBehaviorEventArg();
                arg.DataGrid = this.AssociatedObject;
                arg.ContextMenu = this.AssociatedObject.ContextMenu ;
                arg.ContextMenuEventArgs = e;
                this.Command.Execute(arg);
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ContextMenuOpening -= AssociatedObject_ContextMenuOpening;
            base.OnDetaching();
        }
    }
    public class DataGridContextMenuOpeningBehaviorEventArg : EventArgs
    {
        public DataGrid DataGrid { get; set; }
        public ContextMenu ContextMenu { get; set; }
        public ContextMenuEventArgs ContextMenuEventArgs { get; set; }
    }
}
