using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_GOT",Schema="GOT")]
    public partial class GotDsc
    {
        [Key]
        [Description("N° Ouvrage")]
        [Column("NUM_GOT",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String NumGot { get; set; }
        
        [Description("Profil")]
        [Column("CD_FAM_GOT__FAMILLE",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamGotFamille { get; set; }
        
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_GOT__QUALITE",Order=2)]
        [MaxLength(25)] 
        public String CdQualiteGotQualite { get; set; }
        
        [Description("Géologie")]
        [Column("CD_GEO_GOT__GEOLOGIE",Order=3)]
        [MaxLength(60)] 
        public String CdGeoGotGeologie { get; set; }
        
        [Description("Protections")]
        [Column("CD_PROTECT_GOT__TYPE",Order=4)]
        [MaxLength(60)] 
        public String CdProtectGotType { get; set; }
        
        [Description("Type")]
        [Column("CD_TYPE_GOT__TYPE",Order=5)]
        [MaxLength(20)] 
        public String CdTypeGotType { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GOT__ENTREPRISE",Order=6)]
        [MaxLength(60)] 
        public String CdEntpGotEntreprise { get; set; }
        
        [Description("Note Risque")]
        [Column("CD_RISQUE_GOT__RISQUE",Order=7)]
        [MaxLength(3)] 
        public String CdRisqueGotRisque { get; set; }
        
        [Description("Pente")]
        [Column("CD_PENTE_GOT__PENTE",Order=8)]
        [MaxLength(25)] 
        public String CdPenteGotPente { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=9)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=10)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Début")]
        [Column("ABS_DEB",Order=11)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=12)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("No D'exploitation")]
        [Column("NUM_EXPLOIT",Order=13)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Date achèvement")]
        [Column("DATE_CONST",Order=14)]
        public Nullable<DateTime> DateConst { get; set; }
        
        [Description("Pente TN >15%")]
        [Column("PENTE_TN",Order=15)]
        public Nullable<Boolean> PenteTn { get; set; }
        
        [Description("Hauteur Max (m)")]
        [Column("HAUT",Order=16)]
        public Nullable<Int64> Haut { get; set; }
        
        [Description("Largeur crête (m)")]
        [Column("LARG_CRETE",Order=17)]
        public Nullable<Double> LargCrete { get; set; }
        
        [Description("Volume (m3)")]
        [Column("VOLUME",Order=18)]
        public Nullable<Int64> Volume { get; set; }
        
        [Description("Nbre Risberme")]
        [Column("RISB_NBR",Order=19)]
        public Nullable<Int64> RisbNbr { get; set; }
        
        [Description("Espacem. Risberme")]
        [Column("RISB_ESP",Order=20)]
        public Nullable<Double> RisbEsp { get; set; }
        
        [Description("Larg Risberme")]
        [Column("RISB_LARG",Order=21)]
        public Nullable<Double> RisbLarg { get; set; }
        
        [Description("PHE Hauteur plus hautes eaux")]
        [Column("HAUT_EAU",Order=22)]
        public Nullable<Double> HautEau { get; set; }
        
        [Description("Site instable")]
        [Column("INSTABLE",Order=23)]
        public Nullable<Boolean> Instable { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM_USAGE",Order=24)]
        [MaxLength(255)] 
        public String NomUsage { get; set; }
        
        [Description("Note Plateforme 1")]
        [Column("NOTE1",Order=25)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Plateforme 2")]
        [Column("NOTE2",Order=26)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Talus 1")]
        [Column("NOTE3",Order=27)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Talus 2")]
        [Column("NOTE4",Order=28)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Environnement")]
        [Column("NOTE5",Order=29)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Note Urgence")]
        [Column("URGENCE",Order=30)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=31)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=32)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=33)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine surveillance")]
        [Column("PROSURV_ANNEE",Order=34)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière inspection")]
        [Column("DERN_INSP",Order=35)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DERN_VST",Order=36)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("NOTE_VST",Order=37)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("ARCHIVE",Order=38)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=39)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=40)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=41)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=42)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=43)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=44)]
        public Nullable<Boolean> Terrain { get; set; }
        
        [Description("Y2")]
        [Column("Y2",Order=45)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("Z2",Order=46)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("X2")]
        [Column("X2",Order=47)]
        public Nullable<Double> X2 { get; set; }
        
    }
}
