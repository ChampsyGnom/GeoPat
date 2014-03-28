using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_TEMP_GOT",Schema="GOT")]
    public partial class GotDscTemp
    {
        public virtual GotCdFam GotCdFam {get;set;}
        
        public virtual GotCdType GotCdType {get;set;}
        
        public virtual GotCdPente GotCdPente {get;set;}
        
        public virtual GotCdEntp GotCdEntp {get;set;}
        
        public virtual GotCdProtect GotCdProtect {get;set;}
        
        public virtual GotCdGeo GotCdGeo {get;set;}
        
        public virtual GotCamp GotCamp {get;set;}
        
        public virtual GotDsc GotDsc {get;set;}
        
        public virtual ICollection<GotInspTmp> GotInspTmps { get; set; }
        
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
        public String NumGot { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GOT__ENTREPRISE",Order=2)]
        [MaxLength(60)] 
        public String CdEntpGotEntreprise { get; set; }
        
        [Description("Type")]
        [Column("CD_TYPE_GOT__TYPE",Order=3)]
        [MaxLength(20)] 
        public String CdTypeGotType { get; set; }
        
        [Description("Pente")]
        [Column("CD_PENTE_GOT__PENTE",Order=4)]
        [MaxLength(25)] 
        public String CdPenteGotPente { get; set; }
        
        [Description("Protections")]
        [Column("CD_PROTECT_GOT__TYPE",Order=5)]
        [MaxLength(60)] 
        public String CdProtectGotType { get; set; }
        
        [Description("Profil")]
        [Column("CD_FAM_GOT__FAMILLE",Order=6)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamGotFamille { get; set; }
        
        [Description("Géologie")]
        [Column("CD_GEO_GOT__GEOLOGIE",Order=7)]
        [MaxLength(60)] 
        public String CdGeoGotGeologie { get; set; }
        
        [Description("N° Ouvrage2")]
        [Column("DSC_GOT__NUM_GOT",Order=8)]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_TEMP_GOT__LIAISON",Order=9)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_TEMP_GOT__SENS",Order=10)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Début")]
        [Column("DSC_TEMP_GOT__ABS_DEB",Order=11)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("DSC_TEMP_GOT__ABS_FIN",Order=12)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("No D'exploitation")]
        [Column("DSC_TEMP_GOT__NUM_EXPLOIT",Order=13)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Date achèvement")]
        [Column("DSC_TEMP_GOT__DATE_CONST",Order=14)]
        public Nullable<DateTime> DateConst { get; set; }
        
        [Description("Pente TN >15%")]
        [Column("DSC_TEMP_GOT__PENTE_TN",Order=15)]
        public Nullable<Boolean> PenteTn { get; set; }
        
        [Description("Hauteur Max (m)")]
        [Column("DSC_TEMP_GOT__HAUT",Order=16)]
        public Nullable<Int64> Haut { get; set; }
        
        [Description("Largeur crête (m)")]
        [Column("DSC_TEMP_GOT__LARG_CRETE",Order=17)]
        public Nullable<Double> LargCrete { get; set; }
        
        [Description("Volume (m3)")]
        [Column("DSC_TEMP_GOT__VOLUME",Order=18)]
        public Nullable<Int64> Volume { get; set; }
        
        [Description("Nbre Risberme")]
        [Column("DSC_TEMP_GOT__RISB_NBR",Order=19)]
        public Nullable<Int64> RisbNbr { get; set; }
        
        [Description("Espacem. Risberme")]
        [Column("DSC_TEMP_GOT__RISB_ESP",Order=20)]
        public Nullable<Double> RisbEsp { get; set; }
        
        [Description("Larg Risberme")]
        [Column("DSC_TEMP_GOT__RISB_LARG",Order=21)]
        public Nullable<Double> RisbLarg { get; set; }
        
        [Description("PHE Hauteur plus hautes eaux")]
        [Column("DSC_TEMP_GOT__HAUT_EAU",Order=22)]
        public Nullable<Double> HautEau { get; set; }
        
        [Description("Site instable")]
        [Column("DSC_TEMP_GOT__INSTABLE",Order=23)]
        public Nullable<Boolean> Instable { get; set; }
        
        [Description("Nom d'usage")]
        [Column("DSC_TEMP_GOT__NOM_USAGE",Order=24)]
        [MaxLength(255)] 
        public String NomUsage { get; set; }
        
        [Description("Note Plateforme 1")]
        [Column("DSC_TEMP_GOT__NOTE1",Order=25)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Plateforme 2")]
        [Column("DSC_TEMP_GOT__NOTE2",Order=26)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Talus 1")]
        [Column("DSC_TEMP_GOT__NOTE3",Order=27)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Talus 2")]
        [Column("DSC_TEMP_GOT__NOTE4",Order=28)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Environnement")]
        [Column("DSC_TEMP_GOT__NOTE5",Order=29)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Note Urgence")]
        [Column("DSC_TEMP_GOT__URGENCE",Order=30)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DSC_TEMP_GOT__DESC_INVA",Order=31)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("DSC_TEMP_GOT__SECURITE",Order=32)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("DSC_TEMP_GOT__PRIORITAIRE",Order=33)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine surveillance")]
        [Column("DSC_TEMP_GOT__PROSURV_ANNEE",Order=34)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière inspection")]
        [Column("DSC_TEMP_GOT__DERN_INSP",Order=35)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DSC_TEMP_GOT__DERN_VST",Order=36)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("DSC_TEMP_GOT__NOTE_VST",Order=37)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("DSC_TEMP_GOT__ARCHIVE",Order=38)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_TEMP_GOT__COMMENTAIRE",Order=39)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("DSC_TEMP_GOT__X1",Order=40)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("DSC_TEMP_GOT__Y1",Order=41)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("DSC_TEMP_GOT__Z1",Order=42)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DSC_TEMP_GOT__DATE_RELEVE",Order=43)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("DSC_TEMP_GOT__TERRAIN",Order=44)]
        public Nullable<Boolean> Terrain { get; set; }
        
        [Description("X2")]
        [Column("DSC_TEMP_GOT__X2",Order=45)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("DSC_TEMP_GOT__Y2",Order=46)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("DSC_TEMP_GOT__Z2",Order=47)]
        public Nullable<Double> Z2 { get; set; }
        
    }
}
