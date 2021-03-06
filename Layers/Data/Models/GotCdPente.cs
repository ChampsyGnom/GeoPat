using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PENTE_GOT",Schema="GOT")]
    public partial class GotCdPente
    {
        [Key]
        [Description("Pente")]
        [Column("PENTE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Pente { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
