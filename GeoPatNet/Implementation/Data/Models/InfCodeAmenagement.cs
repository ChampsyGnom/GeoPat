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
	[DisplayName("Code aménagement")]
    [TableName("INF_CD_AMENAGEMENT")]
    [SchemaName("INF")]
    public class InfCodeAmenagement : IInfCodeAmenagement
    {
    	
        [DisplayName("Aménagements")]
        public virtual ICollection<InfAmenagement> InfAmenagements
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_AMENAGEMENT__CODE")]
        [UniqueKey("INF_CD_AMENAGEMENT_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        [PrimaryKey("INF_CD_AMENAGEMENT_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_AMENAGEMENT__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
