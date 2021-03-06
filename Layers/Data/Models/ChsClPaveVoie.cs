using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CL_PAVE_VOIE_CHS",Schema="CHS")]
    public partial class ChsClPaveVoie
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
        [Description("Voie")]
        [Column("PAVE_VOIE_CHS__VOIE",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String PaveVoieChsVoie { get; set; }
        
        [Key]
        [Description("Début Voie")]
        [Column("PAVE_VOIE_CHS__VOIEDEB",Order=7)]
        [Required()]
        public Int64 PaveVoieChsVoiedeb { get; set; }
        
        [Key]
        [Description("Fin voie")]
        [Column("PAVE_VOIE_CHS__VOIEFIN",Order=8)]
        [Required()]
        public Int64 PaveVoieChsVoiefin { get; set; }
        
        [Key]
        [Description("Début pavé voie")]
        [Column("ABS_DEB",Order=9)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin pavé voie")]
        [Column("ABS_FIN",Order=10)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
    }
}
