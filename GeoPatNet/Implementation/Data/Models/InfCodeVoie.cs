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
	[DisplayName("Code voie")]
    [TableName("INF_CD_VOIE")]
    [SchemaName("INF")]
    public class InfCodeVoie : IInfCodeVoie
    {
    	
        [DisplayName("Pavé voies")]
        public virtual ICollection<InfPaveVoie> InfPaveVoies
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_VOIE__CODE")]
        [UniqueKey("UK_CODE_VOIE")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_VOIE__ID")]
        [PrimaryKey("INF_CD_VOIE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_VOIE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Position")]
        [ColumnName("INF_CD_VOIE__POSITION")]
        public Int64 Position
        {
            get;
            set;
        }
        [DisplayName("Roulable")]
        [ColumnName("INF_CD_VOIE__ROULABLE")]
        public Boolean Roulable
        {
            get;
            set;
        }


    }
}
