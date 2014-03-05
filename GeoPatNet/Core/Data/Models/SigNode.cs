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
	[DisplayName("Noeud")]
    [TableName("SIG_NODE")]
    [SchemaName("SIG")]
    public class SigNode 
    {
    	
        [DisplayName("Type de noeud")]
        [ColumnName("SIG_CD_NODE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("SIG_CD_NODE__SIG_NODE",null)]
        [UniqueKey("SIG_NODE_UK_REF")]
        public virtual SigCodeNode SigCodeNode
        {
            get;
            set;
        }
        [DisplayName("Template de carte")]
        [ColumnName("SIG_TEMPLATE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("SIG_TEMPLATE__SIG_NODE",null)]
        [UniqueKey("SIG_NODE_UK_REF")]
        public virtual SigTemplate SigTemplate
        {
            get;
            set;
        }
        [DisplayName("Couche")]
        [ColumnName("SIG_LAYER__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("SIG_NODE__SIG_LAYER",null)]
        [UniqueKey("SIG_NODE_UK_REF")]
        public virtual SigLayer SigLayer
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("SIG_NODE__ID")]
        [PrimaryKey("SIG_NODE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant couche")]
        [ColumnName("SIG_LAYER__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> SigLayerId
        {
            get;
            set;
        }
        [DisplayName("Identifiant template")]
        [ColumnName("SIG_TEMPLATE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 SigTemplateId
        {
            get;
            set;
        }
        [DisplayName("Identifiant type noeud")]
        [ColumnName("SIG_CD_NODE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 SigCodeNodeId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("SIG_NODE__LIBELLE")]
        [UniqueKey("SIG_NODE_UK_REF")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Noeud parent")]
        [ColumnName("SIG_NODE__PARENT_ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> ParentId
        {
            get;
            set;
        }
        [DisplayName("Ordre")]
        [ColumnName("SIG_NODE__ORDER")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Order
        {
            get;
            set;
        }


    }
}
