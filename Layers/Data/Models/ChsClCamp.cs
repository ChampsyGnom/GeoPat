using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CL_CAMP_CHS",Schema="CHS")]
    public partial class ChsClCamp
    {
        [Key]
        [Description("Ind_Code Agr")]
        [Column("CD__CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdCdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String CdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Indicateur")]
        [Column("CD_INDIC_CHS__INDIC",Order=2)]
        [Required()]
        [MaxLength(12)] 
        public String CdIndicChsIndic { get; set; }
        
        [Key]
        [Description("Num Section")]
        [Column("CAMP_CHS__SECTION",Order=3)]
        [Required()]
        [MaxLength(15)] 
        public String CampChsSection { get; set; }
        
        [Key]
        [Description("Année")]
        [Column("CAMP_CHS__ANNEE",Order=4)]
        [Required()]
        public Int64 CampChsAnnee { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("CAMP_CHS__LIAISON",Order=5)]
        [Required()]
        [MaxLength(15)] 
        public String CampChsLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CAMP_CHS__SENS",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String CampChsSens { get; set; }
        
        [Key]
        [Description("Voie2")]
        [Column("CAMP_CHS__VOIE",Order=7)]
        [Required()]
        [MaxLength(6)] 
        public String CampChsVoie { get; set; }
        
        [Key]
        [Description("Année calculs")]
        [Column("ANNEE_CALC",Order=8)]
        [Required()]
        public Int64 AnneeCalc { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=9)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Fin")]
        [Column("ABS_FIN",Order=10)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("VOIE",Order=11)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
    }
}
