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
	[DisplayName("Classe de trafic")]
    [TableName("INF_CD_TRAFIC")]
    [SchemaName("INF")]
    public class InfCodeTrafic : IInfCodeTrafic
    {
    	
        [DisplayName("Section trafics")]
        public virtual ICollection<InfSectionTrafic> InfSectionTrafics
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TRAFIC__CODE")]
        [UniqueKey("INF_CD_TRAFIC_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_TRAFIC__ID")]
        [PrimaryKey("INF_CD_TRAFIC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TRAFIC__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
