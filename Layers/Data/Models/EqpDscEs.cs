using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_ES_EQP",Schema="EQP")]
    public partial class EqpDscEs
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
        [Description("Sens")]
        [Column("SENS",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("PR début")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("N° Exploitation")]
        [Column("NUM_EXPLOIT",Order=4)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=5)]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("Extrémité fin")]
        [Column("CD_EXT_AV_EQP__EXT_FIN",Order=6)]
        [MaxLength(60)] 
        public String CdExtAvEqpExtFin { get; set; }
        
        [Description("Nom Fabricant")]
        [Column("CD_FABRICANT_EQP__NOM",Order=7)]
        [MaxLength(60)] 
        public String CdFabricantEqpNom { get; set; }
        
        [Description("Matériaux")]
        [Column("CD_MATERIAU_EQP__MATERIAUX",Order=8)]
        [Required()]
        [MaxLength(60)] 
        public String CdMateriauEqpMateriaux { get; set; }
        
        [Description("Type de Dispositif")]
        [Column("CD_RETENUE_EQP__DISPOSITIF",Order=9)]
        [Required()]
        [MaxLength(60)] 
        public String CdRetenueEqpDispositif { get; set; }
        
        [Description("Extrémité début")]
        [Column("CD_EXT_AM_EQP__EXT_DEB",Order=10)]
        [MaxLength(60)] 
        public String CdExtAmEqpExtDeb { get; set; }
        
        [Description("PR fin")]
        [Column("ABS_FIN",Order=11)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=12)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=13)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=14)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=15)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=16)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("X2")]
        [Column("X2",Order=17)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("Y2",Order=18)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("Z2",Order=19)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=20)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=21)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
