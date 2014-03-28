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
        public virtual WebCdNode WebCdNode {get;set;}
        
        public virtual ICollection<WebNodeParam> WebNodeParams { get; set; }
        
        public virtual ICollection<WebModeleWebNode> WebModeleWebNodes { get; set; }
        
        public virtual ICollection<WebNodeWebStyle> WebNodeWebStyles { get; set; }
        
        [Key]
        [Description("Identifiant du noeud")]
        [Column("NODE_WEB__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Type de noeud")]
        [Column("CD_NODE_WEB__NAME",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String CdNodeWebName { get; set; }
        
        [Description("Libellé")]
        [Column("NODE_WEB__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
        [Description("Identifiant du noeud parent")]
        [Column("NODE_WEB__PARENT_ID",Order=3)]
        public Nullable<Int64> ParentId { get; set; }
        
        [Description("Ordre du noeud dans le parent")]
        [Column("NODE_WEB__TREE_ORDER",Order=4)]
        public Nullable<Int64> TreeOrder { get; set; }
        
    }
}
