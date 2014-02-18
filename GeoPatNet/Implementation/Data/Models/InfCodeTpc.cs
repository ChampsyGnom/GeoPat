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
	[DisplayName("Code TPC")]
    [TableName("INF_CD_TPC")]
    [SchemaName("INF")]
    public class InfCodeTpc : IInfCodeTpc
    {
    	
        [DisplayName("Terre plein centrals")]
        public virtual ICollection<InfTpc> InfTpcs
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TPC__CODE")]
        [UniqueKey("INF_CD_TPC_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_TPC__ID")]
        [PrimaryKey("INF_CD_TPC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TPC__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
