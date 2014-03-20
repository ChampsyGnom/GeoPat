using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Synoptic.Services;
using Emash.GeoPatNet.Modules.Synoptic.ViewModels;
using Emash.GeoPatNet.Modules.Synoptic.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Synoptic
{
    public class SynopticModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public SynopticModule(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module synoptique ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
            this._container.RegisterType<ISynopticService, SynopticService>(new ContainerControlledLifetimeManager());
            this._container.RegisterType<SynopticBrowserViewModel>(new ContainerControlledLifetimeManager());
            this._container.RegisterType<SynopticBrowserView>();
           
        }
        public void Initialize()
        {
            
        }
    }
}
