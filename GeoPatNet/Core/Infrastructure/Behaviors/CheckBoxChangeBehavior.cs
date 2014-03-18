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
    public class CheckBoxChangeBehavior : Behavior<CheckBox>
    {
        public DelegateCommand CheckBoxChangeCommand
        {
            get { return (DelegateCommand)GetValue(CheckBoxChangeCommandProperty); }
            set { SetValue(CheckBoxChangeCommandProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxChangeCommandProperty =
            DependencyProperty.Register("CheckBoxChangeCommand", typeof(DelegateCommand), typeof(CheckBoxChangeBehavior), new PropertyMetadata(null));

      

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Checked+=AssociatedObject_Checked;
        }

        void AssociatedObject_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.CheckBoxChangeCommand != null)
            {
                this.CheckBoxChangeCommand.Execute();
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Checked -= AssociatedObject_Checked;
            base.OnDetaching();
        }
    }
}
