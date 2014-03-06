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
	[DisplayName("Type de template")]
    [TableName("SIG_CD_TEMPLATE")]
    [SchemaName("SIG")]
    public class SigCodeTemplate 
    {
    	
        [DisplayName("Template de cartes")]
        public virtual ICollection<SigTemplate> SigTemplates
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("SIG_CD_TEMPLATE__CODE")]
        [UniqueKey("SIG_CD_TEMPLATE_UK_REF")]
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
        [ColumnName("SIG_CD_TEMPLATE__ID")]
        [PrimaryKey("SIG_CD_TEMPLATE_PK")]
        [ForeignKeyAttribute("SIG_CD_TEMPLATE__SIG_TEMPLATE","JOIN_o99")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_CD_TEMPLATE__LIBELLE")]
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
