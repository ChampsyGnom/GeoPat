using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("VST_OH",Schema="OH")]
    public partial class OhVst
    {
        public virtual OhCamp OhCamp {get;set;}
        
        public virtual OhDsc OhDsc {get;set;}
        
        public virtual OhInspecteur OhInspecteur {get;set;}
        
        public virtual ICollection<OhSprtVst> OhSprtVsts { get; set; }
        
        public virtual ICollection<OhPhotoVst> OhPhotoVsts { get; set; }
        
        public virtual ICollection<OhEntete> OhEntetes { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Key]
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_OH__NOM",Order=2)]
        [MaxLength(60)] 
        public String InspecteurOhNom { get; set; }
        
        [Description("Statut visite")]
        [Column("VST_OH__ETAT",Order=3)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("VST_OH__DATEV",Order=4)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Urgence traitement")]
        [Column("VST_OH__PRIORITAIRE",Order=5)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Observation")]
        [Column("VST_OH__OBSERV",Order=6)]
        [MaxLength(500)] 
        public String Observ { get; set; }
        
        [Description("Note Visite")]
        [Column("VST_OH__NOTE_VST",Order=7)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
    }
}
