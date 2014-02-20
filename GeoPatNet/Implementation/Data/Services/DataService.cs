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
using Microsoft.Practices.Prism.Commands;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using System.Reflection;


namespace Emash.GeoPatNet.Data.Implementation.Services
{
    public class DataService : IDataService
    {

        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public DbContext DataContext { get; private set; }
        private Boolean _isAvailable;
        private String _connectionString;

        public DataService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._isAvailable = false;
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
        }

        public T CreateItem<T>() where T : class
        {
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    
                    return (T) Activator.CreateInstance (type);
                }
            }
            return null;
        }

        public DbSet<T> GetDbSet<T>() where T : class 
        {
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    var method = typeof(DbContext).GetMethod("Set", new Type[0]).MakeGenericMethod(new Type[] { type });
                    Object set = method.Invoke(this.DataContext, new object[0]);
                    DbSet<T> genericItem = set as DbSet<T>;
                    return genericItem;
                }
            }
           return  this.DataContext.Set<T>();
        }
        public DbSet GetDbSet(Type entityType)
        {
           return  this.DataContext.Set(entityType);
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
            this._schemaInfos = new List<EntitySchemaInfo>();
            PropertyInfo[] dataContextProperties = this.DataContext.GetType().GetProperties();
            List<EntityTableInfo> tableInfos = new List<EntityTableInfo>();

            foreach (PropertyInfo dataContextProperty in dataContextProperties)
            {
                if (dataContextProperty.PropertyType.IsGenericType)
                {
                    Type[] types = dataContextProperty.PropertyType.GetGenericArguments();
                    if (types.Length == 1)
                    {
                        EntityTableInfo entityTableInfo = new Infrastructure.Reflection.EntityTableInfo (types[0]);
                        tableInfos.Add(entityTableInfo);
                       
                    }
                }
            }
            List<String> schemaNames = (from t in tableInfos select t.SchemaName).Distinct().ToList();
            foreach (String schemaName in schemaNames)
            {
                EntitySchemaInfo schemaInfo = new EntitySchemaInfo();
                schemaInfo.TableInfos.AddRange((from t in tableInfos where t.SchemaName .Equals (schemaName ) select t).ToList());
                schemaInfo.SchemaName = schemaName;
                this.SchemaInfos.Add(schemaInfo);
            }
            this._eventAggregator.GetEvent<ServiceLoadedEvent>().Publish(new ServiceLoadedEventArg(this));

        }
     
        public bool IsAvailable
        {
            get { return this._isAvailable; }
        }
        private List<EntitySchemaInfo> _schemaInfos;

        public List<EntitySchemaInfo> SchemaInfos
        {
            get { return _schemaInfos; }
           
        }





        public EntityTableInfo GetEntityTableInfo(Type type)
        {
            foreach (EntitySchemaInfo schema in this.SchemaInfos)
            {
                foreach (EntityTableInfo table in schema.TableInfos)
                {
                    if (table.EntityType.Equals(type)) return table;
                }
            }
            return null;
        }





        public List<string> GetTableFieldPaths(EntityTableInfo entityTableInfo)
        {
            List<String> fieldPaths = new List<string>();
            foreach (EntityColumnInfo columnInfo in entityTableInfo.ColumnInfos)
            {
                if (columnInfo.PrimaryKeyName == null)
                {
                    if (columnInfo.ControlType != Presentation.Infrastructure.Attributes.ControlType.None )
                    {
                        if (columnInfo.ForeignKeyName != null)
                        {
                            fieldPaths.AddRange(GetFkTableFieldPaths(columnInfo));
                        }
                        else
                        { fieldPaths.Add(columnInfo.PropertyName); }
                      //  Console.WriteLine(columnInfo.PropertyName + " " + columnInfo.ControlType);
                       
                    }
                  
                }
            }

            return fieldPaths;
        }

        private List<string> GetFkTableFieldPaths(EntityColumnInfo columnInfo)
        {
            List<String> fkFieldPaths = new List<string>();
            Console.WriteLine("List" + columnInfo.ColumnName);

            return fkFieldPaths;
        }
    }
}
