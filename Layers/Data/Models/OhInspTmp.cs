using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_TMP_OH",Schema="OH")]
    public partial class OhInspTmp
    {
        public virtual OhCdMeteo OhCdMeteo {get;set;}
        
        public virtual OhCdEtude OhCdEtude {get;set;}
        
        public virtual OhDscTemp OhDscTemp {get;set;}
        
        public virtual OhInspecteur OhInspecteur {get;set;}
        
        public virtual ICollection<OhEltInspTmp> OhEltInspTmps { get; set; }
        
        public virtual ICollection<OhPhotoInspTmp> OhPhotoInspTmps { get; set; }
        
        public virtual ICollection<OhCdConclusionInspTmp> OhCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Key]
        [Description("NumOH")]
        [Column("DSC_TEMP_OH__NUM_OH",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempOhNumOh { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_OH__NOM",Order=2)]
        [MaxLength(60)] 
        public String InspecteurOhNom { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_OH__ETUDE",Order=3)]
        [MaxLength(65)] 
        public String CdEtudeOhEtude { get; set; }
        
        [Description("Météo")]
        [Column("CD_METEO_OH__METEO",Order=4)]
        [MaxLength(60)] 
        public String CdMeteoOhMeteo { get; set; }
        
        [Description("Statut visite")]
        [Column("INSP_TMP_OH__ETAT",Order=5)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("INSP_TMP_OH__DATEV",Order=6)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Température")]
        [Column("INSP_TMP_OH__TEMPERATURE",Order=7)]
        public Nullable<Double> Temperature { get; set; }
        
        [Description("Moyen utilisé")]
        [Column("INSP_TMP_OH__MOYEN",Order=8)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Condition particulière")]
        [Column("INSP_TMP_OH__CONDITIONS",Order=9)]
        [MaxLength(500)] 
        public String Conditions { get; set; }
        
        [Description("Nom Valideur")]
        [Column("INSP_TMP_OH__NOM_VALID",Order=10)]
        [MaxLength(250)] 
        public String NomValid { get; set; }
        
        [Description("Date Validation")]
        [Column("INSP_TMP_OH__DATE_VALID",Order=11)]
        public Nullable<DateTime> DateValid { get; set; }
        
        [Description("Description invalide")]
        [Column("INSP_TMP_OH__DESC_INVA",Order=12)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Urgence traitement")]
        [Column("INSP_TMP_OH__PRIORITAIRE",Order=13)]
        [MaxLength(1000)] 
        public String Prioritaire { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("INSP_TMP_OH__SECURITE",Order=14)]
        [MaxLength(1000)] 
        public String Securite { get; set; }
        
        [Description("Abords amont")]
        [Column("INSP_TMP_OH__NOTE1",Order=15)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Protection amont")]
        [Column("INSP_TMP_OH__NOTE2",Order=16)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Conduit")]
        [Column("INSP_TMP_OH__NOTE3",Order=17)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Protection aval")]
        [Column("INSP_TMP_OH__NOTE4",Order=18)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Abordst aval")]
        [Column("INSP_TMP_OH__NOTE5",Order=19)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Niveau urgence")]
        [Column("INSP_TMP_OH__URGENCE",Order=20)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Image qualité")]
        [Column("INSP_TMP_OH__QUALITE",Order=21)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
