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
        public virtual ICollection<GotCouche> GotCouches { get; set; }
        
        [Key]
        [Description("Code couche")]
        [Column("CD_COUCHE_GOT__CODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Code { get; set; }
        
        [Description("Position")]
        [Column("CD_COUCHE_GOT__POSIT",Order=1)]
        public Nullable<Int64> Posit { get; set; }
        
        [Description("Couleur")]
        [Column("CD_COUCHE_GOT__COULEUR",Order=2)]
        [MaxLength(16)] 
        public String Couleur { get; set; }
        
    }
}
