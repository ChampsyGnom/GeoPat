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
	[DisplayName("Famille découpage")]
    [TableName("INF_FAM_DEC")]
    [SchemaName("INF")]
    public class InfFamDec : IInfFamDec
    {
    	
        [DisplayName("Code découpages")]
        public virtual ICollection<InfCodeDec> InfCodeDecs
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_FAM_DEC__CODE")]
        [UniqueKey("INF_FAM_DEC_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_FAM_DEC__ID")]
        [PrimaryKey("INF_FAM_DEC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_FAM_DEC__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
