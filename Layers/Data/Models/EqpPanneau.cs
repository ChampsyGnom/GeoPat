using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PANNEAU_EQP",Schema="EQP")]
    public partial class EqpPanneau
    {
        [Key]
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Key]
        [Description("N°  Exploitation")]
        [Column("DSC_SV_EQP__NUM_EXPLOIT",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String DscSvEqpNumExploit { get; set; }
        
        [Key]
        [Description("N° ORDRE")]
        [Column("ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String CdFamSvEqpFamille { get; set; }
        
        [Description("Type")]
        [Column("CD_TYPE_SV_EQP__TYPE",Order=4)]
        [Required()]
        [MaxLength(12)] 
        public String CdTypeSvEqpType { get; set; }
        
        [Description("Sous type")]
        [Column("CD_STYPE_SV_EQP__S_TYPE",Order=5)]
        [Required()]
        [MaxLength(60)] 
        public String CdStypeSvEqpSType { get; set; }
        
        [Description("Gamme")]
        [Column("CD_GAMME_SV_EQP__GAMME",Order=6)]
        [MaxLength(20)] 
        public String CdGammeSvEqpGamme { get; set; }
        
        [Description("Classe du film")]
        [Column("CD_CLASSE_SV_EQP__CLASSE",Order=7)]
        [MaxLength(5)] 
        public String CdClasseSvEqpClasse { get; set; }
        
        [Description("Matériaux")]
        [Column("CD_MAT_SV_EQP__MATERIAUX",Order=8)]
        [MaxLength(60)] 
        public String CdMatSvEqpMateriaux { get; set; }
        
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=9)]
        [MaxLength(60)] 
        public String CdFabricantEqpNom { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=10)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Hauteur (mm)")]
        [Column("HAUTEUR",Order=11)]
        public Nullable<Int64> Hauteur { get; set; }
        
        [Description("Largeur (mm)")]
        [Column("LARGEUR",Order=12)]
        public Nullable<Int64> Largeur { get; set; }
        
        [Description("Réserve")]
        [Column("RESERVE",Order=13)]
        public Nullable<Int64> Reserve { get; set; }
        
        [Description("Anti Graffiti")]
        [Column("ANTI_GRAFFITI",Order=14)]
        public Nullable<Boolean> AntiGraffiti { get; set; }
        
        [Description("Mention")]
        [Column("MENTION",Order=15)]
        [MaxLength(255)] 
        public String Mention { get; set; }
        
    }
}
