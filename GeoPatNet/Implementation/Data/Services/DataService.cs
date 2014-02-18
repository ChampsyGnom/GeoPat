using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Implentation.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Implementation.Services
{
    public class DataService : IDataService
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;


        public DataService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du service de données ...");
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            
        }
        public void Initialize(string connectionString)
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du service de données ...");
            
        }
    }
}
