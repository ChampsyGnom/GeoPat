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
	[DisplayName("Code gare")]
    [TableName("INF_CD_GARE")]
    [SchemaName("INF")]
    public class InfCodeGare : IInfCodeGare
    {
    	
        [DisplayName("Gares")]
        public virtual ICollection<InfGare> InfGares
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_GARE__CODE")]
        [UniqueKey("INF_CD_GARE_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_GARE__ID")]
        [PrimaryKey("INF_CD_GARE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_GARE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
