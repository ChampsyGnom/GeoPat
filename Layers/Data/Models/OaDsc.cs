using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_OA",Schema="OA")]
    public partial class OaDsc
    {
        public virtual OaCdType OaCdType {get;set;}
        
        public virtual OaCdEntp OaCdEntp {get;set;}
        
        public virtual OaCdCharge OaCdCharge {get;set;}
        
        public virtual OaCdMat OaCdMat {get;set;}
        
        public virtual OaCdBe OaCdBe {get;set;}
        
        public virtual OaCdGest OaCdGest {get;set;}
        
        public virtual OaCdFond OaCdFond {get;set;}
        
        public virtual OaCdTablier OaCdTablier {get;set;}
        
        public virtual OaCdMo OaCdMo {get;set;}
        
        public virtual OaCdQualite OaCdQualite {get;set;}
        
        public virtual OaCdFam OaCdFam {get;set;}
        
        public virtual OaCdHierarchie OaCdHierarchie {get;set;}
        
        public virtual ICollection<OaTravaux> OaTravauxs { get; set; }
        
        public virtual ICollection<OaHistoNote> OaHistoNotes { get; set; }
        
        public virtual ICollection<OaPrevision> OaPrevisions { get; set; }
        
        public virtual ICollection<OaInsp> OaInsps { get; set; }
        
        public virtual ICollection<OaEvt> OaEvts { get; set; }
        
        public virtual ICollection<OaVst> OaVsts { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        public virtual ICollection<OaOccupation> OaOccupations { get; set; }
        
        public virtual ICollection<OaAppuis> OaAppuiss { get; set; }
        
        public virtual ICollection<OaDscCamp> OaDscCamps { get; set; }
        
        public virtual ICollection<OaDscArchive3> OaDscArchive3s { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String NumOa { get; set; }
        
        [Description("Note IQOA")]
        [Column("CD_IQOA_OA__NOTE_IQOA",Order=1)]
        [MaxLength(3)] 
        public String CdIqoaOaNoteIqoa { get; set; }
        
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_OA__QUALITE",Order=2)]
        [MaxLength(25)] 
        public String CdQualiteOaQualite { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_OA__FAMILLE",Order=3)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamOaFamille { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_OA__ENTREPRISE",Order=4)]
        [MaxLength(60)] 
        public String CdEntpOaEntreprise { get; set; }
        
        [Description("Type tablier")]
        [Column("CD_TABLIER_OA__TABLIER",Order=5)]
        [MaxLength(60)] 
        public String CdTablierOaTablier { get; set; }
        
        [Description("Type")]
        [Column("CD_TYPE_OA__TYPE",Order=6)]
        [Required()]
        [MaxLength(20)] 
        public String CdTypeOaType { get; set; }
        
        [Description("Gestionnaire")]
        [Column("CD_GEST_OA__GESTIONNAIRE",Order=7)]
        [MaxLength(60)] 
        public String CdGestOaGestionnaire { get; set; }
        
        [Description("Caractère stratégique")]
        [Column("CD_HIERARCHIE_OA__HIERARCHIE",Order=8)]
        [MaxLength(60)] 
        public String CdHierarchieOaHierarchie { get; set; }
        
        [Description("Matériaux")]
        [Column("CD_MAT_OA__MATERIAUX",Order=9)]
        [MaxLength(60)] 
        public String CdMatOaMateriaux { get; set; }
        
        [Description("Surcharge")]
        [Column("CD_CHARGE_OA__SURCHARGE",Order=10)]
        [MaxLength(60)] 
        public String CdChargeOaSurcharge { get; set; }
        
        [Description("Bureau d'étude")]
        [Column("CD_BE_OA__BUREAU",Order=11)]
        [MaxLength(60)] 
        public String CdBeOaBureau { get; set; }
        
        [Description("Maitre d'ouvrage")]
        [Column("CD_MO_OA__MAITRE_OUVR",Order=12)]
        [MaxLength(60)] 
        public String CdMoOaMaitreOuvr { get; set; }
        
        [Description("Fondation")]
        [Column("CD_FOND_OA__TYPE",Order=13)]
        [MaxLength(60)] 
        public String CdFondOaType { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_OA__LIAISON",Order=14)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_OA__SENS",Order=15)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("DSC_OA__ABS_DEB",Order=16)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR Fin")]
        [Column("DSC_OA__ABS_FIN",Order=17)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("DSC_OA__NUM_EXPLOIT",Order=18)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("DSC_OA__NOM_USAGE",Order=19)]
        [MaxLength(255)] 
        public String NomUsage { get; set; }
        
        [Description("Date construction")]
        [Column("DSC_OA__DATE_CONST",Order=20)]
        public Nullable<DateTime> DateConst { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_OA__DATE_MS",Order=21)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Voie portée ou franchie")]
        [Column("DSC_OA__VPF",Order=22)]
        [MaxLength(60)] 
        public String Vpf { get; set; }
        
        [Description("Trafic Voie portée")]
        [Column("DSC_OA__TRAFIC_VPF",Order=23)]
        public Nullable<Int64> TraficVpf { get; set; }
        
        [Description("Longueur déviation (km)")]
        [Column("DSC_OA__DEVIATION",Order=24)]
        public Nullable<Double> Deviation { get; set; }
        
        [Description("Nb piles intermédiaires")]
        [Column("DSC_OA__NBPILESINTER",Order=25)]
        public Nullable<Int64> Nbpilesinter { get; set; }
        
        [Description("Nombre de travée")]
        [Column("DSC_OA__TRAVURE",Order=26)]
        public Nullable<Int64> Travure { get; set; }
        
        [Description("Long max travée (m)")]
        [Column("DSC_OA__LONG_MAX_TRAV",Order=27)]
        public Nullable<Double> LongMaxTrav { get; set; }
        
        [Description("Gabarit (m)")]
        [Column("DSC_OA__GAB_MINI",Order=28)]
        public Nullable<Double> GabMini { get; set; }
        
        [Description("Gabarit GRA")]
        [Column("DSC_OA__GAB_GRA",Order=29)]
        public Nullable<Boolean> GabGra { get; set; }
        
        [Description("Biais (grad)")]
        [Column("DSC_OA__BIAIS",Order=30)]
        public Nullable<Int64> Biais { get; set; }
        
        [Description("Longueur biaise (m)")]
        [Column("DSC_OA__LONG_BIAISE",Order=31)]
        public Nullable<Double> LongBiaise { get; set; }
        
        [Description("Largeur droite (m)")]
        [Column("DSC_OA__LARG_TRAV",Order=32)]
        public Nullable<Double> LargTrav { get; set; }
        
        [Description("Largeur entre bordure (m)")]
        [Column("DSC_OA__LARG_BIAISE",Order=33)]
        public Nullable<Double> LargBiaise { get; set; }
        
        [Description("Largeur entre GS (m)")]
        [Column("DSC_OA__LARG_GS",Order=34)]
        public Nullable<Double> LargGs { get; set; }
        
        [Description("Surface tablier (m²)")]
        [Column("DSC_OA__SURF_TABLIER",Order=35)]
        public Nullable<Double> SurfTablier { get; set; }
        
        [Description("Surf voie (m²)")]
        [Column("DSC_OA__SURF_VPF",Order=36)]
        public Nullable<Double> SurfVpf { get; set; }
        
        [Description("Fondation immergé")]
        [Column("DSC_OA__IMMERGE",Order=37)]
        public Nullable<Boolean> Immerge { get; set; }
        
        [Description("Sismicité")]
        [Column("DSC_OA__SISMICITE",Order=38)]
        public Nullable<Boolean> Sismicite { get; set; }
        
        [Description("Dalle de transition")]
        [Column("DSC_OA__DALLE",Order=39)]
        public Nullable<Boolean> Dalle { get; set; }
        
        [Description("Corniche")]
        [Column("DSC_OA__CORN",Order=40)]
        public Nullable<Boolean> Corn { get; set; }
        
        [Description("Lanterneau")]
        [Column("DSC_OA__LANTERNEAU",Order=41)]
        public Nullable<Boolean> Lanterneau { get; set; }
        
        [Description("Equipement de visite")]
        [Column("DSC_OA__EQUIP_VST",Order=42)]
        public Nullable<Boolean> EquipVst { get; set; }
        
        [Description("Note Appuis / Fondations")]
        [Column("DSC_OA__NOTE1",Order=43)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Tabliers")]
        [Column("DSC_OA__NOTE2",Order=44)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Equipement")]
        [Column("DSC_OA__NOTE3",Order=45)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("DSC_OA__URGENCE",Order=46)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DSC_OA__DESC_INVA",Order=47)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("DSC_OA__SECURITE",Order=48)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence Traitement")]
        [Column("DSC_OA__PRIORITAIRE",Order=49)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("DSC_OA__PROSURV_ANNEE",Order=50)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DSC_OA__DERN_INSP",Order=51)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DSC_OA__DERN_VST",Order=52)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("DSC_OA__NOTE_VST",Order=53)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("DSC_OA__ARCHIVE",Order=54)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_OA__COMMENTAIRE",Order=55)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("DSC_OA__X1",Order=56)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("DSC_OA__Y1",Order=57)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("DSC_OA__Z1",Order=58)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("X2")]
        [Column("DSC_OA__X2",Order=59)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("DSC_OA__Y2",Order=60)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("DSC_OA__Z2",Order=61)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("Date relevé")]
        [Column("DSC_OA__DATE_RELEVE",Order=62)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("DSC_OA__TERRAIN",Order=63)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
