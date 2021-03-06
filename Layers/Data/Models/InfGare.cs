using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("GARE_INF",Schema="INF")]
    public partial class InfGare
    {
        [Key]
        [Description("Type Gare")]
        [Column("CD_GARE_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdGareInfType { get; set; }
        
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
        [Description("Pr")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("N° Exploitation")]
        [Column("NUM_EXPLOIT",Order=4)]
        [MaxLength(15)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM",Order=5)]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=6)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Nbr Voies Entrée")]
        [Column("VOI_ENTREE",Order=7)]
        public Nullable<Int64> VoiEntree { get; set; }
        
        [Description("Nbr Voies Sortie")]
        [Column("VOI_SORTIE",Order=8)]
        public Nullable<Int64> VoiSortie { get; set; }
        
        [Description("Nbr Voies Mixte")]
        [Column("VOI_MIXTE",Order=9)]
        public Nullable<Int64> VoiMixte { get; set; }
        
        [Description("Nbr Voies TSA")]
        [Column("VOI_TSA",Order=10)]
        public Nullable<Int64> VoiTsa { get; set; }
        
        [Description("Commentaire")]
        [Column("OBSERV",Order=11)]
        [MaxLength(250)] 
        public String Observ { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=12)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=13)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=14)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=15)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=16)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
