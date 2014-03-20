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



        public DelegateCommand<Object> DoubleClicWithParametersCommand
        {
            get { return (DelegateCommand<Object>)GetValue(DoubleClicWithParametersCommandProperty); }
            set { SetValue(DoubleClicWithParametersCommandProperty, value); }
        }

        public static readonly DependencyProperty DoubleClicWithParametersCommandProperty =
            DependencyProperty.Register("DoubleClicWithParametersCommand", typeof(DelegateCommand<Object>), typeof(MouseDoubleClickBehavior), new PropertyMetadata(null));



        public Object DoubleClicWithParametersCommandParameter
        {
            get { return (Object)GetValue(DoubleClicWithParametersCommandParameterProperty); }
            set { SetValue(DoubleClicWithParametersCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty DoubleClicWithParametersCommandParameterProperty =
            DependencyProperty.Register("DoubleClicWithParametersCommandParameter", typeof(Object), typeof(MouseDoubleClickBehavior), new PropertyMetadata(null));

     
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

            if (this.DoubleClicWithParametersCommand != null)
            {
                this.DoubleClicWithParametersCommand.Execute(this.DoubleClicWithParametersCommandParameter);
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;
            base.OnDetaching();
        }
    }
}
