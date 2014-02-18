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
	[DisplayName("Code talus")]
    [TableName("INF_CD_TALUS")]
    [SchemaName("INF")]
    public class InfCodeTalus : IInfCodeTalus
    {
    	
        [DisplayName("Taluss")]
        public virtual ICollection<InfTalus> InfTaluss
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TALUS__CODE")]
        [UniqueKey("INF_CD_TALUS_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_TALUS__ID")]
        [PrimaryKey("INF_CD_TALUS_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TALUS__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
