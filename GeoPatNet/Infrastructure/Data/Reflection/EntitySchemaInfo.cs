using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Reflection
{
    public class EntitySchemaInfo
    {
        public List<EntityTableInfo> TableInfos { get;private  set; }
        public String SchemaName { get; set; }
        public EntitySchemaInfo()
        {
            this.TableInfos = new List<EntityTableInfo>();
        }

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

        private void RecurseFillDependencies(List<EntityTableInfo> leveledTables,int level)
        {
           
            foreach (EntityTableInfo tableInfo in this.TableInfos)
            {
                if (!leveledTables.Contains(tableInfo))
                {
                    Boolean allParentLeveled = true;
                    foreach (EntityColumnInfo columnInfo in tableInfo.ColumnInfos)
                    {
                        if (columnInfo.ForeignKeyNames.Count > 0 && columnInfo.PrimaryKeyName == null)
                        {
                            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                            List<EntityColumnInfo> parentColumnInfos =  dataService.FindParentForeignColumnInfos(columnInfo);
                            foreach (EntityColumnInfo parentColumnInfo in parentColumnInfos)
                            {
                                if (!leveledTables.Contains(parentColumnInfo.TableInfo))
                                { allParentLeveled = false; }
                            }
                        }
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
    }
}
