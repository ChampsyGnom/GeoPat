using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CL_ROUL_CHS",Schema="CHS")]
    public partial class ChsClRoul
    {
        public virtual ChsClCarotte ChsClCarotte {get;set;}
        
        [Key]
        [Description("Liaison")]
        [Column("CL_CAROTTE_CHS__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String ClCarotteChsLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CL_CAROTTE_CHS__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String ClCarotteChsSens { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("CL_CAROTTE_CHS__VOIE",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String ClCarotteChsVoie { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("CL_CAROTTE_CHS__ABS_DEB",Order=3)]
        [Required()]
        public Int64 ClCarotteChsAbsDeb { get; set; }
        
        [Key]
        [Description("Date MS")]
        [Column("CL_ROUL_CHS__DATE_MS",Order=4)]
        [Required()]
        public DateTime DateMs { get; set; }
        
        [Description("Pr fin")]
        [Column("CL_ROUL_CHS__ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Technique")]
        [Column("CL_ROUL_CHS__TECHNIQUE",Order=6)]
        [MaxLength(12)] 
        public String Technique { get; set; }
        
        [Description("Epaisseur")]
        [Column("CL_ROUL_CHS__EPAIS",Order=7)]
        public Nullable<Double> Epais { get; set; }
        
        [Description("Granulométrie")]
        [Column("CL_ROUL_CHS__GRANULO",Order=8)]
        [MaxLength(6)] 
        public String Granulo { get; set; }
        
    }
}
