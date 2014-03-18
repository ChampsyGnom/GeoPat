using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Document des classeurs")]
    [TableName("INF_DOC_CLS")]
    [SchemaName("INF")]
    public class InfDocCls 
    {
    	
        [DisplayName("Document")]
        [ColumnName("INF_DOC__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("ASSOCIATION_54",null)]
        public virtual InfDoc InfDoc
        {
            get;
            set;
        }
        [DisplayName("Classeurs")]
        [ColumnName("INF_CLS__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CLS__INF_DOC_CLS",null)]
        public virtual InfCls InfCls
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_DOC_CLS__ID")]
        [PrimaryKey("INF_DOC_CLS_PK")]
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
        [DisplayName("Identifiant document")]
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
        [ColumnName("INF_DOC_CLS__PHOTO")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean Photo
        {
            get;
            set;
        }
        [DisplayName("Plan par défaut")]
        [ColumnName("INF_DOC_CLS__PLAN")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean Plan
        {
            get;
            set;
        }


		public InfDocCls ()
		{

		}

    }
}
