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
	[DisplayName("Type liaison")]
    [TableName("INF_CD_LIAISON")]
    [SchemaName("INF")]
    public class InfCodeLiaison : IInfCodeLiaison
    {
    	
        [DisplayName("Liaisons")]
        public virtual ICollection<InfLiaison> InfLiaisons
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_LIAISON__CODE")]
        [UniqueKey("INF_CD_LIAISON_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_LIAISON__ID")]
        [PrimaryKey("INF_CD_LIAISON_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_LIAISON__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
