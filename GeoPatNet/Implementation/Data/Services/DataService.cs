using Emash.GeoPatNet.Atom.Infrastructure.Events;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Implentation.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Implementation.Services
{
    public class DataService : IDataService
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public DataContext DataContext { get; private set; }
        private Boolean _isAvailable;
        public DataService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._isAvailable = false;
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du service de données ...");
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            
        }
        public void Initialize(string connectionString)
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du service de données ...");
            NpgsqlConnection connection = (NpgsqlConnection)NpgsqlFactory.Instance.CreateConnection();
            connection.ConnectionString = connectionString;
            this.DataContext = new DataContext(connection);
            Database.SetInitializer<DataContext>(null);
            this.DataContext.Database.Initialize(false);
            this._isAvailable = true;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Service de données initialisé");
            this._eventAggregator.GetEvent<ServiceLoadedEvent>().Publish(new ServiceLoadedEventArg(this));
           
            
        }

        public bool IsAvailable
        {
            get { return this._isAvailable; }
        }
    }
}
