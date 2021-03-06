using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("COUCHE_GOT",Schema="GOT")]
    public partial class GotCouche
    {
        [Key]
        [Description("Code couche")]
        [Column("CD_COUCHE_GOT__CODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String CdCoucheGotCode { get; set; }
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_GOT__NUM_GOT",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Key]
        [Description("Traitement")]
        [Column("CD_TRAITEMENT_GOT__TYPE",Order=2)]
        [Required()]
        [MaxLength(25)] 
        public String CdTraitementGotType { get; set; }
        
        [Key]
        [Description("Etat hydrique")]
        [Column("CD_HYDRIQUE_GOT__ETAT",Order=3)]
        [Required()]
        [MaxLength(25)] 
        public String CdHydriqueGotEtat { get; set; }
        
        [Key]
        [Description("Matériaux")]
        [Column("CD_MATERIAU_GOT__TYPE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String CdMateriauGotType { get; set; }
        
        [Key]
        [Description("Compactage")]
        [Column("CD_COMPACTAGE_GOT__CODE",Order=5)]
        [Required()]
        [MaxLength(50)] 
        public String CdCompactageGotCode { get; set; }
        
        [Description("Epaisseur (m)")]
        [Column("EPAI",Order=6)]
        public Nullable<Double> Epai { get; set; }
        
        [Description("Observation")]
        [Column("OBS",Order=7)]
        [MaxLength(255)] 
        public String Obs { get; set; }
        
    }
}
