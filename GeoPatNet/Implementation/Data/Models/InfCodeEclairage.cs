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
	[DisplayName("Code éclairage")]
    [TableName("INF_CD_ECLAIRAGE")]
    [SchemaName("INF")]
    public class InfCodeEclairage : IInfCodeEclairage
    {
    	
        [DisplayName("Eclairages")]
        public virtual ICollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_ECLAIRAGE__CODE")]
        [UniqueKey("INF_CD_ECLAIRAGE_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [PrimaryKey("INF_CD_ECLAIRAGE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_ECLAIRAGE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
