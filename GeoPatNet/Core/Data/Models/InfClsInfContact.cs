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
	[DisplayName("Classeur > Contact")]
    [TableName("INF_CLS__INF_CONTACT")]
    [SchemaName("INF")]
    public class InfClsInfContact 
    {
    	
        [DisplayName("Contacts")]
        [ColumnName("INF_CONTACT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_CONTACT",null)]
        public virtual InfContact InfContact
        {
            get;
            set;
        }
        [DisplayName("Classeurs")]
        [ColumnName("INF_CLS__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_CONTACT2",null)]
        public virtual InfCls InfCls
        {
            get;
            set;
        }
        [DisplayName("Identifiant")]
        [ColumnName("INF_CLS__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfClsId
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
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
