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
	[DisplayName("Contact des classeurs")]
    [TableName("INF_CONTACT_CLS")]
    [SchemaName("INF")]
    public class InfContactCls 
    {
    	
        [DisplayName("Classeurs")]
        [ColumnName("INF_CLS__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_CONTACT_CLS",null)]
        public virtual InfCls InfCls
        {
            get;
            set;
        }
        [DisplayName("Contacts")]
        [ColumnName("INF_CONTACT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CONTACT__INF_CONTACT_CLS",null)]
        public virtual InfContact InfContact
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CONTACT_CLS__ID")]
        [PrimaryKey("INF_CONTACT_CLS_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant classeur")]
        [ColumnName("INF_CLS__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfClsId
        {
            get;
            set;
        }
        [DisplayName("Identifiant contact")]
        [ColumnName("INF_CONTACT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfContactId
        {
            get;
            set;
        }


    }
}
