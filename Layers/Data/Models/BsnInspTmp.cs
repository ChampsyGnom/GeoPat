using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("INSP_TMP_BSN",Schema="BSN")]
    public partial class BsnInspTmp
    {
        public virtual BsnCdEtude BsnCdEtude {get;set;}
        
        public virtual BsnCdMeteo BsnCdMeteo {get;set;}
        
        public virtual BsnDscTemp BsnDscTemp {get;set;}
        
        public virtual BsnInspecteur BsnInspecteur {get;set;}
        
        public virtual ICollection<BsnPhotoInspTmp> BsnPhotoInspTmps { get; set; }
        
        public virtual ICollection<BsnEltInspTmp> BsnEltInspTmps { get; set; }
        
        public virtual ICollection<BsnCdConclusionInspTmp> BsnCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_TEMP_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempBsnNumBsn { get; set; }
        
        [Description("Nom inspecteur")]
        [Column("INSPECTEUR_BSN__NOM",Order=2)]
        [MaxLength(60)] 
        public String InspecteurBsnNom { get; set; }
        
        [Description("Météo")]
        [Column("CD_METEO_BSN__METEO",Order=3)]
        [MaxLength(60)] 
        public String CdMeteoBsnMeteo { get; set; }
        
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_BSN__ETUDE",Order=4)]
        [MaxLength(65)] 
        public String CdEtudeBsnEtude { get; set; }
        
        [Description("Statut visite")]
        [Column("INSP_TMP_BSN__ETAT",Order=5)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
        [Description("Date de visite")]
        [Column("INSP_TMP_BSN__DATEV",Order=6)]
        public Nullable<DateTime> Datev { get; set; }
        
        [Description("Température")]
        [Column("INSP_TMP_BSN__TEMPERATURE",Order=7)]
        public Nullable<Double> Temperature { get; set; }
        
        [Description("Moyen utilisé")]
        [Column("INSP_TMP_BSN__MOYEN",Order=8)]
        [MaxLength(500)] 
        public String Moyen { get; set; }
        
        [Description("Condition particulière")]
        [Column("INSP_TMP_BSN__CONDITIONS",Order=9)]
        [MaxLength(500)] 
        public String Conditions { get; set; }
        
        [Description("Date Validation")]
        [Column("INSP_TMP_BSN__DATE_VALID",Order=10)]
        public Nullable<DateTime> DateValid { get; set; }
        
        [Description("Nom Valideur")]
        [Column("INSP_TMP_BSN__NOM_VALID",Order=11)]
        [MaxLength(250)] 
        public String NomValid { get; set; }
        
        [Description("Description invalide")]
        [Column("INSP_TMP_BSN__DESC_INVA",Order=12)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("INSP_TMP_BSN__SECURITE",Order=13)]
        [MaxLength(1000)] 
        public String Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("INSP_TMP_BSN__PRIORITAIRE",Order=14)]
        [MaxLength(1000)] 
        public String Prioritaire { get; set; }
        
        [Description("Note Structure")]
        [Column("INSP_TMP_BSN__NOTE1",Order=15)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Equipements")]
        [Column("INSP_TMP_BSN__NOTE2",Order=16)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Abords-Végétation")]
        [Column("INSP_TMP_BSN__NOTE3",Order=17)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Sécurité")]
        [Column("INSP_TMP_BSN__NOTE4",Order=18)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("INSP_TMP_BSN__URGENCE",Order=19)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Image qualité")]
        [Column("INSP_TMP_BSN__QUALITE",Order=20)]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
