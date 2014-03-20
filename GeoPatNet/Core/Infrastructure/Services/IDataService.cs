using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Models;


namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IDataService : IAvailableService
    {
        List<EntitySchemaInfo> SchemaInfos { get; }
        DbContext DataContext { get; }
        void Initialize(string connectionString);
        DbSet GetDbSet(Type entityType);
        DbSet GetDbSet(String entityName);
        DbSet<T> GetDbSet<T>() where T : class;  
        List<EntityTableInfo> GetAllParentTableInfos(EntityTableInfo tableInfo);
        List<EntityTableInfo> GetParentTableInfos(EntityTableInfo tableInfo);      
        List<EntityColumnInfo> GetParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo);
        List<EntityColumnInfo> GetReferenceUniqueKeyColumnInfos(EntityTableInfo tableInfo);
        List<EntityColumnInfo> GetAllParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo);
        EntityTableInfo GetEntityTableInfo(Type type);
        EntityTableInfo GetEntityTableInfo(string p);
        List<EntityTableInfo> TraverseEntityInfoTree(EntityTableInfo entityTableInfo, EntityTableInfo tableInfo);
        ProviderConfiguration ProviderConfiguration { get; }
        void LoadProviderConfiguration();
    }
}
