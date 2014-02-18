using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Bifurcation")]
    [TableName("INF_BIFURCATION")]
    [SchemaName("INF")]
    public class InfBifurcation : IInfBifurcation
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        public virtual InfCodeBifurcation InfCodeBifurcation
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_BIFURCATION__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_BIFURCATION__DATE_MS")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_BIFURCATION__ABS_DEB")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_BIFURCATION__ID")]
        [PrimaryKey("INF_BIFURCATION_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_BIFURCATION","JOIN_o745")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code bifurcation")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [ForeignKey("INF_CD_BIFURCATION__INF_BIFURCATION","JOIN_o765")]
        [UniqueKey("INF_BIFURCATION_UK_REF")]
        public Int64 InfCodeBifurcationId
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        [ColumnName("INF_BIFURCATION__NUM_EXPLOIT")]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("INF_BIFURCATION__NOM")]
        public String Nom
        {
            get;
            set;
        }


    }
}
