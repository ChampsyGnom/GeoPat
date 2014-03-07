using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Eclairage")]
    [TableName("INF_ECLAIRAGE")]
    [SchemaName("INF")]
    public class InfEclairage 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_ECLAIRAGE",null)]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code éclairage")]
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_ECLAIRAGE__INF_ECLAIRAGE",null)]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public virtual InfCodeEclairage InfCodeEclairage
        {
            get;
            set;
        }
        [DisplayName("Code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_POSIT__INF_ECLAIRAGE",null)]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        public virtual InfCodePosit InfCodePosit
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_ECLAIRAGE__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_ECLAIRAGE_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_ECLAIRAGE__ID")]
        [PrimaryKey("INF_ECLAIRAGE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chassée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [LocationAttribute(LocationAttributeType.ReferenceId)]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code éclairage")]
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeEclairageId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodePositId
        {
            get;
            set;
        }


    }
}
