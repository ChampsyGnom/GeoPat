using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PRESTATAIRE_INF",Schema="INF")]
    public partial class InfPrestataire
    {
        [Key]
        [Description("Type Prestataire")]
        [Column("CD_PRESTATAIRE_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPrestataireInfType { get; set; }
        
        [Key]
        [Description("Enseigne")]
        [Column("NOM",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
    }
}
