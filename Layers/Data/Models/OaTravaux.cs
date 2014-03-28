using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAVAUX_OA",Schema="OA")]
    public partial class OaTravaux
    {
        public virtual OaDsc OaDsc {get;set;}
        
        public virtual OaNatureTrav OaNatureTrav {get;set;}
        
        public virtual OaCdEntp OaCdEntp {get;set;}
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_OA__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxOaCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE_TRAV_OA__NATURE",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String NatureTravOaNature { get; set; }
        
        [Key]
        [Description("Date Réception")]
        [Column("TRAVAUX_OA__DATE_RCP",Order=3)]
        [Required()]
        public DateTime DateRcp { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_OA__ENTREPRISE",Order=4)]
        [MaxLength(60)] 
        public String CdEntpOaEntreprise { get; set; }
        
        [Description("Fin de garantie")]
        [Column("TRAVAUX_OA__DATE_FIN_GAR",Order=5)]
        public Nullable<DateTime> DateFinGar { get; set; }
        
        [Description("Coûts (€)")]
        [Column("TRAVAUX_OA__COUT",Order=6)]
        public Nullable<Int64> Cout { get; set; }
        
        [Description("No Marché")]
        [Column("TRAVAUX_OA__MARCHE",Order=7)]
        [MaxLength(25)] 
        public String Marche { get; set; }
        
        [Description("Commentaire")]
        [Column("TRAVAUX_OA__COMMENTAIRE",Order=8)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
    }
}
