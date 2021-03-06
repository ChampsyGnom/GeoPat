using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_CHS",Schema="CHS")]
    public partial class ChsPrevision
    {
        [Key]
        [Description("Technique")]
        [Column("BPU_CHS__CODE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String BpuChsCode { get; set; }
        
        [Key]
        [Description("Année")]
        [Column("ANNEE",Order=1)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("VOIE",Order=4)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=5)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Contrainte")]
        [Column("CD_CONTRAINTE_CHS__TYPE",Order=6)]
        [MaxLength(100)] 
        public String CdContrainteChsType { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=7)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Coût (€)")]
        [Column("MONTANT",Order=8)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date début")]
        [Column("DATE_DEBUT",Order=9)]
        public Nullable<DateTime> DateDebut { get; set; }
        
        [Description("Date fin")]
        [Column("DATE_FIN",Order=10)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Date demande publication")]
        [Column("DATE_DEM_PUB",Order=11)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Réalisé")]
        [Column("REALISE",Order=12)]
        public Nullable<Boolean> Realise { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=13)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
