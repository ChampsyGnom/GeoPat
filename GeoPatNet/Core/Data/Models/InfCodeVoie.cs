using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code voie")]
    [TableName("INF_CD_VOIE")]
    [SchemaName("INF")]
    public class InfCodeVoie 
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
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [DisplayName("Couleur")]
        [ColumnName("INF_CD_VOIE__COULEUR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Couleur
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_VOIE__ID")]
        [PrimaryKey("INF_CD_VOIE_PK")]
        [ForeignKeyAttribute("INF_CD_VOIE__INF_PAVE_VOIE","JOIN_o883")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_VOIE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Position")]
        [ColumnName("INF_CD_VOIE__POSITION")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Position
        {
            get;
            set;
        }
        [DisplayName("Roulable")]
        [ColumnName("INF_CD_VOIE__ROULABLE")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean Roulable
        {
            get;
            set;
        }


    }
}
