using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SPRT_VST_GMS",Schema="GMS")]
    public partial class GmsSprtVst
    {
        [Key]
        [Description("Identifiant")]
        [Column("CAMP_GMS__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampGmsIdCamp { get; set; }
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_GMS__ID_CHAP",Order=2)]
        [Required()]
        public Int64 CdChapitreGmsIdChap { get; set; }
        
        [Key]
        [Description("Identifiant ligne")]
        [Column("CD_LIGNE_GMS__ID_LIGNE",Order=3)]
        [Required()]
        public Int64 CdLigneGmsIdLigne { get; set; }
        
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
