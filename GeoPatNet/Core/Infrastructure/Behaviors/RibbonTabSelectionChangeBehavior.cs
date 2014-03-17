using Microsoft.Practices.Prism.Commands;
using Microsoft.Windows.Controls.Ribbon;
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
    public class RibbonTabSelectionChangeBehavior : Behavior<Ribbon>
    {

        #region Closing Command

        public DelegateCommand<SelectionChangedEventArgs> RibbonTabSelectionChangeCommand
        {
            get { return (DelegateCommand<SelectionChangedEventArgs>)GetValue(RibbonTabSelectionChangeCommandProperty); }
            set { SetValue(RibbonTabSelectionChangeCommandProperty, value); }
        }

        public static readonly DependencyProperty RibbonTabSelectionChangeCommandProperty =
            DependencyProperty.Register("RibbonTabSelectionChangeCommand", typeof(DelegateCommand<SelectionChangedEventArgs>), typeof(RibbonTabSelectionChangeBehavior), new PropertyMetadata(null));



        #endregion


        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            base.OnDetaching();
        }

        void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RibbonTabSelectionChangeCommand != null )
            {
                RibbonTabSelectionChangeCommand.Execute(e);
            }
        }
    }
}
