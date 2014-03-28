using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BIFURCATION_INF",Schema="INF")]
    public partial class InfBifurcation
    {
        public virtual InfCdBif InfCdBif {get;set;}
        
        public virtual InfChaussee InfChaussee {get;set;}
        
        [Key]
        [Description("Type Bifurcation")]
        [Column("CD_BIF_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdBifInfType { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Pr Axe")]
        [Column("BIFURCATION_INF__ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Nom d'usage")]
        [Column("BIFURCATION_INF__NOM",Order=4)]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
        [Description("N° Exploitation")]
        [Column("BIFURCATION_INF__NUM_EXPLOIT",Order=5)]
        [MaxLength(15)] 
        public String NumExploit { get; set; }
        
        [Description("Date MS")]
        [Column("BIFURCATION_INF__DATE_MS",Order=6)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Commentaire")]
        [Column("BIFURCATION_INF__OBSERV",Order=7)]
        [MaxLength(250)] 
        public String Observ { get; set; }
        
        [Description("X1")]
        [Column("BIFURCATION_INF__X1",Order=8)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("BIFURCATION_INF__Y1",Order=9)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("BIFURCATION_INF__Z1",Order=10)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("BIFURCATION_INF__DATE_RELEVE",Order=11)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("BIFURCATION_INF__TERRAIN",Order=12)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
