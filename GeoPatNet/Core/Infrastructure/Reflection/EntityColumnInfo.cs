using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Attributes;

namespace Emash.GeoPatNet.Infrastructure.Reflection
{
    /// <summary>
    /// Information sur un colonne de la base de donné <-> un propriété de l'entity
    /// </summary>
    public class EntityColumnInfo
    {
        public List<EntityFieldInfo> FieldInfos { get; private set; }
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
        public Boolean HasChausseeEmpriseRule { get; private set; }
        public String EmpriseChausseeColumnName { get; private set; }
        public String PrimaryKeyName { get; private set; }
        public List<String> ForeignKeyNames { get; private set; }
        public List<String> UniqueKeyNames { get; private set; }
        public ControlType ControlType { get; private set; }
        public Boolean IsLocalisationReferenceId { get; private set; }
        public Boolean IsLocalisationReferenceGeom { get; private set; }
        public Boolean IsLocalisationDeb { get; private set; }
        public Boolean IsLocalisationFin { get; private set; }

      
        public String DisplayName { get; private set; }
        public EntityColumnInfo(EntityTableInfo entityTableInfo, PropertyInfo property)
        {

            // TODO: Complete member initialization
            this.TableInfo = entityTableInfo;
            this.ForeignKeyNames = new List<string>();
            this.FieldInfos = new List<EntityFieldInfo>();
            this.Property = property;
            this.HasChausseeEmpriseRule = false;
            this.PropertyName = property.Name;
            this.UniqueKeyNames = new List<string>();
            this.PropertyType = property.PropertyType;
            IEnumerable<Attribute> atts = property.GetCustomAttributes();
          
            foreach (Attribute att in atts)
            {
                if (att is LocationAttribute)
                {
                    LocationAttribute locationAttribute = att as LocationAttribute;
                    if (locationAttribute.LocationAttributeType == Enums.LocationAttributeType.ReferenceDeb)
                    { this.IsLocalisationDeb = true; }

                    if (locationAttribute.LocationAttributeType == Enums.LocationAttributeType.ReferenceFin)
                    { this.IsLocalisationFin = true; }

                    if (locationAttribute.LocationAttributeType == Enums.LocationAttributeType.ReferenceId)
                    { this.IsLocalisationReferenceId = true; }

                    if (locationAttribute.LocationAttributeType == Enums.LocationAttributeType.ReferenceGeometry)
                    { this.IsLocalisationReferenceGeom = true; }
                   
                }


                if (att is AllowNullAttribute)
                {
                    this.AllowNull = (att as AllowNullAttribute).AllowNull;
                }
                if (att is RuleEmpriseAttribute)
                {
                    this.EmpriseChausseeColumnName = (att as RuleEmpriseAttribute).ChauseeColumnName;
                    this.HasChausseeEmpriseRule = true;
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
