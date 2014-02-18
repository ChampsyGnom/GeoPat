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
	[DisplayName("Climat")]
    [TableName("INF_CLIMAT")]
    [SchemaName("INF")]
    public class InfClimat : IInfClimat
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code climat")]
        [ColumnName("INF_CD_CLIMAT__ID")]
        public virtual InfCodeClimat InfCodeClimat
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_CLIMAT__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_CLIMAT__ABS_DEB")]
        [UniqueKey("INF_CLIMAT_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_CLIMAT__ABS_FIN")]
        public Int64 AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CLIMAT__ID")]
        [PrimaryKey("INF_CLIMAT_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_CLIMAT","JOIN_o747")]
        [UniqueKey("INF_CLIMAT_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code climat")]
        [ColumnName("INF_CD_CLIMAT__ID")]
        [ForeignKey("INF_CD_CLIMAT__INF_CLIMAT","JOIN_o766")]
        [UniqueKey("INF_CLIMAT_UK_REF")]
        public Int64 InfCodeClimatId
        {
            get;
            set;
        }


    }
}
