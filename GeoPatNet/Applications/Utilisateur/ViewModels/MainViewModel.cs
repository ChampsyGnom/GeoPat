using Emash.GeoPatNet.App.Utilisateur.Views;
using Emash.GeoPatNet.Engine.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
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

        private IRegionManager RegionManager { get; set; }
        public DelegateCommand<SelectionChangedEventArgs> RibbonTabSelectionChangeCommand { get; private set; }
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container)
            : base(eventAggregator, regionManager, container)
        {

            this.RegionManager = regionManager;
            this.RibbonTabSelectionChangeCommand = new DelegateCommand<SelectionChangedEventArgs>(RibbonTabSelectionChangeExecute);
           
            

        }
        private void RibbonTabSelectionChangeExecute(SelectionChangedEventArgs e)
        {
            if (RegionManager.Regions["MainRegion"].Views.Count() == 0)
            { 
                RegionManager.Regions["MainRegion"].Add (ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<UserMatserDetailView>());
                RegionManager.Regions["MainRegion"].Add (ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<ProfilMasterDetailView>());
                RegionManager.Regions["MainRegion"].Add(ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<ConfigurationView>());

                
            }
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (e.Source != null && e.Source is Ribbon)
                {
                    Ribbon ribbon = e.Source as Ribbon;
                    int index =  ribbon.Items.IndexOf (e.AddedItems[0]);
                    if (index == 0)
                    {
                        RegionManager.Regions["MainRegion"].Activate (ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<UserMatserDetailView>());
                      
                    }
                    else if (index == 1)
                    {
                        RegionManager.Regions["MainRegion"].Activate(ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<ProfilMasterDetailView>());

                    }
                    else if (index == 2)
                    {
                        RegionManager.Regions["MainRegion"].Activate(ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<ConfigurationView>());

                    }
                }
            }
        }
    }
}
