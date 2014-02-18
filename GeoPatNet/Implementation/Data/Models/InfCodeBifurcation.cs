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
	[DisplayName("Code bifurcation")]
    [TableName("INF_CD_BIFURCATION")]
    [SchemaName("INF")]
    public class InfCodeBifurcation : IInfCodeBifurcation
    {
    	
        [DisplayName("Bifurcations")]
        public virtual ICollection<InfBifurcation> InfBifurcations
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_BIFURCATION__CODE")]
        [UniqueKey("INF_CD_BIFURCATION__UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [PrimaryKey("INF_CD_BIFURCATION_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_BIFURCATION__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
