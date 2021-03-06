using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SOUS_COUCHE_CHS",Schema="CHS")]
    public partial class ChsSousCouche
    {
        [Key]
        [Description("Couche")]
        [Column("CD_COU_CHS__COUCHE",Order=0)]
        [Required()]
        [MaxLength(14)] 
        public String CdCouChsCouche { get; set; }
        
        [Key]
        [Description("Date MS")]
        [Column("PAVE_CHS__DATE_MS",Order=1)]
        [Required()]
        public DateTime PaveChsDateMs { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("PAVE_CHS__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String PaveChsLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("PAVE_CHS__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String PaveChsSens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("PAVE_CHS__ABS_DEB",Order=4)]
        [Required()]
        public Int64 PaveChsAbsDeb { get; set; }
        
        [Key]
        [Description("Fin")]
        [Column("PAVE_CHS__ABS_FIN",Order=5)]
        [Required()]
        public Int64 PaveChsAbsFin { get; set; }
        
        [Key]
        [Description("No Ordre")]
        [Column("NUMORDRE",Order=6)]
        [Required()]
        public Int64 Numordre { get; set; }
        
        [Description("Famille technique")]
        [Column("CD_FAM_TECH_CHS__CODE",Order=7)]
        [Required()]
        [MaxLength(15)] 
        public String CdFamTechChsCode { get; set; }
        
        [Description("Technique")]
        [Column("CD_TECH_CHS__TECHNIQUE",Order=8)]
        [Required()]
        [MaxLength(12)] 
        public String CdTechChsTechnique { get; set; }
        
        [Description("Epaisseur (cm)")]
        [Column("EPAIS",Order=9)]
        [Required()]
        public Double Epais { get; set; }
        
        [Description("Dosage")]
        [Column("DOSAGE",Order=10)]
        [MaxLength(5)] 
        public String Dosage { get; set; }
        
    }
}
