using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CAMP_GOT",Schema="GOT")]
    public partial class GotCamp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String IdCamp { get; set; }
        
        [Description("Type de PV")]
        [Column("CD_TYPE_PV_GOT__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdTypePvGotCode { get; set; }
        
        [Description("Prestataire")]
        [Column("CD_PRESTA_GOT__PRESTATAIRE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String CdPrestaGotPrestataire { get; set; }
        
        [Description("Année")]
        [Column("ANNEE",Order=3)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("Date maxi retour")]
        [Column("DATER",Order=4)]
        [Required()]
        public DateTime Dater { get; set; }
        
        [Description("Date Génération")]
        [Column("DATEG",Order=5)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Nom créateur")]
        [Column("USERG",Order=6)]
        [MaxLength(255)] 
        public String Userg { get; set; }
        
        [Description("Observation")]
        [Column("OBSERV",Order=7)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
