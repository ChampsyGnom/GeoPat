using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NODE_WEB__STYLE_WEB",Schema="WEB")]
    public partial class WebNodeWebStyle
    {
        [Key]
        [Description("Identifiant du noeud")]
        [Column("NODE_WEB__ID",Order=0)]
        [Required()]
        public Int64 NodeWebId { get; set; }
        
        [Key]
        [Description("Identifiant du style")]
        [Column("STYLE_WEB__ID",Order=1)]
        [Required()]
        public Int64 StyleWebId { get; set; }
        
    }
}
