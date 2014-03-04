
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Dashboard.Implementation.Services;
using Emash.GeoPatNet.Dashboard.Implementation.ViewModels;
using Emash.GeoPatNet.Dashboard.Implementation.Views;
using Emash.GeoPatNet.Infrastructure.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Dashboard.Implementation
{
    [Module (ModuleName="Dashboard")]
    [ModuleDependency ("Data")]
    public class DashboardModule : IModule
    {
         private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DashboardModule(IEventAggregator eventAggregator, IUnityContainer container,IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module tableau de bord ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
           
           
        }

        public void Initialize()
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du module tableau de bord ...");
            this._container.RegisterType<DashboardDialogFolderViewModel>();
            this._container.RegisterType<IDashboardService, DashboardService>(new ContainerControlledLifetimeManager());
            this._regionManager.RegisterViewWithRegion("Dashboard", typeof(DashboardView));

        }
    }
}
