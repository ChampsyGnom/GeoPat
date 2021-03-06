using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_TMP_GOT",Schema="GOT")]
    public partial class GotInspTmp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_GOT__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampGotIdCamp { get; set; }
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_TEMP_GOT__NUM_GOT",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscTempGotNumGot { get; set; }
        
        [Description("Condition météo")]
        [Column("CD_METEO_GOT__METEO",Order=2)]
        [MaxLength(60)] 
        public String CdMeteoGotMeteo { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_GOT__ETUDE",Order=3)]
        [MaxLength(65)] 
        public String CdEtudeGotEtude { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_GOT__NOM",Order=4)]
        [MaxLength(60)] 
        public String InspecteurGotNom { get; set; }
        
        [Description("Statut visite")]
        [Column("ETAT",Order=5)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("DATEV",Order=6)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Température")]
        [Column("TEMPERATURE",Order=7)]
        public Nullable<Double> Temperature { get; set; }
        
        [Description("Moyens utilisés")]
        [Column("MOYEN",Order=8)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Conditions particulières")]
        [Column("CONDITIONS",Order=9)]
        [MaxLength(500)] 
        public String Conditions { get; set; }
        
        [Description("Date de validation")]
        [Column("DATE_VALID",Order=10)]
        public Nullable<DateTime> DateValid { get; set; }
        
        [Description("Nom valideur")]
        [Column("NOM_VALID",Order=11)]
        [MaxLength(255)] 
        public String NomValid { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=12)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=13)]
        [MaxLength(1000)] 
        public String Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=14)]
        [MaxLength(1000)] 
        public String Prioritaire { get; set; }
        
        [Description("Note Plateforme 1")]
        [Column("NOTE1",Order=15)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Plateforme 2")]
        [Column("NOTE2",Order=16)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Talus 1")]
        [Column("NOTE3",Order=17)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Talus 2")]
        [Column("NOTE4",Order=18)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Environnement")]
        [Column("NOTE5",Order=19)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Note urgence")]
        [Column("URGENCE",Order=20)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Note qualité")]
        [Column("QUALITE",Order=21)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
