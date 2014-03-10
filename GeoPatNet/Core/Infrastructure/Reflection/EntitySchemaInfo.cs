using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;

namespace Emash.GeoPatNet.Infrastructure.Reflection
{
    /// <summary>
    /// Informations d'un shcéma de base de données géré par EntityFramework
    /// En gros on as que la liste des table et de quoi initialiser leur niveau dans la hiérarchie de la base de donnée
    /// </summary>
    public class EntitySchemaInfo
    {
        /// <summary>
        /// Liste des tables du schémas
        /// </summary>
        public List<EntityTableInfo> TableInfos { get;private  set; }
        public String SchemaName { get; set; }
        public EntitySchemaInfo()
        {
            this.TableInfos = new List<EntityTableInfo>();
        }
        /// <summary>
        /// Initialise la propriété level de chaque table du schéma en fonction de leur niveau dans la hiérarchie de la base de donnée
        /// Cette propriété level permet de faire un trie à l'import de données pour que les contrainte de clé étrangère ne soit pas violé
        /// </summary>
        public void FillDependencies()
        {
            List<EntityTableInfo> leveledTables = new List<EntityTableInfo>();
            foreach (EntityTableInfo tableInfo in this.TableInfos)
            {
                Boolean hasForeignKey = false;
                foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
                {
                    if (columnInfo.ForeignKeyNames.Count > 0 && columnInfo.PrimaryKeyName == null)
                    { hasForeignKey = true; }
                }
                if (!hasForeignKey)
                {
                    tableInfo.Level = 0;
                    leveledTables.Add(tableInfo);

                }
            }
            this.RecurseFillDependencies(leveledTables,1);
            this.TableInfos = (from t in this.TableInfos orderby t.Level select t).ToList();
         
           
        }
        /// <summary>
        /// Pareil que FillDependencies mais en recursif
        /// </summary>
        /// <param name="leveledTables"></param>
        /// <param name="level"></param>
        private void RecurseFillDependencies(List<EntityTableInfo> leveledTables,int level)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            foreach (EntityTableInfo tableInfo in this.TableInfos)
            {
                if (!leveledTables.Contains(tableInfo))
                {
                    Boolean allParentLeveled = true;
                    List<EntityTableInfo> allParentTables = dataService.GetAllParentTableInfos(tableInfo);
                    foreach (EntityTableInfo allParentTable in allParentTables)
                    {
                        if (!leveledTables.Contains(allParentTable))
                        { allParentLeveled = false; }
                    }
                    
                    if (allParentLeveled == true)
                    {
                        tableInfo.Level = level;
                        level++;
                        leveledTables.Add (tableInfo);
                    }
                }
            }
            if (leveledTables.Count != this.TableInfos.Count)
            { RecurseFillDependencies(leveledTables, level + 1); }
            
        }

        public void CreateTableFields()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
           
            foreach (EntityTableInfo tableInfo in this.TableInfos)
            {
                
                foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
                {
                    if (columnInfo.ControlType != Attributes.ControlType.None)
                    {
                        if (columnInfo.ForeignKeyNames != null && columnInfo.ForeignKeyNames.Count > 0 && columnInfo.PrimaryKeyName == null)
                        {
                            List<EntityFieldInfo> compositeFields = new List<EntityFieldInfo>();
                            List<EntityColumnInfo> parentColumnInfos = dataService.GetAllParentUniqueKeyColumnInfos(columnInfo);
                            foreach (EntityColumnInfo parentColumnInfo in parentColumnInfos)
                            {
                                EntityFieldInfo fieldInfo = new EntityFieldInfo();
                                fieldInfo.ColumnInfo = columnInfo;
                                fieldInfo.ParentColumnInfo = parentColumnInfo;
                                fieldInfo.TableInfo = tableInfo;
                                compositeFields.Add(fieldInfo);
                                fieldInfo.IsMainTableField = false;
                                fieldInfo.ControlType = Attributes.ControlType.Combo;
                                if (columnInfo.AllowNull)
                                { fieldInfo.IsNeeded = false; }
                                else
                                { fieldInfo.IsNeeded = true; }

                                List<EntityTableInfo> tableTree = dataService.TraverseEntityInfoTree(parentColumnInfo.TableInfo, tableInfo);
                                List<String> paths = new List<string>();
                                foreach (EntityTableInfo parentTable in tableTree)
                                { paths.Add(parentTable.EntityType.Name); }
                                paths.Add(parentColumnInfo.PropertyName);
                                fieldInfo.Path = String.Join(".", paths);

                            }
                            compositeFields.Reverse();
                            foreach (EntityFieldInfo fieldInfo in compositeFields)
                            {
                                tableInfo.FieldInfos.Add(fieldInfo);
                                columnInfo.FieldInfos.Add(fieldInfo);
                            }


                        }
                        else
                        {
                            EntityFieldInfo fieldInfo = new EntityFieldInfo();
                            fieldInfo.ColumnInfo = columnInfo;
                            fieldInfo.TableInfo = tableInfo;
                            fieldInfo.IsMainTableField = true;
                            fieldInfo.IsNeeded = !columnInfo.AllowNull;
                            fieldInfo.ControlType = columnInfo.ControlType;
                            tableInfo.FieldInfos.Add(fieldInfo);
                            columnInfo.FieldInfos.Add(fieldInfo);
                            fieldInfo.Path = columnInfo.PropertyName;
                            if (String.IsNullOrEmpty(fieldInfo.Path)) throw new Exception("Field Path Empty");
                        }
                    }
                    
                }
                List<EntityTableInfo> parentTables = dataService.GetAllParentTableInfos(tableInfo);
                foreach (EntityTableInfo parentTable in parentTables)
                {
                    foreach (EntityColumnInfo parentTableColumnInfo in parentTable.ColumnInfos)
                    {
                        if (parentTableColumnInfo.ControlType != Attributes.ControlType.None)
                        {
                            if (!(from c in tableInfo.FieldInfos
                                 where c.ParentColumnInfo != null && c.ParentColumnInfo.Equals (parentTableColumnInfo)
                                 
                                 select c).Any())
                            {
                                EntityFieldInfo fieldInfo = new EntityFieldInfo();
                                fieldInfo.ParentColumnInfo = parentTableColumnInfo;
                                fieldInfo.TableInfo = tableInfo;
                                fieldInfo.IsMainTableField = false;
                                fieldInfo.IsNeeded = false;
                                fieldInfo.ControlType = parentTableColumnInfo.ControlType;
                               
                                List<EntityTableInfo> tableTree = dataService.TraverseEntityInfoTree(parentTableColumnInfo.TableInfo, tableInfo);
                                List<String> paths = new List<string>();
                                foreach (EntityTableInfo parentTableInTree in tableTree)
                                { paths.Add(parentTableInTree.EntityType.Name); }
                                paths.Add(parentTableColumnInfo.PropertyName);
                                fieldInfo.Path = String.Join(".", paths);
                                tableInfo.FieldInfos.Add(fieldInfo);
                            }
                        }
                    }
                }
            }

            foreach (EntityTableInfo tableInfo in this.TableInfos)
            {
                tableInfo.CreateValidationRules();
              //  Console.WriteLine("Table " + tableInfo.DisplayName);
                foreach (EntityFieldInfo fieldInfo in tableInfo.FieldInfos)
                { 
                    //Console.WriteLine("\t Champ " + fieldInfo.Path);
                    fieldInfo.CreateValidationRules();
                }
              
            }

        }
    }
}
