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
	[DisplayName("Couche")]
    [TableName("SIG_LAYER")]
    [SchemaName("SIG")]
    public class SigLayer 
    {
    	
        [DisplayName("Noeuds")]
        public virtual ICollection<SigNode> SigNodes
        {
            get;
            set;
        }
        [DisplayName("Type de couche")]
        [ColumnName("SIG_CD_LAYER__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("SIG_CD_LAYER__SIG_LAYER",null)]
        [UniqueKey("SIG_LAYER_UK_REF")]
        public virtual SigCodeLayer SigCodeLayer
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("SIG_LAYER__ID")]
        [PrimaryKey("SIG_LAYER_PK")]
        [ForeignKeyAttribute("SIG_NODE__SIG_LAYER","JOIN_o96")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant type couche")]
        [ColumnName("SIG_CD_LAYER__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 SigCodeLayerId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_LAYER__LIBELLE")]
        [UniqueKey("SIG_LAYER_UK_REF")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Ordre dans la carte")]
        [ColumnName("SIG_LAYER__MAP_ORDER")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 MapOrder
        {
            get;
            set;
        }


    }
}
