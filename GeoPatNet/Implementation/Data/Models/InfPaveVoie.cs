using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Pavé voie")]
    [TableName("INF_PAVE_VOIE")]
    [SchemaName("INF")]
    public class InfPaveVoie : IInfPaveVoie
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_PAVE_VOIE",null)]
        [UniqueKey("INF_PAVE_VOIE_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code voie")]
        [ColumnName("INF_CD_VOIE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_VOIE__INF_PAVE_VOIE",null)]
        [UniqueKey("INF_PAVE_VOIE_UK_REF")]
        public virtual InfCodeVoie InfCodeVoie
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_PAVE_VOIE__DATE_MS")]
        [ControlType(ControlType.Date)]
        [AllowNull(false)]
        public DateTime DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_PAVE_VOIE__ABS_DEB")]
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
        [ColumnName("INF_PAVE_VOIE__ABS_FIN")]
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
        [ColumnName("INF_PAVE_VOIE__ID")]
        [PrimaryKey("INF_PAVE_VOIE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code voie")]
        [ColumnName("INF_CD_VOIE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeVoieId
        {
            get;
            set;
        }
        [DisplayName("Largeur")]
        [ColumnName("INF_PAVE_VOIE__LARGEUR")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(false)]
        public Double Largeur
        {
            get;
            set;
        }


    }
}
