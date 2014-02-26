using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using System.Reflection;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;

namespace Emash.GeoPatNet.Data.Infrastructure.Reflection
{
    public class EntityTableInfo
    {
        public Type EntityType { get; private set; }
        public String TableName { get; private set; }
        public String SchemaName { get; private set; }
        public String DisplayName { get; private set; }
        public Int32 Level { get; set; }
        public EntitySchemaInfo SchemaInfo { get;   set; }
        public List<EntityColumnInfo> ColumnInfos { get; private set; }
        public EntityTableInfo(Type entityType)
        {
            this.Level = -1;
            
            this.EntityType = entityType;
            Object[] atts = this.EntityType.GetCustomAttributes(false);
            foreach (Attribute att in atts)
            {
                if (att is SchemaNameAttribute)
                {
                    this.SchemaName = (att as SchemaNameAttribute).SchemaName;
                }

                if (att is TableNameAttribute)
                {
                    this.TableName = (att as TableNameAttribute).TableName;
                }
                if (att is DisplayNameAttribute)
                {
                    this.DisplayName = (att as DisplayNameAttribute).DisplayName;
                }
            }
            this.ColumnInfos = new List<EntityColumnInfo>();
            PropertyInfo[] properties = entityType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ControlTypeAttribute att = property.GetCustomAttribute<ControlTypeAttribute>();
                if (att != null)
                {
                    EntityColumnInfo columnInfo = new EntityColumnInfo(this, property);

                    this.ColumnInfos.Add(columnInfo);
                }
                
            }

      
        }
    }
}
