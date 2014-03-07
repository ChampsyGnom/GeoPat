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
	[DisplayName("Bifurcation")]
    [TableName("INF_BIFURCATION")]
    [SchemaName("INF")]
    public class InfBifurcation 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_BIFURCATION",null)]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_BIFURCATION__INF_BIFURCATION",null)]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public virtual InfCodeBifurcation InfCodeBifurcation
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_BIFURCATION__INFO")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_BIFURCATION__DATE_MS")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        [ControlType(ControlType.Date)]
        [AllowNull(true)]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_BIFURCATION__ABS_DEB")]
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
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
        [ColumnName("INF_BIFURCATION__ID")]
        [PrimaryKey("INF_BIFURCATION_PK")]
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
        [DisplayName("Identifiant code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeBifurcationId
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        [ColumnName("INF_BIFURCATION__NUM_EXPLOIT")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("INF_BIFURCATION__NOM")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Nom
        {
            get;
            set;
        }


    }
}
