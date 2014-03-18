using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Répartition trafic")]
    [TableName("INF_REPARTITION_TRAFIC")]
    [SchemaName("INF")]
    public class InfRepartitionTrafic 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_REPARTITION_TRAFIC",null)]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("% Poid lourd")]
        [ColumnName("INF_REPARTITION_TRAFIC__PC_PL")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> PcPl
        {
            get;
            set;
        }
        [DisplayName("Année")]
        [ColumnName("INF_REPARTITION_TRAFIC__ANNEE")]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Annee
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_REPARTITION_TRAFIC__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_REPARTITION_TRAFIC_UK_REF")]
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
        [ColumnName("INF_REPARTITION_TRAFIC__ABS_FIN")]
        [LocationAttribute(LocationAttributeType.ReferenceFin)]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(true)]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_REPARTITION_TRAFIC__ID")]
        [PrimaryKey("INF_REPARTITION_TRAFIC_PK")]
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


		public InfRepartitionTrafic ()
		{

		}

    }
}
