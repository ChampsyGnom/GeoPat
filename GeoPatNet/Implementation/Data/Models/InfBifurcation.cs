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
	[DisplayName("Bifurcation")]
    [TableName("INF_BIFURCATION")]
    [SchemaName("INF")]
    public class InfBifurcation : IInfBifurcation
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
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
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
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
        [ForeignKey("INF_CHAUSSEE__INF_BIFURCATION","JOIN_o769")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [ForeignKey("INF_CD_BIFURCATION__INF_BIFURCATION","JOIN_o789")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
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
