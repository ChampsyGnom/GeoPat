using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSPECTEUR_OH",Schema="OH")]
    public partial class OhInspecteur
    {
        [Key]
        [Description("Nom inspecteur")]
        [Column("NOM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
        [Description("Prestataire")]
        [Column("CD_PRESTA_OH__PRESTATAIRE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String CdPrestaOhPrestataire { get; set; }
        
        [Description("Fonction")]
        [Column("FONC",Order=2)]
        [MaxLength(60)] 
        public String Fonc { get; set; }
        
    }
}
