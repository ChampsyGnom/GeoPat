using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NODE_PARAM_WEB",Schema="WEB")]
    public partial class WebNodeParam
    {
        [Key]
        [Description("Identifiant du noeud")]
        [Column("NODE_WEB__ID",Order=0)]
        [Required()]
        public Int64 NodeWebId { get; set; }
        
        [Key]
        [Description("Code du paramètre")]
        [Column("CODE",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String Code { get; set; }
        
        [Description("Valeur du paramètre")]
        [Column("VALEUR",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String Valeur { get; set; }
        
    }
}
