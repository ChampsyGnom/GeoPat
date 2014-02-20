using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Reflection
{
    public class EntityTableInfo
    {
        public Type EntityType { get; private set; }
        public String TableName { get; private set; }
        public String SchemaName { get; private set; }
        public String DisplayName { get; private set; }
        public EntityTableInfo(Type entityType)
        {
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
            Console.WriteLine(this.SchemaName + "." + this.TableName);
        }
    }
}
