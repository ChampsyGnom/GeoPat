using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_COUCHE_GOT",Schema="GOT")]
    public partial class GotCdCouche
    {
        [Key]
        [Description("Code couche")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Code { get; set; }
        
        [Description("Position")]
        [Column("POSIT",Order=1)]
        public Nullable<Int64> Posit { get; set; }
        
        [Description("Couleur")]
        [Column("COULEUR",Order=2)]
        [MaxLength(16)] 
        public String Couleur { get; set; }
        
    }
}
