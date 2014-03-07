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
	[DisplayName("Climat")]
    [TableName("INF_CLIMAT")]
    [SchemaName("INF")]
    public class InfClimat 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_CLIMAT",null)]
        [UniqueKey("INF_CLIMAT_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code climat")]
        [ColumnName("INF_CD_CLIMAT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_CLIMAT__INF_CLIMAT",null)]
        [UniqueKey("INF_CLIMAT_UK_REF")]
        public virtual InfCodeClimat InfCodeClimat
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_CLIMAT__INFO")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_CLIMAT__ABS_DEB")]
        [UniqueKey("INF_CLIMAT_UK_REF")]
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
        [ColumnName("INF_CLIMAT__ABS_FIN")]
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
        [ColumnName("INF_CLIMAT__ID")]
        [PrimaryKey("INF_CLIMAT_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant code climat")]
        [ColumnName("INF_CD_CLIMAT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeClimatId
        {
            get;
            set;
        }
        [DisplayName("Identifiant3")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }


    }
}
