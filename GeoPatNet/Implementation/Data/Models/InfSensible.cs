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
	[DisplayName("Sensibilité")]
    [TableName("INF_SENSIBLE")]
    [SchemaName("INF")]
    public class InfSensible : IInfSensible
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code sensibilité")]
        [ColumnName("INF_CD_SENSIBLE__ID")]
        public virtual InfCodeSensible InfCodeSensible
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_SENSIBLE__ABS_DEB")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_SENSIBLE__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_SENSIBLE__ID")]
        [PrimaryKey("INF_SENSIBLE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_SENSIBLE","JOIN_o758")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code sensible")]
        [ColumnName("INF_CD_SENSIBLE__ID")]
        [ForeignKey("INF_CD_SENSIBLE__INF_SENSIBLE","JOIN_o777")]
        public Int64 InfCodeSensibleId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_SENSIBLE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
