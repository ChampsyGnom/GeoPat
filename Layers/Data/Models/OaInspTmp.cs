using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_TMP_OA",Schema="OA")]
    public partial class OaInspTmp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_TEMP_OA__NUM_OA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempOaNumOa { get; set; }
        
        [Description("Note IQOA")]
        [Column("CD_IQOA_OA__NOTE_IQOA",Order=2)]
        [Required()]
        [MaxLength(3)] 
        public String CdIqoaOaNoteIqoa { get; set; }
        
        [Description("Condition météo")]
        [Column("CD_METEO_OA__METEO",Order=3)]
        [MaxLength(60)] 
        public String CdMeteoOaMeteo { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_OA__ETUDE",Order=4)]
        [MaxLength(60)] 
        public String CdEtudeOaEtude { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_OA__NOM",Order=5)]
        [MaxLength(60)] 
        public String InspecteurOaNom { get; set; }
        
        [Description("Statut visite")]
        [Column("ETAT",Order=6)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("DATEV",Order=7)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Température")]
        [Column("TEMPERATURE",Order=8)]
        public Nullable<Double> Temperature { get; set; }
        
        [Description("Moyens utilisés")]
        [Column("MOYEN",Order=9)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Conditions particulières")]
        [Column("CONDITIONS",Order=10)]
        [MaxLength(500)] 
        public String Conditions { get; set; }
        
        [Description("Date validation")]
        [Column("DATE_VALID",Order=11)]
        public Nullable<DateTime> DateValid { get; set; }
        
        [Description("Nom valideur")]
        [Column("NOM_VALID",Order=12)]
        [MaxLength(255)] 
        public String NomValid { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=13)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=14)]
        [MaxLength(1000)] 
        public String Prioritaire { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=15)]
        [MaxLength(1000)] 
        public String Securite { get; set; }
        
        [Description("Appuis-Fondations")]
        [Column("NOTE1",Order=16)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Tabliers")]
        [Column("NOTE2",Order=17)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Equipements")]
        [Column("NOTE3",Order=18)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Niveau urgence")]
        [Column("URGENCE",Order=19)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Image qualité")]
        [Column("QUALITE",Order=20)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
