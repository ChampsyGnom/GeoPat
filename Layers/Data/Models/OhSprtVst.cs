using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SPRT_VST_OH",Schema="OH")]
    public partial class OhSprtVst
    {
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Key]
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_OH__ID_CHAP",Order=2)]
        [Required()]
        public Int64 CdChapitreOhIdChap { get; set; }
        
        [Key]
        [Description("Identifiant ligne")]
        [Column("CD_LIGNE_OH__ID_LIGNE",Order=3)]
        [Required()]
        public Int64 CdLigneOhIdLigne { get; set; }
        
        [Description("Indice")]
        [Column("INDICE",Order=4)]
        [Required()]
        public Int64 Indice { get; set; }
        
        [Description("Observation")]
        [Column("OBS",Order=5)]
        [MaxLength(500)] 
        public String Obs { get; set; }
        
    }
}
