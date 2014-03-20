
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Microsoft.Practices.Prism.Commands;

using System.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Attributes;
using Emash.GeoPatNet.Infrastructure.Models;



namespace Emash.GeoPatNet.Data.Implementation.Services
{
    public class DataService : IDataService
    {
        public ProviderConfiguration ProviderConfiguration { get; private set; }
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public DbContext DataContext { get; private set; }
        private Boolean _isAvailable;
        private String _connectionString;
        private List<EntitySchemaInfo> _schemaInfos;
        public DataService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._isAvailable = false;
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Traverse la hiérarchie et retourne la liste des tables
        /// </summary>
        /// <param name="entityTableInfo"></param>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public List<EntityTableInfo> TraverseEntityInfoTree(EntityTableInfo parent, EntityTableInfo child)
        {
            List<EntityTableInfo> tableTree = new List<EntityTableInfo>();
            this.RecurseGetEntityTableInfoTree(tableTree, parent, child);            
            return tableTree;
        }

        private Boolean RecurseGetEntityTableInfoTree(List<EntityTableInfo> tableTree, EntityTableInfo parent, EntityTableInfo child)
        {

            List<EntityTableInfo> parentTables = this.GetParentTableInfos(child);
            foreach (EntityTableInfo parentTable in parentTables)
            {
                tableTree.Add(parentTable);
                if (parentTable.Equals(parent)) return true;
                else
                {
                    if (RecurseGetEntityTableInfoTree (tableTree,parent,parentTable))
                    { return true;}
                    else tableTree.Remove(parentTable);
                }
                
            }
            return false;
      
        }
        public List<EntityColumnInfo> GetAllParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo)
        {
            List<EntityColumnInfo> allParentUniqueKeyColumnInfos = new List<EntityColumnInfo>();
            List<EntityColumnInfo> parentUniqueKeyColumnInfos = this.GetParentUniqueKeyColumnInfos(columnInfo);
            allParentUniqueKeyColumnInfos.AddRange(parentUniqueKeyColumnInfos);
            foreach (EntityColumnInfo parentUniqueKeyColumnInfo in parentUniqueKeyColumnInfos)
            {
                if (parentUniqueKeyColumnInfo.ControlType == ControlType.Combo)
                {
                    allParentUniqueKeyColumnInfos.AddRange(GetAllParentUniqueKeyColumnInfos(parentUniqueKeyColumnInfo));
                    allParentUniqueKeyColumnInfos.Remove(parentUniqueKeyColumnInfo);
                }
            }
            if (columnInfo.PrimaryKeyName != null && allParentUniqueKeyColumnInfos.Contains(columnInfo))
            { allParentUniqueKeyColumnInfos.Remove(columnInfo); }
            return allParentUniqueKeyColumnInfos;
        }


