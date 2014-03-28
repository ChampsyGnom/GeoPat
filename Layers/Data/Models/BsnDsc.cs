using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_BSN",Schema="BSN")]
    public partial class BsnDsc
    {
        public virtual BsnCdFam BsnCdFam {get;set;}
        
        public virtual BsnCdPermeable BsnCdPermeable {get;set;}
        
        public virtual BsnCdType BsnCdType {get;set;}
        
        public virtual BsnCdExt BsnCdExt {get;set;}
        
        public virtual BsnCdQualite BsnCdQualite {get;set;}
        
        public virtual BsnCdAcces BsnCdAcces {get;set;}
        
        public virtual BsnCdSousType BsnCdSousType {get;set;}
        
        public virtual BsnCdFrequence BsnCdFrequence {get;set;}
        
        public virtual BsnCdEntp BsnCdEntp {get;set;}
        
        public virtual ICollection<BsnTravaux> BsnTravauxs { get; set; }
        
        public virtual ICollection<BsnPrevision> BsnPrevisions { get; set; }
        
        public virtual ICollection<BsnVst> BsnVsts { get; set; }
        
        public virtual ICollection<BsnInsp> BsnInsps { get; set; }
        
        public virtual ICollection<BsnHistoNote> BsnHistoNotes { get; set; }
        
        public virtual ICollection<BsnEvt> BsnEvts { get; set; }
        
        public virtual ICollection<BsnImpluvium> BsnImpluviums { get; set; }
        
        public virtual ICollection<BsnGeometrie> BsnGeometries { get; set; }
        
        public virtual ICollection<BsnEquipement> BsnEquipements { get; set; }
        
        public virtual ICollection<BsnDscTemp> BsnDscTemps { get; set; }
        
        public virtual ICollection<BsnDscCamp> BsnDscCamps { get; set; }
        
        public virtual ICollection<BsnCdRoleDsc> BsnCdRoleDscs { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String NumBsn { get; set; }
        
        [Description("Voie d'accès")]
        [Column("CD_ACCES_BSN__VACCES",Order=1)]
        [MaxLength(60)] 
        public String CdAccesBsnVacces { get; set; }
        
        [Description("Perméabilité")]
        [Column("CD_PERMEABLE_BSN__TYPE",Order=2)]
        [MaxLength(60)] 
        public String CdPermeableBsnType { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_BSN__ENTREPRISE",Order=3)]
        [MaxLength(60)] 
        public String CdEntpBsnEntreprise { get; set; }
        
        [Description("Sensibilité du milieu")]
        [Column("CD_TYPE_BSN__TYPE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String CdTypeBsnType { get; set; }
        
        [Description("Nature sensibilité")]
        [Column("CD_SOUS_TYPE_BSN__NAT_SENSIB",Order=5)]
        [MaxLength(60)] 
        public String CdSousTypeBsnNatSensib { get; set; }
        
        [Description("Fréquence")]
        [Column("CD_FREQUENCE_BSN__FREQ",Order=6)]
        [MaxLength(25)] 
        public String CdFrequenceBsnFreq { get; set; }
        
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_BSN__QUALITE",Order=7)]
        [MaxLength(25)] 
        public String CdQualiteBsnQualite { get; set; }
        
        [Description("Exutoire")]
        [Column("CD_EXT_BSN__TYPE",Order=8)]
        [MaxLength(60)] 
        public String CdExtBsnType { get; set; }
        
        [Description("Dénomination")]
        [Column("CD_FAM_BSN__FAMILLE",Order=9)]
        [Required()]
        [MaxLength(60)] 
        public String CdFamBsnFamille { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("DSC_BSN__NUM_EXPLOIT",Order=10)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_BSN__LIAISON",Order=11)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_BSN__SENS",Order=12)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR")]
        [Column("DSC_BSN__ABS_DEB",Order=13)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_BSN__DATE_MS",Order=14)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Volume utile (m3)")]
        [Column("DSC_BSN__VOL_UTIL",Order=15)]
        public Nullable<Int64> VolUtil { get; set; }
        
        [Description("Volume mort (m3)")]
        [Column("DSC_BSN__VOL_MOR",Order=16)]
        public Nullable<Int64> VolMor { get; set; }
        
        [Description("Volume polluant (m3)")]
        [Column("DSC_BSN__VOL_POLL",Order=17)]
        public Nullable<Int64> VolPoll { get; set; }
        
        [Description("Volume eau incendie (m3)")]
        [Column("DSC_BSN__VOL_INCEN",Order=18)]
        public Nullable<Int64> VolIncen { get; set; }
        
        [Description("Durée des pluies (h)")]
        [Column("DSC_BSN__DUREE_PLUIE",Order=19)]
        public Nullable<Int64> DureePluie { get; set; }
        
        [Description("Sensibilité Faune et flore")]
        [Column("DSC_BSN__FAUNE_FLORE",Order=20)]
        [MaxLength(60)] 
        public String FauneFlore { get; set; }
        
        [Description("Surf. bassin versant ext. (ha)")]
        [Column("DSC_BSN__SURF_VERSANT",Order=21)]
        public Nullable<Double> SurfVersant { get; set; }
        
        [Description("Sortie débit fuite  (l/s)")]
        [Column("DSC_BSN__DEBIT_MAX",Order=22)]
        public Nullable<Int64> DebitMax { get; set; }
        
        [Description("Tps de concentration (mn)")]
        [Column("DSC_BSN__TPS_CONCENT",Order=23)]
        public Nullable<Int64> TpsConcent { get; set; }
        
        [Description("Accès véhicule")]
        [Column("DSC_BSN__VEHICULE",Order=24)]
        [MaxLength(255)] 
        public String Vehicule { get; set; }
        
        [Description("Accès piéton")]
        [Column("DSC_BSN__PIETON",Order=25)]
        [MaxLength(255)] 
        public String Pieton { get; set; }
        
        [Description("Note Structure")]
        [Column("DSC_BSN__NOTE1",Order=26)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Equipements")]
        [Column("DSC_BSN__NOTE2",Order=27)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Abords-Végétation")]
        [Column("DSC_BSN__NOTE3",Order=28)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Sécurité")]
        [Column("DSC_BSN__NOTE4",Order=29)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("DSC_BSN__URGENCE",Order=30)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DSC_BSN__DESC_INVA",Order=31)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("DSC_BSN__SECURITE",Order=32)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("DSC_BSN__PRIORITAIRE",Order=33)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("DSC_BSN__PROSURV_ANNEE",Order=34)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DSC_BSN__DERN_INSP",Order=35)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DSC_BSN__DERN_VST",Order=36)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("DSC_BSN__NOTE_VST",Order=37)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("DSC_BSN__ARCHIVE",Order=38)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Connexion Aval")]
        [Column("DSC_BSN__OUV_AVAL",Order=39)]
        [MaxLength(200)] 
        public String OuvAval { get; set; }
        
        [Description("Loi sur l'eau")]
        [Column("DSC_BSN__LOI_EAU",Order=40)]
        public Nullable<Boolean> LoiEau { get; set; }
        
        [Description("Eaux collectées")]
        [Column("DSC_BSN__EAUX_COLLECT",Order=41)]
        [MaxLength(200)] 
        public String EauxCollect { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_BSN__COMMENTAIRE",Order=42)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("DSC_BSN__X1",Order=43)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("DSC_BSN__Y1",Order=44)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("DSC_BSN__Z1",Order=45)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DSC_BSN__DATE_RELEVE",Order=46)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("DSC_BSN__TERRAIN",Order=47)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
