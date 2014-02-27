using Emash.GeoPatNet.Atom.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Data.Infrastructure.Services
{
    public interface IDataService : IAvailableService
    {
        List<EntitySchemaInfo> SchemaInfos { get; }
        DbContext DataContext { get; }
        void Initialize(string connectionString);
        DbSet<T> GetDbSet<T>() where T : class;
        T CreateItem<T>() where T : class;

        EntityTableInfo GetEntityTableInfo(Type type);

        DbSet GetDbSet(Type entityType);

        List<string> GetTableFieldPaths(EntityTableInfo entityTableInfo);

        EntityColumnInfo GetTopParentProperty(Type modelType, string fieldPath);

        EntityTableInfo GetEntityTableInfo(string entityName);

        
        EntityColumnInfo GetBottomColumnInfo(Type type, string fieldPath);
        string GetPath(EntityTableInfo parent, EntityTableInfo child);
        List<EntityColumnInfo> FindParentForeignColumnInfos(EntityColumnInfo columnInfo);


        Dictionary<string, List<EntityColumnInfo>> GetUks(EntityTableInfo tableInfo);
    }
}
