using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_PO_EQP",Schema="EQP")]
    public partial class EqpDscPo
    {
        public virtual EqpCdPortail EqpCdPortail {get;set;}
        
        public virtual EqpCdFabricant EqpCdFabricant {get;set;}
        
        public virtual EqpCdEntp EqpCdEntp {get;set;}
        
        public virtual EqpCdPosit EqpCdPosit {get;set;}
        
        [Key]
        [Description("N° d'exploitation")]
        [Column("DSC_PO_EQP__NUM_EXPLOIT",Order=0)]
        [Required()]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=1)]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("Portail")]
        [Column("CD_PORTAIL_EQP__PORTAIL",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdPortailEqpPortail { get; set; }
        
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=3)]
        [MaxLength(60)] 
        public String CdFabricantEqpNom { get; set; }
        
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=4)]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_PO_EQP__LIAISON",Order=5)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_PO_EQP__SENS",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("DSC_PO_EQP__ABS_DEB",Order=7)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_PO_EQP__DATE_MS",Order=8)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Largeur (m)")]
        [Column("DSC_PO_EQP__LARGEUR",Order=9)]
        public Nullable<Double> Largeur { get; set; }
        
        [Description("Hauteur (m)")]
        [Column("DSC_PO_EQP__HAUTEUR",Order=10)]
        public Nullable<Double> Hauteur { get; set; }
        
        [Description("Dispositif accès")]
        [Column("DSC_PO_EQP__DISPO_ACCES",Order=11)]
        public Nullable<Boolean> DispoAcces { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_PO_EQP__COMMENTAIRE",Order=12)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("DSC_PO_EQP__X1",Order=13)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("DSC_PO_EQP__Y1",Order=14)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("DSC_PO_EQP__Z1",Order=15)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DSC_PO_EQP__DATE_RELEVE",Order=16)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("DSC_PO_EQP__TERRAIN",Order=17)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
