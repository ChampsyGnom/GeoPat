using Emash.GeoPatNet.Atom.Infrastructure.Events;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using System.Threading;


namespace Emash.GeoPatNet.Data.Implementation.Services
{
    public class DataService : IDataService
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public DataContext DataContext { get; private set; }
        private Boolean _isAvailable;
        private String _connectionString;

        public IQueryable<T> GetQueryable<T>() where T : class 
        {
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    var method = typeof(DbContext).GetMethod("Set", new Type[0]).MakeGenericMethod(new Type[] { type });
                    Object set = method.Invoke(this.DataContext, new object[0]);
                    IQueryable<T> genericItem = set as IQueryable<T>;
                    return genericItem;
                }
            }
           return  this.DataContext.Set<T>();
        }
        public DataService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._isAvailable = false;
            this._eventAggregator = eventAggregator;            
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            
        }
        public void Initialize(string connectionString)
        {
            this._connectionString = connectionString;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du service de données ...");
            NpgsqlConnection connection = (NpgsqlConnection)NpgsqlFactory.Instance.CreateConnection();
            connection.ConnectionString = _connectionString;
            this.DataContext = new DataContext(connection);           
            Database.SetInitializer<DataContext>(null);
            this.DataContext.Database.Initialize(false);
            this._isAvailable = true;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Service de données initialisé");
            Thread.Sleep(100);
            this._eventAggregator.GetEvent<ServiceLoadedEvent>().Publish(new ServiceLoadedEventArg(this));
        }
     
        public bool IsAvailable
        {
            get { return this._isAvailable; }
        }
    }
}
