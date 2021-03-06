using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CAMP_GMS",Schema="GMS")]
    public partial class GmsCamp
    {
        [Key]
        [Description("Identifiant")]
        [Column("ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String IdCamp { get; set; }
        
        [Description("Type de PV")]
        [Column("CD_TYPE_PV_GMS__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdTypePvGmsCode { get; set; }
        
        [Description("Prestataire")]
        [Column("CD_PRESTA_GMS__PRESTATAIRE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String CdPrestaGmsPrestataire { get; set; }
        
        [Description("Année")]
        [Column("ANNEE",Order=3)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("Date maxi retour")]
        [Column("DATER",Order=4)]
        [Required()]
        public DateTime Dater { get; set; }
        
        [Description("Date génération")]
        [Column("DATEG",Order=5)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Nom créateur")]
        [Column("USERG",Order=6)]
        [MaxLength(2555)] 
        public String Userg { get; set; }
        
        [Description("Commentaire")]
        [Column("OBSERV",Order=7)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
