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
	[DisplayName("Code occupation")]
    [TableName("INF_CD_OCCUPATION")]
    [SchemaName("INF")]
    public class InfCodeOccupation : IInfCodeOccupation
    {
    	
        [DisplayName("Occupations")]
        public virtual ICollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_OCCUPATION__CODE")]
        [UniqueKey("INF_CD_OCCUPATION_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [PrimaryKey("INF_CD_OCCUPATION_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_OCCUPATION__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
