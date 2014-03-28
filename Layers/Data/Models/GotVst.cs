using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("VST_GOT",Schema="GOT")]
    public partial class GotVst
    {
        public virtual GotDsc GotDsc {get;set;}
        
        public virtual GotCamp GotCamp {get;set;}
        
        public virtual GotInspecteur GotInspecteur {get;set;}
        
        public virtual ICollection<GotPhotoVst> GotPhotoVsts { get; set; }
        
        public virtual ICollection<GotSprtVst> GotSprtVsts { get; set; }
        
        public virtual ICollection<GotEntete> GotEntetes { get; set; }
        
        public virtual ICollection<GotCdPrecoSprtVst> GotCdPrecoSprtVsts { get; set; }
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_GOT__NUM_GOT",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_GOT__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampGotIdCamp { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_GOT__NOM",Order=2)]
        [MaxLength(60)] 
        public String InspecteurGotNom { get; set; }
        
        [Description("Statut visite")]
        [Column("VST_GOT__ETAT",Order=3)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("VST_GOT__DATEV",Order=4)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Urgence traitement")]
        [Column("VST_GOT__PRIORITAIRE",Order=5)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Observation")]
        [Column("VST_GOT__OBSERV",Order=6)]
        [MaxLength(500)] 
        public String Observ { get; set; }
        
        [Description("Note Visite")]
        [Column("VST_GOT__NOTE_VST",Order=7)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
    }
}
