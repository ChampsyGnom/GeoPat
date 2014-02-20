using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Commands;

namespace Emash.GeoPatNet.Presentation.Infrastructure.Behaviors
{
    public class MouseDoubleClickBehavior : Behavior<Control>
    {
        #region SelectedItem Property

        public DelegateCommand DoubleClickCommand
        {
            get { return (DelegateCommand)GetValue(DoubleClickCommandProperty); }
            set { SetValue(DoubleClickCommandProperty, value); }
        }

        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.Register("DoubleClickCommand", typeof(DelegateCommand), typeof(MouseDoubleClickBehavior),new PropertyMetadata (null));

       

        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
        }

        void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.DoubleClickCommand != null)
            { this.DoubleClickCommand.Execute(); }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
            base.OnDetaching();
        }
    }
}
