using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_DV_EQP",Schema="EQP")]
    public partial class EqpDscDv
    {
        public virtual EqpCdPosit EqpCdPosit {get;set;}
        
        public virtual EqpCdFabricant EqpCdFabricant {get;set;}
        
        public virtual EqpCdEntp EqpCdEntp {get;set;}
        
        public virtual EqpCdTypeDv EqpCdTypeDv {get;set;}
        
        [Key]
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_TYPE_DV_EQP__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdTypeDvEqpCode { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("DSC_DV_EQP__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("DSC_DV_EQP__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Pr début")]
        [Column("DSC_DV_EQP__ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("DSC_DV_EQP__NUM_EXPLOIT",Order=5)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=6)]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=7)]
        [MaxLength(60)] 
        public String CdFabricantEqpNom { get; set; }
        
        [Description("Pr fin")]
        [Column("DSC_DV_EQP__ABS_FIN",Order=8)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_DV_EQP__DATE_MS",Order=9)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Alimentation")]
        [Column("DSC_DV_EQP__ALIMENTATION",Order=10)]
        [MaxLength(60)] 
        public String Alimentation { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_DV_EQP__COMMENTAIRE",Order=11)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
