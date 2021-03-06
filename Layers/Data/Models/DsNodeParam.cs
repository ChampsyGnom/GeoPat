using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NODE_PARAM_DS",Schema="DS")]
    public partial class DsNodeParam
    {
        [Key]
        [Description("TREE_DS__ID")]
        [Column("TREE_DS__ID",Order=0)]
        [Required()]
        public Int64 TreeDsId { get; set; }
        
        [Key]
        [Description("NODE_DS__ID")]
        [Column("NODE_DS__ID",Order=1)]
        [Required()]
        public Int64 NodeDsId { get; set; }
        
        [Key]
        [Description("NODE_PARAM_DS__ID")]
        [Column("ID",Order=2)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("NODE_PARAM_DS__AGR")]
        [Column("AGR",Order=3)]
        [MaxLength(20)] 
        public String Agr { get; set; }
        
        [Description("NODE_PARAM_DS__INDIC")]
        [Column("INDIC",Order=4)]
        [MaxLength(20)] 
        public String Indic { get; set; }
        
        [Description("NODE_PARAM_DS__COMPARE_VALUE")]
        [Column("COMPARE_VALUE",Order=5)]
        public Nullable<Int64> CompareValue { get; set; }
        
        [Description("NODE_PARAM_DS__COMPARE_OP")]
        [Column("COMPARE_OP",Order=6)]
        [MaxLength(50)] 
        public String CompareOp { get; set; }
        
    }
}
