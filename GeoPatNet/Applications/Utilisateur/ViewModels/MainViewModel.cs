using Emash.GeoPatNet.App.Utilisateur.Views;
using Emash.GeoPatNet.Engine.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class MainViewModel : MainViewModelBase
    {


        public DelegateCommand<SelectionChangedEventArgs> RibbonTabSelectionChangeCommand { get; private set; }
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container)
            : base(eventAggregator, regionManager, container)
        {
       
            this.RibbonTabSelectionChangeCommand = new DelegateCommand<SelectionChangedEventArgs>(RibbonTabSelectionChangeExecute);
            

        }
        private void RibbonTabSelectionChangeExecute(SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (e.Source != null && e.Source is Ribbon)
                {
                    Ribbon ribbon = e.Source as Ribbon;
                    int index =  ribbon.Items.IndexOf (e.AddedItems[0]);
                    if (index == 0)
                    {
                        UserMatserDetailView userMatserDetailView = new UserMatserDetailView();
                        userMatserDetailView.DataContext = new UserViewModel();
                        this.ActiveContent = userMatserDetailView;
                    }
                    else
                    {
                        this.ActiveContent = null;
                    }
                }
            }
        }
    }
}
