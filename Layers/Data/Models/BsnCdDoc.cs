using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_DOC_BSN",Schema="BSN")]
    public partial class BsnCdDoc
    {
        [Key]
        [Description("Code")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Répertoire")]
        [Column("PATH",Order=2)]
        [MaxLength(255)] 
        public String Path { get; set; }
        
    }
}
