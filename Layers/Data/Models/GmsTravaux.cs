using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAVAUX_GMS",Schema="GMS")]
    public partial class GmsTravaux
    {
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_GMS__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxGmsCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE_TRAV_GMS__NATURE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String NatureTravGmsNature { get; set; }
        
        [Key]
        [Description("Date réception")]
        [Column("DATE_RCP",Order=3)]
        [Required()]
        public DateTime DateRcp { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GMS__ENTREPRISE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String CdEntpGmsEntreprise { get; set; }
        
        [Description("Date fin de garantie")]
        [Column("DATE_FIN_GAR",Order=5)]
        public Nullable<DateTime> DateFinGar { get; set; }
        
        [Description("Coûts (€)")]
        [Column("COUT",Order=6)]
        public Nullable<Int64> Cout { get; set; }
        
        [Description("No Marché")]
        [Column("MARCHE",Order=7)]
        [MaxLength(25)] 
        public String Marche { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=8)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
    }
}
