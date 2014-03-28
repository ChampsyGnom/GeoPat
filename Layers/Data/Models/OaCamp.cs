using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CAMP_OA",Schema="OA")]
    public partial class OaCamp
    {
        public virtual OaCdPresta OaCdPresta {get;set;}
        
        public virtual OaCdTypePv OaCdTypePv {get;set;}
        
        public virtual ICollection<OaVst> OaVsts { get; set; }
        
        public virtual ICollection<OaInsp> OaInsps { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        public virtual ICollection<OaDscCamp> OaDscCamps { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String IdCamp { get; set; }
        
        [Description("Type de PV")]
        [Column("CD_TYPE_PV_OA__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdTypePvOaCode { get; set; }
        
        [Description("Prestataire")]
        [Column("CD_PRESTA_OA__PRESTATAIRE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String CdPrestaOaPrestataire { get; set; }
        
        [Description("Année")]
        [Column("CAMP_OA__ANNEE",Order=3)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("Date maxi retour")]
        [Column("CAMP_OA__DATER",Order=4)]
        [Required()]
        public DateTime Dater { get; set; }
        
        [Description("Date génération")]
        [Column("CAMP_OA__DATEG",Order=5)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Nom créateur")]
        [Column("CAMP_OA__USERG",Order=6)]
        [MaxLength(255)] 
        public String Userg { get; set; }
        
        [Description("Commentaire")]
        [Column("CAMP_OA__OBSERV",Order=7)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
