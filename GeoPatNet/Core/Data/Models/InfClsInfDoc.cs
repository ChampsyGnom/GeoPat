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
	[DisplayName("Classeurs > Documents")]
    [TableName("INF_CLS__INF_DOC")]
    [SchemaName("INF")]
    public class InfClsInfDoc 
    {
    	
        [DisplayName("Document")]
        [ColumnName("INF_DOC__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_DOC",null)]
        public virtual InfDoc InfDoc
        {
            get;
            set;
        }
        [DisplayName("Classeurs")]
        [ColumnName("INF_CLS__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_DOC2",null)]
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
        [ColumnName("INF_DOC__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfDocId
        {
            get;
            set;
        }
        [DisplayName("Photo par défaut")]
        [ColumnName("INF_CLS__INF_DOC__PHOTO")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> Photo
        {
            get;
            set;
        }
        [DisplayName("Plan par défaut")]
        [ColumnName("INF_CLS__INF_DOC__PLAN")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> Plan
        {
            get;
            set;
        }


    }
}
