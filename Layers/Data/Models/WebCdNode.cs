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
        [Key]
        [Description("Type de noeud")]
        [Column("NAME",Order=0)]
        [Required()]
        [MaxLength(255)] 
        public String Name { get; set; }
        
    }
}
