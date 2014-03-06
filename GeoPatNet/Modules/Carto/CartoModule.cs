using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.Services;
using Emash.GeoPatNet.Modules.Carto.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Carto
{
    [Module(ModuleName = "Carto")]
    [ModuleDependency("Data")]
    public  class CartoModule : IModule
    {
          private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public CartoModule(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module cartographie ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
            this._container.RegisterType<ICartoService, CartoService>(new ContainerControlledLifetimeManager());
            this._regionManager.RegisterViewWithRegion("CartoView", typeof(CartoView));
            this._regionManager.RegisterViewWithRegion("CartoControl", typeof(CartoControl));
           
        }
        public void Initialize()
        {
           
        }
    }
}
