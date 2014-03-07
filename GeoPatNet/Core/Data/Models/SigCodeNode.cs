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
	[DisplayName("Type de noeud")]
    [TableName("SIG_CD_NODE")]
    [SchemaName("SIG")]
    public class SigCodeNode 
    {
    	
        [DisplayName("Noeuds")]
        public virtual ICollection<SigNode> SigNodes
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("SIG_CD_NODE__CODE")]
        [UniqueKey("SIG_CD_NODE_UK_REF")]
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
        [ColumnName("SIG_CD_NODE__ID")]
        [PrimaryKey("SIG_CD_NODE_PK")]
        [ForeignKeyAttribute("SIG_CD_NODE__SIG_NODE","JOIN_o90")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_CD_NODE__LIBELLE")]
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
