using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NODE_DS",Schema="DS")]
    public partial class DsNode
    {
        [Key]
        [Description("TREE_DS__ID")]
        [Column("TREE_DS__ID",Order=0)]
        [Required()]
        public Int64 TreeDsId { get; set; }
        
        [Key]
        [Description("NODE_DS__ID")]
        [Column("ID",Order=1)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("NODE_DS__LIBELLE")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(200)] 
        public String Libelle { get; set; }
        
        [Description("NODE_DS__TYPE")]
        [Column("TYPE",Order=3)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
        [Description("NODE_DS__PARENT_ID")]
        [Column("PARENT_ID",Order=4)]
        [Required()]
        public Int64 ParentId { get; set; }
        
        [Description("NODE_DS__TECHNIQUE")]
        [Column("TECHNIQUE",Order=5)]
        [MaxLength(100)] 
        public String Technique { get; set; }
        
        [Description("NODE_DS__STRUCTURE")]
        [Column("STRUCTURE",Order=6)]
        [MaxLength(100)] 
        public String Structure { get; set; }
        
        [Description("NODE_DS__NB_SI")]
        [Column("NB_SI",Order=7)]
        public Nullable<Int64> NbSi { get; set; }
        
        [Description("NODE_DS__IS_FOR_TRUE")]
        [Column("IS_FOR_TRUE",Order=8)]
        [Required()]
        public Int64 IsForTrue { get; set; }
        
    }
}
