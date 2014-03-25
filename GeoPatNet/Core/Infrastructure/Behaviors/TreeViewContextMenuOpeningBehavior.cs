
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
    
    public class TreeViewContextMenuOpeningBehavior : Behavior<TreeView>
    {
       

        public DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg> Command
        {
            get { return (DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(DelegateCommand<TreeViewContextMenuOpeningBehaviorEventArg>), typeof(TreeViewContextMenuOpeningBehavior),new PropertyMetadata (null));

        
       

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ContextMenuOpening += AssociatedObject_ContextMenuOpening;
        }



        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (this.AssociatedObject != null &&  this.Command != null)
            {
                if (this.AssociatedObject.ContextMenu == null)
                { this.AssociatedObject.ContextMenu = new ContextMenu(); }
                TreeViewContextMenuOpeningBehaviorEventArg arg = new TreeViewContextMenuOpeningBehaviorEventArg();
                arg.TreeView = this.AssociatedObject;
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
    public class TreeViewContextMenuOpeningBehaviorEventArg : EventArgs
    {
        public TreeView TreeView { get; set; }
        public ContextMenu ContextMenu { get; set; }
        public ContextMenuEventArgs ContextMenuEventArgs { get; set; }
    }
}
