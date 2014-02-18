using Emash.GeoPatNet.Data.Implementation.Services;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;


namespace Emash.GeoPatNet.Data.Implementation
{
    [Module(ModuleName = "Data")]
    public class DataModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;

        public DataModule(IEventAggregator eventAggregator,IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module de données ...");
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            
        }

        public void Initialize()
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du module de données ...");
           
        }
    }
}
