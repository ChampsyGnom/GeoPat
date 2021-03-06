using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_SV_EQP",Schema="EQP")]
    public partial class EqpDscSv
    {
        [Key]
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Key]
        [Description("N°  Exploitation")]
        [Column("NUM_EXPLOIT",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Type fondation")]
        [Column("CD_FONDATION_EQP__FONDATION",Order=2)]
        [MaxLength(60)] 
        public String CdFondationEqpFondation { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=3)]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("Type support")]
        [Column("CD_SUPPORT_SV_EQP__SUPPORT",Order=4)]
        [MaxLength(60)] 
        public String CdSupportSvEqpSupport { get; set; }
        
        [Description("Protection")]
        [Column("CD_PROTECT_EQP__PROTECT",Order=5)]
        [MaxLength(60)] 
        public String CdProtectEqpProtect { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String CdFamSvEqpFamille { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=7)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=8)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR Début")]
        [Column("ABS_DEB",Order=9)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=10)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Massif")]
        [Column("MASSIF",Order=11)]
        [MaxLength(20)] 
        public String Massif { get; set; }
        
        [Description("Nbre de support")]
        [Column("NBRE_SUPPORT",Order=12)]
        public Nullable<Int64> NbreSupport { get; set; }
        
        [Description("Classe de flexion")]
        [Column("RESIST",Order=13)]
        public Nullable<Int64> Resist { get; set; }
        
        [Description("Eclairage")]
        [Column("ECLAIRAGE",Order=14)]
        public Nullable<Boolean> Eclairage { get; set; }
        
        [Description("Accessibilité")]
        [Column("ACCESSIBILITE",Order=15)]
        public Nullable<Boolean> Accessibilite { get; set; }
        
        [Description("Hauteur sous panneau (m)")]
        [Column("HAUTEUR_SP",Order=16)]
        public Nullable<Double> HauteurSp { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=17)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=18)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=19)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=20)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=21)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=22)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
