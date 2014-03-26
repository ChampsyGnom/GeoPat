
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Input;
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

        public void ClearSelection( TreeView input)
        {
            var selected = input.SelectedItem;

            if (selected == null) return;

            var tvi = ContainerFromItem(input,selected) as TreeViewItem;

            if (tvi == null) return;

            tvi.IsSelected = false;

        }

        public TreeViewItem ContainerFromItem(TreeView treeView, object item)
        {
            TreeViewItem containerThatMightContainItem = (TreeViewItem)treeView.ItemContainerGenerator.ContainerFromItem(item);
            if (containerThatMightContainItem != null)
                return containerThatMightContainItem;
            else
                return ContainerFromItem(treeView.ItemContainerGenerator, treeView.Items, item);
        }

        private TreeViewItem ContainerFromItem(ItemContainerGenerator parentItemContainerGenerator, ItemCollection itemCollection, object item)
        {
            foreach (object curChildItem in itemCollection)
            {
                TreeViewItem parentContainer = (TreeViewItem)parentItemContainerGenerator.ContainerFromItem(curChildItem);
                if (parentContainer == null)
                    return null;
                TreeViewItem containerThatMightContainItem = (TreeViewItem)parentContainer.ItemContainerGenerator.ContainerFromItem(item);
                if (containerThatMightContainItem != null)
                    return containerThatMightContainItem;
                TreeViewItem recursionResult = ContainerFromItem(parentContainer.ItemContainerGenerator, parentContainer.Items, item);
                if (recursionResult != null)
                    return recursionResult;
            }
            return null;
        }

        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            Point pt =   Mouse.GetPosition(sender as IInputElement);
            IInputElement elt =   (sender as FrameworkElement).InputHitTest(pt);
            TreeViewItem treeViewItem = (elt as DependencyObject).FindParentControl<TreeViewItem>();
            if (treeViewItem != null)
            {treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);}
            else
            {ClearSelection(this.AssociatedObject);}

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
