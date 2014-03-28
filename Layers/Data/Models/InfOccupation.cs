using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("OCCUPATION_INF",Schema="INF")]
    public partial class InfOccupation
    {
        public virtual InfCdOccup InfCdOccup {get;set;}
        
        public virtual InfCdOccupant InfCdOccupant {get;set;}
        
        public virtual InfChaussee InfChaussee {get;set;}
        
        [Key]
        [Description("Type Occupation")]
        [Column("CD_OCCUP_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdOccupInfType { get; set; }
        
        [Key]
        [Description("Nom")]
        [Column("CD_OCCUPANT_INF__NOM",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdOccupantInfNom { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("OCCUPATION_INF__ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("OCCUPATION_INF__ABS_FIN",Order=5)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date Début")]
        [Column("OCCUPATION_INF__DATE_MS",Order=6)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Date Fin")]
        [Column("OCCUPATION_INF__DATE_FV",Order=7)]
        public Nullable<DateTime> DateFv { get; set; }
        
        [Description("Traversé")]
        [Column("OCCUPATION_INF__TRAV",Order=8)]
        public Nullable<Boolean> Trav { get; set; }
        
        [Description("Commentaire")]
        [Column("OCCUPATION_INF__OBS",Order=9)]
        [MaxLength(255)] 
        public String Obs { get; set; }
        
    }
}
