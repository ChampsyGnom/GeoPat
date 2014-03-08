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
	[DisplayName("Template de carte")]
    [TableName("SIG_TEMPLATE")]
    [SchemaName("SIG")]
    public class SigTemplate 
    {
    	
        [DisplayName("Noeuds")]
        public virtual ICollection<SigNode> SigNodes
        {
            get;
            set;
        }
        [DisplayName("Type de template")]
        [ColumnName("SIG_CD_TEMPLATE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("SIG_CD_TEMPLATE__SIG_TEMPLATE",null)]
        public virtual SigCodeTemplate SigCodeTemplate
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("SIG_TEMPLATE__ID")]
        [PrimaryKey("SIG_TEMPLATE_PK")]
        [ForeignKeyAttribute("SIG_TEMPLATE__SIG_NODE","JOIN_o88")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant type template")]
        [ColumnName("SIG_CD_TEMPLATE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 SigCodeTemplateId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_TEMPLATE__LIBELLE")]
        [UniqueKey("SIG_TEMPLATE__UK_REF")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
