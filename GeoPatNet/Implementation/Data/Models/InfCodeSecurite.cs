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
	[DisplayName("Code sécurité")]
    [TableName("INF_CD_SECURITE")]
    [SchemaName("INF")]
    public class InfCodeSecurite : IInfCodeSecurite
    {
    	
        [DisplayName("Sécurités")]
        public virtual ICollection<InfSecurite> InfSecurites
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_SECURITE__CODE")]
        [UniqueKey("INF_CD_SECURITE_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_SECURITE__ID")]
        [PrimaryKey("INF_CD_SECURITE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_SECURITE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
