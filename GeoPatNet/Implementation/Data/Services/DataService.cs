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
using Emash.GeoPatNet.Data.Infrastructure.Validations;


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
                schemaInfo.FillDependencies();
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

        public EntityColumnInfo GetEntityColumnInfo(EntityTableInfo tableInfo,String fieldName)
        {
            return (from c in tableInfo.ColumnInfos where c.PropertyName.Equals (fieldName ) select c).FirstOrDefault();
        }





        public List<string> GetTableFieldPaths(EntityTableInfo entityTableInfo)
        {
            List<String> fieldPaths = new List<string>();
            foreach (EntityColumnInfo columnInfo in entityTableInfo.ColumnInfos)
            {
                if (columnInfo.PrimaryKeyName == null)
                {
                    if (columnInfo.ControlType == Presentation.Infrastructure.Attributes.ControlType.Combo )
                    {
                        List<EntityColumnInfo> parentColumnInfos = this.FindParentForeignColumnInfos(columnInfo);
                        foreach (EntityColumnInfo parentColumnInfo in parentColumnInfos)
                        {

                            String path = this.GetPath(parentColumnInfo.TableInfo, entityTableInfo) + "." + parentColumnInfo.PropertyName;
                            fieldPaths.Add(path);
                        }
                    
                    }
                    else if (columnInfo.ControlType != Presentation.Infrastructure.Attributes.ControlType.None)
                    {
                        fieldPaths.Add(columnInfo.PropertyName);
                    }
                  
                }
            }

            return fieldPaths;
        }


        private bool GetPath(EntityTableInfo parent, EntityTableInfo child, List<string> paths)
        {
            List<EntityTableInfo> parentTables = this.GetParentTables(child);
            foreach (EntityTableInfo parentTable in parentTables)
            {
                if (parentTable.EntityType.Equals(parent.EntityType))
                {
                    paths.Add(parentTable.EntityType.Name);
                    return true;
                }
                else
                {
                    paths.Add(parentTable.EntityType.Name);
                    if (GetPath(parent, parentTable, paths))
                    { return true; }
                    paths.Remove(parentTable.EntityType.Name);
                }
            }
            return false;

        }

        private List<EntityTableInfo> GetParentTables(EntityTableInfo child)
        {
            List<EntityTableInfo> tables = new List<EntityTableInfo>();
            List<String> childFkNames = new List<string>();
            foreach (EntityColumnInfo column in child.ColumnInfos)
            {
                if (column.ForeignKeyNames .Count > 0 && column.PrimaryKeyName == null)
                {
                    childFkNames.AddRange(column.ForeignKeyNames);
                }
            }
            childFkNames = (from f in childFkNames select f).Distinct().ToList ();

            foreach (EntitySchemaInfo schema in this.SchemaInfos)
            {
                foreach (EntityTableInfo table in schema.TableInfos)
                {
                    bool parentFkNamesContainChildFkName = false;
                    foreach (EntityColumnInfo column in table.ColumnInfos)
                    {
                        if (column.ForeignKeyNames.Count > 0 && column.PrimaryKeyName != null)
                        {
                            
                            foreach (String childFkName in childFkNames)
                            {
                                if (column.ForeignKeyNames.Contains(childFkName))
                                { parentFkNamesContainChildFkName = true; }
                                
                            }
                           
                        }
                    }
                    if (parentFkNamesContainChildFkName)
                    { tables.Add(table); }
                }
            }
            return tables;
        }

        public string GetPath(EntityTableInfo parent, EntityTableInfo child)
        {
            List<String> paths = new List<string>();
            GetPath(parent, child, paths);
            return String.Join(".", paths);
        }

        public String GetReferenceUkName(EntityTableInfo tableInfo)
        {
            String ukNameRef = null;
            List<String> allUkNames = new List<string>();
            foreach (EntityColumnInfo columnIno in tableInfo.ColumnInfos)
            {allUkNames.AddRange(columnIno.UniqueKeyNames);}
            allUkNames = (from uk in allUkNames select uk).Distinct ().ToList ();
            foreach (String ukName in allUkNames)
            {
                if (ukName.EndsWith("_REF"))
                { ukNameRef = ukName; }
            }
            if (ukNameRef == null && allUkNames.Count > 0)
            { ukNameRef = allUkNames.First(); }
            return ukNameRef;
        }

        public List<EntityColumnInfo> FindParentForeignColumnInfos(EntityColumnInfo columnInfo)
        {
            List<EntityColumnInfo> list = new List<EntityColumnInfo>();
            EntityTableInfo parentTable = null;
            String ukRefName = null;
            List<EntityColumnInfo> ukRefColumnInfos = null;

            try
            {
                parentTable = this.GetEntityTableInfo(columnInfo.PropertyType);
                ukRefName = this.GetReferenceUkName(parentTable);
                ukRefColumnInfos = (from c in parentTable.ColumnInfos where c.UniqueKeyNames.Contains(ukRefName) select c).ToList();
                foreach (EntityColumnInfo ukRefColumnInfo in ukRefColumnInfos)
                {
                    if (ukRefColumnInfo.ForeignKeyNames.Count > 0)
                    {
                        list.AddRange(FindParentForeignColumnInfos(ukRefColumnInfo));
                    }
                    else
                    {
                        list.Add(ukRefColumnInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return list;
        }

        








        public EntityColumnInfo GetTopColumnInfo(Type sourceType, string fieldPath)
        {
            EntityTableInfo sourceTableInfo = this.GetEntityTableInfo(sourceType);
            if (fieldPath.IndexOf(".") == -1)
            {
                return this.GetEntityColumnInfo(sourceTableInfo, fieldPath);
            }
            else
            {
                EntityTableInfo currentTableInfo = sourceTableInfo;
                String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                EntityColumnInfo currentColumnInfo = null;
                for (int i = 0; i < items.Length; i++)
                {
                    currentColumnInfo = this.GetEntityColumnInfo(currentTableInfo, items[i]);
                    currentTableInfo = this.GetEntityTableInfo(currentColumnInfo.Property.PropertyType);
                    
                    
                }
                return currentColumnInfo;
            }
        }


        public EntityTableInfo GetEntityTableInfo(string entityName)
        {
            foreach (EntitySchemaInfo schema in this.SchemaInfos)
            {
                foreach (EntityTableInfo table in schema.TableInfos)
                {
                    if (table.EntityType.Name.Equals(entityName)) return table;
                }
            }
            return null;
        }


      


        public EntityColumnInfo GetBottomColumnInfo(Type type, string fieldPath)
        {
            EntityTableInfo tableInfo = this.GetEntityTableInfo(type);
            if (fieldPath.IndexOf(".") == -1)
            {
                return (from c in tableInfo.ColumnInfos where c.PropertyName.Equals (fieldPath ) select c).FirstOrDefault();
            }
            else 
            {
                String[] items = fieldPath.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return (from c in tableInfo.ColumnInfos where c.PropertyName.Equals(items[0]) select c).FirstOrDefault();
               
            }
        }




        


        public Dictionary<string, List<EntityColumnInfo>> GetUks(EntityTableInfo tableInfo)
        {
            Dictionary<string, List<EntityColumnInfo>> uks = new Dictionary<string, List<EntityColumnInfo>>();
            foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
            {
                if (columnInfo.UniqueKeyNames.Count > 0)
                {
                    foreach (String ukName in columnInfo.UniqueKeyNames)
                    {
                        if (!uks.ContainsKey(ukName))
                        {uks.Add(ukName, new List<EntityColumnInfo>());}
                        uks[ukName].Add(columnInfo);
                    }
                }
            }
            return uks;
        }
    }
}
