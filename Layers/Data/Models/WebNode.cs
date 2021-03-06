using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NODE_WEB",Schema="WEB")]
    public partial class WebNode
    {
        [Key]
        [Description("Identifiant du noeud")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Type de noeud")]
        [Column("CD_NODE_WEB__NAME",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String CdNodeWebName { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
        [Description("Identifiant du noeud parent")]
        [Column("PARENT_ID",Order=3)]
        public Nullable<Int64> ParentId { get; set; }
        
        [Description("Ordre du noeud dans le parent")]
        [Column("TREE_ORDER",Order=4)]
        public Nullable<Int64> TreeOrder { get; set; }
        
    }
}
