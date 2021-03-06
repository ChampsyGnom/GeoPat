using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TREE_RESULT_DS",Schema="DS")]
    public partial class DsTreeResult
    {
        [Key]
        [Description("TREE_DS__ID")]
        [Column("TREE_DS__ID",Order=0)]
        [Required()]
        public Int64 TreeDsId { get; set; }
        
        [Key]
        [Description("TREE_RESULT_DS__ID")]
        [Column("ID",Order=1)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("TREE_RESULT_DS__LIBELLE")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
    }
}
