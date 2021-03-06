using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PAVE_CHS",Schema="CHS")]
    public partial class ChsPave
    {
        [Key]
        [Description("Couche")]
        [Column("CD_COU_CHS__COUCHE",Order=0)]
        [Required()]
        [MaxLength(14)] 
        public String CdCouChsCouche { get; set; }
        
        [Key]
        [Description("Date MS")]
        [Column("DATE_MS",Order=1)]
        [Required()]
        public DateTime DateMs { get; set; }
        
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
        [Description("Début")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_CHS__ENTREPRISE",Order=6)]
        [MaxLength(60)] 
        public String CdEntpChsEntreprise { get; set; }
        
        [Description("Cause")]
        [Column("CD_CAUSE_CHS__CAUSE",Order=7)]
        [MaxLength(60)] 
        public String CdCauseChsCause { get; set; }
        
        [Description("Maître d'oeuvre")]
        [Column("CD_MO_CHS__MO",Order=8)]
        [MaxLength(25)] 
        public String CdMoChsMo { get; set; }
        
        [Description("Famille technique")]
        [Column("CD_FAM_TECH_CHS__CODE",Order=9)]
        [Required()]
        [MaxLength(15)] 
        public String CdFamTechChsCode { get; set; }
        
        [Description("Technique")]
        [Column("CD_TECH_CHS__TECHNIQUE",Order=10)]
        [Required()]
        [MaxLength(12)] 
        public String CdTechChsTechnique { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_CHS__CODE",Order=11)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxChsCode { get; set; }
        
        [Description("Largeur (m)")]
        [Column("LARGEUR",Order=12)]
        public Nullable<Double> Largeur { get; set; }
        
        [Description("Epaisseur (cm)")]
        [Column("EPAIS",Order=13)]
        [Required()]
        public Double Epais { get; set; }
        
        [Description("Granulométrie")]
        [Column("GRANULO",Order=14)]
        [MaxLength(6)] 
        public String Granulo { get; set; }
        
        [Description("Durée de vie")]
        [Column("DUREE_VIE",Order=15)]
        public Nullable<Double> DureeVie { get; set; }
        
        [Description("Archive")]
        [Column("ARCHIVE",Order=16)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("N° Marché")]
        [Column("MARCHE",Order=17)]
        [MaxLength(25)] 
        public String Marche { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=18)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Montant (€)")]
        [Column("MONTANT",Order=19)]
        public Nullable<Int64> Montant { get; set; }
        
    }
}
