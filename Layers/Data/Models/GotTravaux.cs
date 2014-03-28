using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAVAUX_GOT",Schema="GOT")]
    public partial class GotTravaux
    {
        public virtual GotDsc GotDsc {get;set;}
        
        public virtual GotNatureTrav GotNatureTrav {get;set;}
        
        public virtual GotCdEntp GotCdEntp {get;set;}
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_GOT__NUM_GOT",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Key]
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_GOT__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxGotCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE_TRAV_GOT__NATURE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String NatureTravGotNature { get; set; }
        
        [Key]
        [Description("Date réception")]
        [Column("TRAVAUX_GOT__DATE_RCP",Order=3)]
        [Required()]
        public DateTime DateRcp { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GOT__ENTREPRISE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String CdEntpGotEntreprise { get; set; }
        
        [Description("Date fin de garantie")]
        [Column("TRAVAUX_GOT__DATE_FIN_GAR",Order=5)]
        public Nullable<DateTime> DateFinGar { get; set; }
        
        [Description("Coûts (€)")]
        [Column("TRAVAUX_GOT__COUT",Order=6)]
        public Nullable<Int64> Cout { get; set; }
        
        [Description("No Marché")]
        [Column("TRAVAUX_GOT__MARCHE",Order=7)]
        [MaxLength(25)] 
        public String Marche { get; set; }
        
        [Description("Commentaire")]
        [Column("TRAVAUX_GOT__COMMENTAIRE",Order=8)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
    }
}
