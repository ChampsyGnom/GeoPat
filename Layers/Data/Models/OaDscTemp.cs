using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_TEMP_OA",Schema="OA")]
    public partial class OaDscTemp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("NUM_OA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String NumOa { get; set; }
        
        [Description("Bureau d'étude")]
        [Column("CD_BE_OA__BUREAU",Order=2)]
        [MaxLength(60)] 
        public String CdBeOaBureau { get; set; }
        
        [Description("Gestionnaire")]
        [Column("CD_GEST_OA__GESTIONNAIRE",Order=3)]
        [MaxLength(60)] 
        public String CdGestOaGestionnaire { get; set; }
        
        [Description("Surcharge")]
        [Column("CD_CHARGE_OA__SURCHARGE",Order=4)]
        [MaxLength(60)] 
        public String CdChargeOaSurcharge { get; set; }
        
        [Description("Type")]
        [Column("CD_TYPE_OA__TYPE",Order=5)]
        [Required()]
        [MaxLength(20)] 
        public String CdTypeOaType { get; set; }
        
        [Description("NumOA2")]
        [Column("DSC_OA__NUM_OA",Order=6)]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_OA__ENTREPRISE",Order=7)]
        [MaxLength(60)] 
        public String CdEntpOaEntreprise { get; set; }
        
        [Description("Type tablier")]
        [Column("CD_TABLIER_OA__TABLIER",Order=8)]
        [MaxLength(60)] 
        public String CdTablierOaTablier { get; set; }
        
        [Description("Fondation")]
        [Column("CD_FOND_OA__TYPE",Order=9)]
        [MaxLength(60)] 
        public String CdFondOaType { get; set; }
        
        [Description("Matériaux")]
        [Column("CD_MAT_OA__MATERIAUX",Order=10)]
        [MaxLength(60)] 
        public String CdMatOaMateriaux { get; set; }
        
        [Description("Maitre d'ouvrage")]
        [Column("CD_MO_OA__MAITRE_OUVR",Order=11)]
        [MaxLength(60)] 
        public String CdMoOaMaitreOuvr { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_OA__FAMILLE",Order=12)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamOaFamille { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=13)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=14)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("ABS_DEB",Order=15)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR Fin")]
        [Column("ABS_FIN",Order=16)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("NUM_EXPLOIT",Order=17)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM_USAGE",Order=18)]
        [MaxLength(255)] 
        public String NomUsage { get; set; }
        
        [Description("Date construction")]
        [Column("DATE_CONST",Order=19)]
        public Nullable<DateTime> DateConst { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=20)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Voie portée ou franchie")]
        [Column("VPF",Order=21)]
        [MaxLength(60)] 
        public String Vpf { get; set; }
        
        [Description("Trafic Voie portée")]
        [Column("TRAFIC_VPF",Order=22)]
        public Nullable<Int64> TraficVpf { get; set; }
        
        [Description("Longueur déviation (km)")]
        [Column("DEVIATION",Order=23)]
        public Nullable<Double> Deviation { get; set; }
        
        [Description("Nb piles intermédiaires")]
        [Column("NBPILESINTER",Order=24)]
        public Nullable<Int64> Nbpilesinter { get; set; }
        
        [Description("Nombre de travée")]
        [Column("TRAVURE",Order=25)]
        public Nullable<Int64> Travure { get; set; }
        
        [Description("Long max travée (m)")]
        [Column("LONG_MAX_TRAV",Order=26)]
        public Nullable<Double> LongMaxTrav { get; set; }
        
        [Description("Gabarit (m)")]
        [Column("GAB_MINI",Order=27)]
        public Nullable<Double> GabMini { get; set; }
        
        [Description("Gabarit GRA")]
        [Column("GAB_GRA",Order=28)]
        public Nullable<Boolean> GabGra { get; set; }
        
        [Description("Biais (grad)")]
        [Column("BIAIS",Order=29)]
        public Nullable<Int64> Biais { get; set; }
        
        [Description("Longueur biaise (m)")]
        [Column("LONG_BIAISE",Order=30)]
        public Nullable<Double> LongBiaise { get; set; }
        
        [Description("Largeur droite (m)")]
        [Column("LARG_TRAV",Order=31)]
        public Nullable<Double> LargTrav { get; set; }
        
        [Description("Largeur entre bordure (m)")]
        [Column("LARG_BIAISE",Order=32)]
        public Nullable<Double> LargBiaise { get; set; }
        
        [Description("Largeur entre GS (m)")]
        [Column("LARG_GS",Order=33)]
        public Nullable<Double> LargGs { get; set; }
        
        [Description("Surface tablier (m²)")]
        [Column("SURF_TABLIER",Order=34)]
        public Nullable<Double> SurfTablier { get; set; }
        
        [Description("Surf voie (m²)")]
        [Column("SURF_VPF",Order=35)]
        public Nullable<Double> SurfVpf { get; set; }
        
        [Description("Fondation immergé")]
        [Column("IMMERGE",Order=36)]
        public Nullable<Boolean> Immerge { get; set; }
        
        [Description("Sismicité")]
        [Column("SISMICITE",Order=37)]
        public Nullable<Boolean> Sismicite { get; set; }
        
        [Description("Dalle de transition")]
        [Column("DALLE",Order=38)]
        public Nullable<Boolean> Dalle { get; set; }
        
        [Description("Corniche")]
        [Column("CORN",Order=39)]
        public Nullable<Boolean> Corn { get; set; }
        
        [Description("Lanterneau")]
        [Column("LANTERNEAU",Order=40)]
        public Nullable<Boolean> Lanterneau { get; set; }
        
        [Description("Equipement de visite")]
        [Column("EQUIP_VST",Order=41)]
        public Nullable<Boolean> EquipVst { get; set; }
        
        [Description("Note Appuis / Fondations")]
        [Column("NOTE1",Order=42)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Tabliers")]
        [Column("NOTE2",Order=43)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Equipement")]
        [Column("NOTE3",Order=44)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=45)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=46)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=47)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence Traitement")]
        [Column("PRIORITAIRE",Order=48)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("PROSURV_ANNEE",Order=49)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DERN_INSP",Order=50)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DERN_VST",Order=51)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("NOTE_VST",Order=52)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("ARCHIVE",Order=53)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=54)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=55)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=56)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=57)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("X2")]
        [Column("X2",Order=58)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("Y2",Order=59)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("Z2",Order=60)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=61)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=62)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
