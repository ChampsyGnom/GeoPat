using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRESTA_GOT",Schema="GOT")]
    public partial class GotCdPresta
    {
        public virtual ICollection<GotCamp> GotCamps { get; set; }
        
        public virtual ICollection<GotInspecteur> GotInspecteurs { get; set; }
        
        [Key]
        [Description("Prestataire")]
        [Column("CD_PRESTA_GOT__PRESTATAIRE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Prestataire { get; set; }
        
    }
}
