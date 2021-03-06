using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_SH_EQP",Schema="EQP")]
    public partial class EqpDscSh
    {
        [Key]
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("PR début")]
        [Column("ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("N° Exploitation")]
        [Column("NUM_EXPLOIT",Order=4)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Modulation")]
        [Column("CD_MOD_SH_EQP__MOD",Order=5)]
        [Required()]
        [MaxLength(6)] 
        public String CdModShEqpMod { get; set; }
        
        [Description("Marquage")]
        [Column("CD_MARQUAGE_SH_EQP__MARQUAGE",Order=6)]
        [Required()]
        [MaxLength(255)] 
        public String CdMarquageShEqpMarquage { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=7)]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("Barette")]
        [Column("CD_BARRETTE_SH_EQP__BARETTE",Order=8)]
        [MaxLength(60)] 
        public String CdBarretteShEqpBarette { get; set; }
        
        [Description("Produit")]
        [Column("CD_PRODUIT_SH_EQP__PRODUIT",Order=9)]
        [MaxLength(60)] 
        public String CdProduitShEqpProduit { get; set; }
        
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=10)]
        [MaxLength(60)] 
        public String CdFabricantEqpNom { get; set; }
        
        [Description("PR fin")]
        [Column("ABS_FIN",Order=11)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=12)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Revêtement VNTP")]
        [Column("REVETEMENT_VNTP",Order=13)]
        public Nullable<Boolean> RevetementVntp { get; set; }
        
        [Description("Produit Saupoudrage")]
        [Column("SAUPOUDRAGE",Order=14)]
        public Nullable<Boolean> Saupoudrage { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=15)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=16)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=17)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=18)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("X2")]
        [Column("X2",Order=19)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("Y2",Order=20)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("Z2",Order=21)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=22)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=23)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
