using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;


namespace Emash.GeoPatNet.Infrastructure.Behaviors
{
    public class DropBehavior : Behavior<Panel>
    {
        public DelegateCommand<DragEventArgs> DropCommand
        {
            get { return (DelegateCommand<DragEventArgs>)GetValue(DropCommandProperty); }
            set { SetValue(DropCommandProperty, value); }
        }

        public static readonly DependencyProperty DropCommandProperty =
            DependencyProperty.Register("DropCommand", typeof(DelegateCommand<DragEventArgs>), typeof(DropBehavior), new PropertyMetadata(null));

      
        protected override void OnAttached()
        {
          
            base.OnAttached();
            this.AssociatedObject.Drop += AssociatedObject_Drop;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Drop -= AssociatedObject_Drop;
            base.OnDetaching();
        }

        void AssociatedObject_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (this.DropCommand != null)
            {
                this.DropCommand.Execute(e);
            }
        }
    }
}
