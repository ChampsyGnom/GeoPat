using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("AIRE_INF",Schema="INF")]
    public partial class InfAire
    {
        public virtual InfCdAire InfCdAire {get;set;}
        
        public virtual InfChaussee InfChaussee {get;set;}
        
        public virtual ICollection<InfAirePrestataire> InfAirePrestataires { get; set; }
        
        public virtual ICollection<InfAireService> InfAireServices { get; set; }
        
        public virtual ICollection<InfAirePlace> InfAirePlaces { get; set; }
        
        [Key]
        [Description("Type Aire")]
        [Column("CD_AIRE_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdAireInfType { get; set; }
        
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
        [Description("Début")]
        [Column("AIRE_INF__ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("N° Exploitation")]
        [Column("AIRE_INF__NUM_EXPLOIT",Order=4)]
        [MaxLength(15)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("AIRE_INF__NOM",Order=5)]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
        [Description("Date MS")]
        [Column("AIRE_INF__DATE_MS",Order=6)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Passerelle")]
        [Column("AIRE_INF__PASSERELLE",Order=7)]
        public Nullable<Boolean> Passerelle { get; set; }
        
        [Description("Demi tour")]
        [Column("AIRE_INF__DEMI_TOUR",Order=8)]
        public Nullable<Boolean> DemiTour { get; set; }
        
        [Description("Bilatérale")]
        [Column("AIRE_INF__BILATERALE",Order=9)]
        public Nullable<Boolean> Bilaterale { get; set; }
        
        [Description("Commentaires")]
        [Column("AIRE_INF__OBSERV",Order=10)]
        [MaxLength(250)] 
        public String Observ { get; set; }
        
        [Description("X1")]
        [Column("AIRE_INF__X1",Order=11)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("AIRE_INF__Y1",Order=12)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("AIRE_INF__Z1",Order=13)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("AIRE_INF__DATE_RELEVE",Order=14)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("AIRE_INF__TERRAIN",Order=15)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
