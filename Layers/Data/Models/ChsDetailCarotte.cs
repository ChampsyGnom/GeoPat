using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DETAIL_CAROTTE_CHS",Schema="CHS")]
    public partial class ChsDetailCarotte
    {
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
        [Column("DATE_MS",Order=4)]
        [Required()]
        public DateTime DateMs { get; set; }
        
        [Key]
        [Description("Position")]
        [Column("POSIT",Order=5)]
        [Required()]
        public Int64 Posit { get; set; }
        
        [Key]
        [Description("No Ordre sous couche")]
        [Column("NUMORDRE",Order=6)]
        [Required()]
        public Int64 Numordre { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=7)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Couche")]
        [Column("COUCHE",Order=8)]
        [Required()]
        [MaxLength(12)] 
        public String Couche { get; set; }
        
        [Description("Technique")]
        [Column("TECHNIQUE",Order=9)]
        [MaxLength(12)] 
        public String Technique { get; set; }
        
        [Description("Epaisseur (cm)")]
        [Column("EPAIS",Order=10)]
        public Nullable<Double> Epais { get; set; }
        
        [Description("Granulométrie")]
        [Column("GRANULO",Order=11)]
        [MaxLength(6)] 
        public String Granulo { get; set; }
        
        [Description("Sous-couche")]
        [Column("TYPE_SC",Order=12)]
        [MaxLength(25)] 
        public String TypeSc { get; set; }
        
        [Description("Epais SC")]
        [Column("EPAIS_SC",Order=13)]
        public Nullable<Double> EpaisSc { get; set; }
        
        [Description("Durée de service")]
        [Column("DUREE_SERV",Order=14)]
        public Nullable<Double> DureeServ { get; set; }
        
    }
}
