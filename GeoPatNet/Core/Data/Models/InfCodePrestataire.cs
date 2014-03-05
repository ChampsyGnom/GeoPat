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
	[DisplayName("Type Prestataire")]
    [TableName("INF_CD_PRESTATAIRE")]
    [SchemaName("INF")]
    public class InfCodePrestataire 
    {
    	
        [DisplayName("Prestataires")]
        public virtual ICollection<InfPrestataire> InfPrestataires
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_PRESTATAIRE__CODE")]
        [UniqueKey("INF_CD_PRESTATAIRE_UK_REF")]
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
        [ColumnName("INF_CD_PRESTATAIRE__ID")]
        [PrimaryKey("INF_CD_PRESTATAIRE_PK")]
        [ForeignKeyAttribute("INF_CD_PRESTATAIRE__CD_PRESTATAIRE","JOIN_o898")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_PRESTATAIRE__LIBELLE")]
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
