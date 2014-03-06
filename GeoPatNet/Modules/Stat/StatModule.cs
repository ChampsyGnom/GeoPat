using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Stat.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Emash.GeoPatNet.Modules.Stat.Views;

namespace Emash.GeoPatNet.Modules.Stat
{
    [Module(ModuleName = "Stat")]
    [ModuleDependency("Data")]
    public class StatModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public StatModule(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module statistiques ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
            this._regionManager.RegisterViewWithRegion("StatWizzardRegion", typeof(StatWizzardView));
           
           
        }
        public void Initialize()
        {
            this._container.RegisterType<IStatService, StatService>();
        }
    }
}
