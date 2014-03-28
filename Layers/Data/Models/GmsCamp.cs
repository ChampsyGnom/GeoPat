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
        public virtual GmsCdPresta GmsCdPresta {get;set;}
        
        public virtual GmsCdTypePv GmsCdTypePv {get;set;}
        
        public virtual ICollection<GmsInsp> GmsInsps { get; set; }
        
        public virtual ICollection<GmsVst> GmsVsts { get; set; }
        
        public virtual ICollection<GmsDscTemp> GmsDscTemps { get; set; }
        
        public virtual ICollection<GmsDscCamp> GmsDscCamps { get; set; }
        
        [Key]
        [Description("Identifiant")]
        [Column("CAMP_GMS__ID_CAMP",Order=0)]
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
        [Column("CAMP_GMS__ANNEE",Order=3)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("Date maxi retour")]
        [Column("CAMP_GMS__DATER",Order=4)]
        [Required()]
        public DateTime Dater { get; set; }
        
        [Description("Date génération")]
        [Column("CAMP_GMS__DATEG",Order=5)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Nom créateur")]
        [Column("CAMP_GMS__USERG",Order=6)]
        [MaxLength(2555)] 
        public String Userg { get; set; }
        
        [Description("Commentaire")]
        [Column("CAMP_GMS__OBSERV",Order=7)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
