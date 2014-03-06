using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Xceed.Wpf.AvalonDock;

namespace Emash.GeoPatNet.Infrastructure.Behaviors
{
    public class AvalonDocumentClosingBehavior : Behavior<DockingManager>
    {
        #region Closing Command 

        public DelegateCommand<DocumentClosingEventArgs> DocumentClosingCommand
        {
            get { return (DelegateCommand<DocumentClosingEventArgs>)GetValue(DocumentClosingCommandProperty); }
            set { SetValue(DocumentClosingCommandProperty, value); }
        }

        public static readonly DependencyProperty DocumentClosingCommandProperty =
            DependencyProperty.Register("DocumentClosingCommand", typeof(DelegateCommand<DocumentClosingEventArgs>), typeof(AvalonDocumentClosingBehavior), new PropertyMetadata(null));



        #endregion


        #region Closed Command

        public DelegateCommand<DocumentClosedEventArgs> DocumentClosedCommand
        {
            get { return (DelegateCommand<DocumentClosedEventArgs>)GetValue(DocumentClosedCommandProperty); }
            set { SetValue(DocumentClosedCommandProperty, value); }
        }

        public static readonly DependencyProperty DocumentClosedCommandProperty =
            DependencyProperty.Register("DocumentClosedCommand", typeof(DelegateCommand<DocumentClosedEventArgs>), typeof(AvalonDocumentClosingBehavior), new PropertyMetadata(null));



        #endregion
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.DocumentClosing += AssociatedObject_DocumentClosing;
            this.AssociatedObject.DocumentClosed += AssociatedObject_DocumentClosed;
        }

        void AssociatedObject_DocumentClosed(object sender, DocumentClosedEventArgs e)
        {
            if (this.DocumentClosedCommand != null) this.DocumentClosedCommand.Execute(e);
        }

        void AssociatedObject_DocumentClosing(object sender, DocumentClosingEventArgs e)
        {
            if (this.DocumentClosingCommand != null) this.DocumentClosingCommand.Execute(e);
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.DocumentClosed -= AssociatedObject_DocumentClosed;
            this.AssociatedObject.DocumentClosing -= AssociatedObject_DocumentClosing;
            base.OnDetaching();
        }
    }
}
