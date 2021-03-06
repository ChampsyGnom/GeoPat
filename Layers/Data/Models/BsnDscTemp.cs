using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_TEMP_BSN",Schema="BSN")]
    public partial class BsnDscTemp
    {
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String NumBsn { get; set; }
        
        [Description("N° Bassin2")]
        [Column("DSC_BSN__NUM_BSN",Order=2)]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Description("Perméabilité")]
        [Column("CD_PERMEABLE_BSN__TYPE",Order=3)]
        [MaxLength(60)] 
        public String CdPermeableBsnType { get; set; }
        
        [Description("Nature sensibilité")]
        [Column("CD_SOUS_TYPE_BSN__NAT_SENSIB",Order=4)]
        [MaxLength(60)] 
        public String CdSousTypeBsnNatSensib { get; set; }
        
        [Description("Exutoire")]
        [Column("CD_EXT_BSN__TYPE",Order=5)]
        [MaxLength(60)] 
        public String CdExtBsnType { get; set; }
        
        [Description("Sensibilité du milieu")]
        [Column("CD_TYPE_BSN__TYPE",Order=6)]
        [Required()]
        [MaxLength(60)] 
        public String CdTypeBsnType { get; set; }
        
        [Description("Voie d'accès")]
        [Column("CD_ACCES_BSN__VACCES",Order=7)]
        [MaxLength(60)] 
        public String CdAccesBsnVacces { get; set; }
        
        [Description("Dénomination")]
        [Column("CD_FAM_BSN__FAMILLE",Order=8)]
        [Required()]
        [MaxLength(60)] 
        public String CdFamBsnFamille { get; set; }
        
        [Description("Fréquence")]
        [Column("CD_FREQUENCE_BSN__FREQ",Order=9)]
        [MaxLength(25)] 
        public String CdFrequenceBsnFreq { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_BSN__ENTREPRISE",Order=10)]
        [MaxLength(60)] 
        public String CdEntpBsnEntreprise { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("NUM_EXPLOIT",Order=11)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=12)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=13)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR")]
        [Column("ABS_DEB",Order=14)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=15)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Volume utile (m3)")]
        [Column("VOL_UTIL",Order=16)]
        public Nullable<Int64> VolUtil { get; set; }
        
        [Description("Volume mort (m3)")]
        [Column("VOL_MOR",Order=17)]
        public Nullable<Int64> VolMor { get; set; }
        
        [Description("Volume polluant (m3)")]
        [Column("VOL_POLL",Order=18)]
        public Nullable<Int64> VolPoll { get; set; }
        
        [Description("Volume eau incendie (m3)")]
        [Column("VOL_INCEN",Order=19)]
        public Nullable<Int64> VolIncen { get; set; }
        
        [Description("Durée des pluies (h)")]
        [Column("DUREE_PLUIE",Order=20)]
        public Nullable<Int64> DureePluie { get; set; }
        
        [Description("Sensibilité Faune et flore")]
        [Column("FAUNE_FLORE",Order=21)]
        [MaxLength(60)] 
        public String FauneFlore { get; set; }
        
        [Description("Surf. bassin versant ext. (ha)")]
        [Column("SURF_VERSANT",Order=22)]
        public Nullable<Double> SurfVersant { get; set; }
        
        [Description("Sortie débit fuite  (l/s)")]
        [Column("DEBIT_MAX",Order=23)]
        public Nullable<Int64> DebitMax { get; set; }
        
        [Description("Tps de concentration (mn)")]
        [Column("TPS_CONCENT",Order=24)]
        public Nullable<Int64> TpsConcent { get; set; }
        
        [Description("Accès véhicule")]
        [Column("VEHICULE",Order=25)]
        [MaxLength(255)] 
        public String Vehicule { get; set; }
        
        [Description("Accès piéton")]
        [Column("PIETON",Order=26)]
        [MaxLength(255)] 
        public String Pieton { get; set; }
        
        [Description("Note Structure")]
        [Column("NOTE1",Order=27)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Equipements")]
        [Column("NOTE2",Order=28)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Abords-Végétation")]
        [Column("NOTE3",Order=29)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Sécurité")]
        [Column("NOTE4",Order=30)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=31)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=32)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=33)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=34)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("PROSURV_ANNEE",Order=35)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DERN_INSP",Order=36)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DERN_VST",Order=37)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("NOTE_VST",Order=38)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("ARCHIVE",Order=39)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Connexion Aval")]
        [Column("OUV_AVAL",Order=40)]
        [MaxLength(200)] 
        public String OuvAval { get; set; }
        
        [Description("Loi sur l'eau")]
        [Column("LOI_EAU",Order=41)]
        public Nullable<Boolean> LoiEau { get; set; }
        
        [Description("Eaux collectées")]
        [Column("EAUX_COLLECT",Order=42)]
        [MaxLength(200)] 
        public String EauxCollect { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=43)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=44)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=45)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=46)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=47)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=48)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
