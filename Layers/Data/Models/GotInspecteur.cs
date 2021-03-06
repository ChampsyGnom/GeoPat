using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSPECTEUR_GOT",Schema="GOT")]
    public partial class GotInspecteur
    {
        [Key]
        [Description("Nom inspecteur")]
        [Column("NOM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
        [Description("Prestataire")]
        [Column("CD_PRESTA_GOT__PRESTATAIRE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String CdPrestaGotPrestataire { get; set; }
        
        [Description("Fonction")]
        [Column("FONC",Order=2)]
        [MaxLength(60)] 
        public String Fonc { get; set; }
        
    }
}
