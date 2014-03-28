using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_NODE_WEB",Schema="WEB")]
    public partial class WebCdNode
    {
        public virtual ICollection<WebNode> WebNodes { get; set; }
        
        [Key]
        [Description("Type de noeud")]
        [Column("CD_NODE_WEB__NAME",Order=0)]
        [Required()]
        [MaxLength(255)] 
        public String Name { get; set; }
        
    }
}
