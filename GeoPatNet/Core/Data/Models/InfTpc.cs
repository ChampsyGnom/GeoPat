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
	[DisplayName("Terre plein central")]
    [TableName("INF_TPC")]
    [SchemaName("INF")]
    public class InfTpc 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_TPC",null)]
        [UniqueKey("INF_TPC_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code TPC")]
        [ColumnName("INF_CD_TPC__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_TPC__INF_TPC",null)]
        [UniqueKey("INF_TPC_UK_REF")]
        public virtual InfCodeTpc InfCodeTpc
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_TPC__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_TPC_UK_REF")]
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
        [DisplayName("Fin")]
        [ColumnName("INF_TPC__ABS_FIN")]
        [LocationAttribute(LocationAttributeType.ReferenceFin)]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        public Int64 AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_TPC__ID")]
        [PrimaryKey("INF_TPC_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
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
        [DisplayName("Identifiant code TPC")]
        [ColumnName("INF_CD_TPC__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeTpcId
        {
            get;
            set;
        }
        [DisplayName("Largeur")]
        [ColumnName("INF_TPC__LARGEUR")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> Largeur
        {
            get;
            set;
        }


    }
}