        public List<EntityColumnInfo> GetParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo)
        {
            List<EntityColumnInfo> parentUniqueKeyColumnInfos = new List<EntityColumnInfo>();
            if (columnInfo.ForeignKeyNames != null && columnInfo.ForeignKeyNames.Count > 0)
            {
                foreach (String foreignKeyName in columnInfo.ForeignKeyNames)
                {
                    foreach (EntityTableInfo iterTableInfo in columnInfo.TableInfo.SchemaInfo.TableInfos)
                    {
                        if (!iterTableInfo.Equals(columnInfo.TableInfo))
                        {
                            if ((from c in iterTableInfo.ColumnInfos
                                 where c.ForeignKeyNames != null && c.ForeignKeyNames.Contains(foreignKeyName)
                                 select c).Any())
                            {
                                List <EntityColumnInfo> referenceUniqueKeyColumnInfos = this.GetReferenceUniqueKeyColumnInfos(iterTableInfo);
                                parentUniqueKeyColumnInfos.AddRange(referenceUniqueKeyColumnInfos);
                            }
                        }
                    }
                }
            }
            return parentUniqueKeyColumnInfos;
        }

        public List<EntityColumnInfo> GetReferenceUniqueKeyColumnInfos(EntityTableInfo tableInfo)
        {
            List<EntityColumnInfo> referenceUniqueKeyColumnInfos = new List<EntityColumnInfo>();
            String referenceUniqueKeyName = null;
            foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
            {
                if (columnInfo.UniqueKeyNames != null && columnInfo.UniqueKeyNames.Count > 0)
                {
                    foreach (String uniqueKeyName in columnInfo.UniqueKeyNames)
                    {
                        if (uniqueKeyName.EndsWith("REF"))
                        {
                            referenceUniqueKeyName = uniqueKeyName;
                        }
                    }
                }
                if (referenceUniqueKeyName == null)
                {
                    if (columnInfo.UniqueKeyNames != null && columnInfo.UniqueKeyNames.Count > 0)
                    {
                        foreach (String uniqueKeyName in columnInfo.UniqueKeyNames)
                        {referenceUniqueKeyName = uniqueKeyName;}
                    }
                }
            }
            if (referenceUniqueKeyName != null)
            {
                foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
                {
                    if (columnInfo.UniqueKeyNames != null && columnInfo.UniqueKeyNames.Contains (referenceUniqueKeyName))
                    {
                        referenceUniqueKeyColumnInfos.Add(columnInfo);
                    }
                }
            }
            return referenceUniqueKeyColumnInfos;
        }

      /*
        public EntityTableInfo GetParentTableInfo(EntityColumnInfo columnInfo)
        {
            EntityTableInfo parentTableInfo = null;
            if (columnInfo.ForeignKeyNames != null && columnInfo.ForeignKeyNames.Count > 0)
            {
                foreach (String foreignKeyName in columnInfo.ForeignKeyNames)
                {
                    foreach (EntityTableInfo iterTableInfo in columnInfo.TableInfo.SchemaInfo.TableInfos)
                    {
                        if (!iterTableInfo.Equals(columnInfo.TableInfo))
                        {
                            if ((from c in iterTableInfo.ColumnInfos
                                    where c.ForeignKeyNames != null && c.ForeignKeyNames.Contains(foreignKeyName)
                                    select c).Any())
                            { parentTableInfo = iterTableInfo; }
                        }
                    }
                }
            }
            return parentTableInfo;
        }
        public List<EntityTableInfo> GetAllParentTableInfos(EntityColumnInfo columnInfo)
        {
            List<EntityTableInfo> parentTableInfos = new List<EntityTableInfo>();
            EntityTableInfo parentTableInfo = this.GetParentTableInfo(columnInfo);
            if (parentTableInfo != null)
            {
                parentTableInfos.Add(parentTableInfo);
                foreach (EntityColumnInfo parentColumnInfo in parentTableInfo.ColumnInfos)
                {
                    if (parentColumnInfo.PrimaryKeyName == null && parentColumnInfo.ForeignKeyNames != null && parentColumnInfo.ForeignKeyNames .Count > 0)
                    { parentTableInfos.AddRange(GetAllParentTableInfos(parentColumnInfo)); }
                  
                }
             
            }
            return parentTableInfos;
        }

        */
        /// <summary>
        /// Retourne les tables parente de la table passé en paramètre (recursivement sur toute la hiérarchie)
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public List<EntityTableInfo> GetAllParentTableInfos(EntityTableInfo tableInfo)
        {
            List<EntityTableInfo> allParentTableInfos = new List<EntityTableInfo>();
            List<EntityTableInfo> parentTableInfos = this.GetParentTableInfos(tableInfo);
            allParentTableInfos.AddRange(parentTableInfos);
            foreach (EntityTableInfo parentTableInfo in parentTableInfos)
            {
                allParentTableInfos.AddRange(GetAllParentTableInfos(parentTableInfo));
            }
            allParentTableInfos = (from t in allParentTableInfos orderby t.Level select t).Distinct().ToList();
            return allParentTableInfos;
        }
        /// <summary>
        /// Retourne les tables parente de la table passé en paramètre (selement celle un niveau au dessus)
        /// </summary>
        /// <param name="tableInfo"></param>
        /// <returns></returns>
        public List<EntityTableInfo> GetParentTableInfos(EntityTableInfo tableInfo)
        {
            List<EntityTableInfo> parentTableInfos = new List<EntityTableInfo>();
            foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
            {
                if (columnInfo.ForeignKeyNames != null && columnInfo.ForeignKeyNames.Count > 0 && columnInfo.PrimaryKeyName == null)
                {
                    foreach (String foreignKeyName in columnInfo.ForeignKeyNames)
                    {
                        foreach (EntityTableInfo iterTableInfo in tableInfo.SchemaInfo.TableInfos)
                        {
                            if (!iterTableInfo.Equals(tableInfo))
                            {
                                if ((from c in iterTableInfo.ColumnInfos
                                     where c.ForeignKeyNames != null && c.ForeignKeyNames.Contains (foreignKeyName)                                     
                                     select c).Any())
                                {parentTableInfos.Add(iterTableInfo);}
                            }
                        }
                    }
                }
            }
            parentTableInfos = (from t in parentTableInfos orderby t.Level select t).Distinct().ToList();
            return parentTableInfos;
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
            try { this.DataContext.Database.Initialize(false); }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
    
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
                foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                { tableInfo.SchemaInfo = schemaInfo; }
                schemaInfo.SchemaName = schemaName;
                this.SchemaInfos.Add(schemaInfo);
               
            }
            
            foreach (EntitySchemaInfo schemaInfo in this.SchemaInfos)
            {
                schemaInfo.FillDependencies();
                schemaInfo.CreateTableFields(); 
            }
           
            this._eventAggregator.GetEvent<ServiceLoadedEvent>().Publish(new ServiceLoadedEventArg(this));

        }
        public EntityTableInfo GetEntityTableInfo(Type type)
        {
            foreach (EntitySchemaInfo schemaInfo in this.SchemaInfos)
            {
                foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                {
                    if (tableInfo.EntityType.Equals(type)) return tableInfo;
                }
            }
            return null;
        }
        public EntityTableInfo GetEntityTableInfo(String entityName)
        {
            foreach (EntitySchemaInfo schemaInfo in this.SchemaInfos)
            {
                foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                {
                    if (tableInfo.EntityType.Name.Equals(entityName)) return tableInfo;
                }
            }
            return null;
        }
     
        public bool IsAvailable
        {
            get { return this._isAvailable; }
        }

        public List<EntitySchemaInfo> SchemaInfos
        {
            get { return _schemaInfos; }
           
        }

        /*
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
                    if (columnInfo.ControlType == ControlType.Combo )
                    {
                        List<EntityColumnInfo> parentColumnInfos = this.FindParentForeignColumnInfos(columnInfo);
                        foreach (EntityColumnInfo parentColumnInfo in parentColumnInfos)
                        {

                            String path = this.GetPath(parentColumnInfo.TableInfo, entityTableInfo) + "." + parentColumnInfo.PropertyName;
                            fieldPaths.Add(path);
                        }
                    
                    }
                    else if (columnInfo.ControlType != ControlType.None)
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
        
        public List<EntityTableInfo> GetAllParentEntityTableInfo(Type type)
        {
            List<EntityTableInfo> parentTables = new List<EntityTableInfo>();
            EntityTableInfo tableInfo = this.GetEntityTableInfo(type);
            List<String> tableFieldPaths = this.GetTableFieldPaths(tableInfo);
            foreach (String tableFieldPath in tableFieldPaths)
            {
                if (tableFieldPath.IndexOf(".") != -1)
                {
                    EntityColumnInfo topColumn = this.GetTopColumnInfo(type, tableFieldPath);
                    parentTables.Add(topColumn.TableInfo);
                }
            }
            parentTables = (from t in parentTables orderby t.DisplayName select t).Distinct().ToList();
            return parentTables;
        }
         * */





















        public DbSet GetDbSet(string entityName)
        {
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (type.Name.Equals(entityName))
                {
                    return this.GetDbSet(type);
                }
            }
            return null;
        }


        public void LoadProviderConfiguration()
        {
            this.ProviderConfiguration = new ProviderConfiguration();
            this.ProviderConfiguration.Load();
        }
    }
}
