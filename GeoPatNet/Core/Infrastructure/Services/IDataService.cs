﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Emash.GeoPatNet.Infrastructure.Reflection;


namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IDataService : IAvailableService
    {
        List<EntitySchemaInfo> SchemaInfos { get; }
        DbContext DataContext { get; }
        void Initialize(string connectionString);
        DbSet GetDbSet(Type entityType);
        DbSet<T> GetDbSet<T>() where T : class;  

        /*
        EntityTableInfo GetEntityTableInfo(Type type);
        List<string> GetTableFieldPaths(EntityTableInfo entityTableInfo);
        EntityColumnInfo GetTopColumnInfo(Type modelType, string fieldPath);
        EntityTableInfo GetEntityTableInfo(string entityName);        
        EntityColumnInfo GetBottomColumnInfo(Type type, string fieldPath);
        string GetPath(EntityTableInfo parent, EntityTableInfo child);
        List<EntityColumnInfo> FindParentForeignColumnInfos(EntityColumnInfo columnInfo);
        Dictionary<string, List<EntityColumnInfo>> GetUks(EntityTableInfo tableInfo);
        List<EntityTableInfo> GetAllParentEntityTableInfo(Type type);
         * */

        List<EntityTableInfo> GetAllParentTableInfos(EntityTableInfo tableInfo);
        List<EntityTableInfo> GetParentTableInfos(EntityTableInfo tableInfo);

        //List<EntityTableInfo> GetAllParentTableInfos(EntityColumnInfo columnInfo);    
        //EntityTableInfo GetParentTableInfo(EntityColumnInfo columnInfo);
        List<EntityColumnInfo> GetParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo);
        List<EntityColumnInfo> GetReferenceUniqueKeyColumnInfos(EntityTableInfo tableInfo);
        List<EntityColumnInfo> GetAllParentUniqueKeyColumnInfos(EntityColumnInfo columnInfo);
        EntityTableInfo GetEntityTableInfo(Type type);
        EntityTableInfo GetEntityTableInfo(string p);
        List<EntityTableInfo> TraverseEntityInfoTree(EntityTableInfo entityTableInfo, EntityTableInfo tableInfo);
    }
}