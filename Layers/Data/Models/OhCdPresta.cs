using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRESTA_OH",Schema="OH")]
    public partial class OhCdPresta
    {
        [Key]
        [Description("Prestataire")]
        [Column("PRESTATAIRE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Prestataire { get; set; }
        
    }
}
