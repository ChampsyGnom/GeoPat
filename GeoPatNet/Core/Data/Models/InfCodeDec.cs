using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code découpage")]
    [TableName("INF_CD_DEC")]
    [SchemaName("INF")]
    public class InfCodeDec 
    {
    	
        [DisplayName("Tronçons découpages")]
        public virtual ICollection<InfTrDec> InfTrDecs
        {
            get;
            set;
        }
        [DisplayName("Famille découpage")]
        [ColumnName("INF_FAM_DEC__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_FAM_DEC__INF_CD_DEC",null)]
        [UniqueKey("INF_CD_DEC_UK_REF")]
        public virtual InfFamDec InfFamDec
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_DEC__CODE")]
        [UniqueKey("INF_CD_DEC_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_DEC__ID")]
        [PrimaryKey("INF_CD_DEC_PK")]
        [ForeignKeyAttribute("INF_CD_DEC__INF_TR_DEC","JOIN_o965")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant famille découpage")]
        [ColumnName("INF_FAM_DEC__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfFamDecId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_DEC__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
