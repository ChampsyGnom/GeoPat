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
	[DisplayName("Code découpage")]
    [TableName("INF_CD_DEC")]
    [SchemaName("INF")]
    public class InfCodeDec : IInfCodeDec
    {
    	
        [DisplayName("Tronçons découpages")]
        public virtual ICollection<InfTrDec> InfTrDecs
        {
            get;
            set;
        }
        [DisplayName("Famille découpage")]
        [ColumnName("INF_FAM_DEC__ID")]
        public virtual InfFamDec InfFamDec
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_DEC__CODE")]
        [UniqueKey("INF_CD_DEC_UK_REF")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_DEC__ID")]
        [PrimaryKey("INF_CD_DEC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant famille découpage")]
        [ColumnName("INF_FAM_DEC__ID")]
        [ForeignKey("INF_FAM_DEC__INF_CD_DEC","JOIN_o781")]
        [UniqueKey("INF_CD_DEC_UK_REF")]
        public Int64 InfFamDecId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_DEC__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
