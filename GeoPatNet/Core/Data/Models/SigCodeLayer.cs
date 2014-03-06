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
	[DisplayName("Type de couche")]
    [TableName("SIG_CD_LAYER")]
    [SchemaName("SIG")]
    public class SigCodeLayer 
    {
    	
        [DisplayName("Couches")]
        public virtual ICollection<SigLayer> SigLayers
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("SIG_CD_LAYER__CODE")]
        [UniqueKey("SIG_CD_LAYER_UK_REF")]
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
        [ColumnName("SIG_CD_LAYER__ID")]
        [PrimaryKey("SIG_CD_LAYER_PK")]
        [ForeignKeyAttribute("SIG_CD_LAYER__SIG_LAYER","JOIN_o97")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_CD_LAYER__LIBELLE")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
