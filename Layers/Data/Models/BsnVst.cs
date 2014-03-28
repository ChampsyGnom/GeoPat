using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("VST_BSN",Schema="BSN")]
    public partial class BsnVst
    {
        public virtual BsnCamp BsnCamp {get;set;}
        
        public virtual BsnDsc BsnDsc {get;set;}
        
        public virtual BsnInspecteur BsnInspecteur {get;set;}
        
        public virtual ICollection<BsnSprtVst> BsnSprtVsts { get; set; }
        
        public virtual ICollection<BsnPhotoVst> BsnPhotoVsts { get; set; }
        
        public virtual ICollection<BsnEntete> BsnEntetes { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_BSN__NOM",Order=2)]
        [MaxLength(60)] 
        public String InspecteurBsnNom { get; set; }
        
        [Description("Statut visite")]
        [Column("VST_BSN__ETAT",Order=3)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("VST_BSN__DATEV",Order=4)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Urgence traitement")]
        [Column("VST_BSN__PRIORITAIRE",Order=5)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Observation")]
        [Column("VST_BSN__OBSERV",Order=6)]
        [MaxLength(500)] 
        public String Observ { get; set; }
        
        [Description("Note Visite")]
        [Column("VST_BSN__NOTE_VST",Order=7)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
    }
}
