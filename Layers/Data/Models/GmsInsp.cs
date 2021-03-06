using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_GMS",Schema="GMS")]
    public partial class GmsInsp
    {
        [Key]
        [Description("Identifiant")]
        [Column("CAMP_GMS__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampGmsIdCamp { get; set; }
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_GMS__ETUDE",Order=2)]
        [MaxLength(65)] 
        public String CdEtudeGmsEtude { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_GMS__NOM",Order=3)]
        [MaxLength(60)] 
        public String InspecteurGmsNom { get; set; }
        
        [Description("Condition météo")]
        [Column("CD_METEO_GMS__METEO",Order=4)]
        [MaxLength(60)] 
        public String CdMeteoGmsMeteo { get; set; }
        
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
        
        [Description("Moyen utilisé")]
        [Column("MOYEN",Order=8)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Condition particulière")]
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
        
        [Description("Ancrage")]
        [Column("NOTE1",Order=15)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Structure")]
        [Column("NOTE2",Order=16)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Fixation")]
        [Column("NOTE3",Order=17)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Panneau")]
        [Column("NOTE4",Order=18)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Accessibilité")]
        [Column("NOTE5",Order=19)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Niveau urgence")]
        [Column("URGENCE",Order=20)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Image qualité")]
        [Column("QUALITE",Order=21)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
