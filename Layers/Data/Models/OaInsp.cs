using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_OA",Schema="OA")]
    public partial class OaInsp
    {
        public virtual OaDsc OaDsc {get;set;}
        
        public virtual OaCdMeteo OaCdMeteo {get;set;}
        
        public virtual OaCdEtude OaCdEtude {get;set;}
        
        public virtual OaCdIqoa OaCdIqoa {get;set;}
        
        public virtual OaCamp OaCamp {get;set;}
        
        public virtual OaInspecteur OaInspecteur {get;set;}
        
        public virtual ICollection<OaEltInsp> OaEltInsps { get; set; }
        
        public virtual ICollection<OaPhotoInsp> OaPhotoInsps { get; set; }
        
        public virtual ICollection<OaCdConclusionInsp> OaCdConclusionInsps { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Description("Condition météo")]
        [Column("CD_METEO_OA__METEO",Order=2)]
        [MaxLength(60)] 
        public String CdMeteoOaMeteo { get; set; }
        
        [Description("Note IQOA")]
        [Column("CD_IQOA_OA__NOTE_IQOA",Order=3)]
        [Required()]
        [MaxLength(3)] 
        public String CdIqoaOaNoteIqoa { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_OA__NOM",Order=4)]
        [MaxLength(60)] 
        public String InspecteurOaNom { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_OA__ETUDE",Order=5)]
        [MaxLength(60)] 
        public String CdEtudeOaEtude { get; set; }
        
        [Description("Statut visite")]
        [Column("INSP_OA__ETAT",Order=6)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("INSP_OA__DATEV",Order=7)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Température")]
        [Column("INSP_OA__TEMPERATURE",Order=8)]
        public Nullable<Double> Temperature { get; set; }
        
        [Description("Moyens utilisés")]
        [Column("INSP_OA__MOYEN",Order=9)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Conditions particulières")]
        [Column("INSP_OA__CONDITIONS",Order=10)]
        [MaxLength(500)] 
        public String Conditions { get; set; }
        
        [Description("Date validation")]
        [Column("INSP_OA__DATE_VALID",Order=11)]
        public Nullable<DateTime> DateValid { get; set; }
        
        [Description("Nom valideur")]
        [Column("INSP_OA__NOM_VALID",Order=12)]
        [MaxLength(255)] 
        public String NomValid { get; set; }
        
        [Description("Description invalide")]
        [Column("INSP_OA__DESC_INVA",Order=13)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Urgence traitement")]
        [Column("INSP_OA__PRIORITAIRE",Order=14)]
        [MaxLength(1000)] 
        public String Prioritaire { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("INSP_OA__SECURITE",Order=15)]
        [MaxLength(1000)] 
        public String Securite { get; set; }
        
        [Description("Appuis-Fondations")]
        [Column("INSP_OA__NOTE1",Order=16)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Tabliers")]
        [Column("INSP_OA__NOTE2",Order=17)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Equipements")]
        [Column("INSP_OA__NOTE3",Order=18)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Niveau urgence")]
        [Column("INSP_OA__URGENCE",Order=19)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Image qualité")]
        [Column("INSP_OA__QUALITE",Order=20)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
