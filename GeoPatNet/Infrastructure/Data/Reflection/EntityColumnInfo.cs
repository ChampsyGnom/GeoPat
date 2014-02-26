using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Infrastructure.Reflection
{
    public class EntityColumnInfo
    {
        public EntityTableInfo TableInfo { get; private set; }
        public PropertyInfo Property { get; private set; }
        public String PropertyName { get; private set; }
        public Type PropertyType { get; private set; }

        public String ColumnName { get; private set; }
        public Boolean AllowNull { get; private set; }
        public Int32  MaxCharLength { get; private set; }
        public double MinNumericValue { get; private set; }
        public double MaxNumericValue { get; private set; }
        public Boolean IsPr { get; private set; }
        public String PrChausseeColumnName { get; private set; }
        public String PrimaryKeyName { get; private set; }
        public List<String> ForeignKeyNames { get; private set; }
        public List<String> UniqueKeyNames { get; private set; }
        public ControlType ControlType { get; private set; }
      
        public String DisplayName { get; private set; }
        public EntityColumnInfo(EntityTableInfo entityTableInfo, PropertyInfo property)
        {
            // TODO: Complete member initialization
            this.TableInfo = entityTableInfo;
            this.ForeignKeyNames = new List<string>();
            this.Property = property;
            this.PropertyName = property.Name;
            this.UniqueKeyNames = new List<string>();
            this.PropertyType = property.PropertyType;
            IEnumerable<Attribute> atts = property.GetCustomAttributes();
          
            foreach (Attribute att in atts)
            {
                if (att is AllowNullAttribute)
                {
                    this.AllowNull = (att as AllowNullAttribute).AllowNull;
                } 
                if (att is ControlTypeAttribute)
                {
                    this.ControlType = (att as ControlTypeAttribute).ControlType;
                }


                if (att is ColumnNameAttribute)
                {
                    this.ColumnName = (att as ColumnNameAttribute).ColumnName;
                }

                if (att is MaxCharLengthAttribute )
                {
                    this.MaxCharLength  = (att as MaxCharLengthAttribute).MaxCharLength;
                } 
               
                if (att is DisplayNameAttribute )
                {
                    this.DisplayName = (att as DisplayNameAttribute).DisplayName;
                }
                if (att is RangeValueAttribute )
                {
                    this.MinNumericValue = (att as RangeValueAttribute).MinValue;
                    this.MaxNumericValue = (att as RangeValueAttribute).MaxValue;
                }
                if (att is RulePrAttribute)
                {
                    this.IsPr = true;
                    this.PrChausseeColumnName = (att as RulePrAttribute).ChauseeColumnName;
                }

                if (att is PrimaryKeyAttribute)
                { this.PrimaryKeyName = (att as PrimaryKeyAttribute).PrimaryKeyName ; }

                if (att is ForeignKeyAttribute )
                { this.ForeignKeyNames.Add (  (att as ForeignKeyAttribute).ForeignKeyName); }

                if (att is UniqueKeyAttribute )
                { this.UniqueKeyNames.Add((att as UniqueKeyAttribute).UniqueKeyName); }

            }

        }
    }
}
