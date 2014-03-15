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
	[DisplayName("Classeurs")]
    [TableName("INF_CLS")]
    [SchemaName("INF")]
    public class InfCls 
    {
    	
        [DisplayName("Classeur > Contacts")]
        public virtual ICollection<InfClsInfContact> InfClsInfContacts
        {
            get;
            set;
        }
        [DisplayName("Classeurs > Documentss")]
        public virtual ICollection<InfClsInfDoc> InfClsInfDocs
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CLS__ID")]
        [PrimaryKey("INF_CLS_PK")]
        [ForeignKeyAttribute("INF_CLS__INF_CONTACT2","JOIN_o958")]
        [ForeignKeyAttribute("INF_CLS__INF_DOC2","JOIN_o960")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant ligne")]
        [ColumnName("INF_CLS__ROW_ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> RowId
        {
            get;
            set;
        }
        [DisplayName("Table")]
        [ColumnName("INF_CLS__TABLE_NAME")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String TableName
        {
            get;
            set;
        }


    }
}
