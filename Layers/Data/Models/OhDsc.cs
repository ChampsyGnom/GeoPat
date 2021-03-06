using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_OH",Schema="OH")]
    public partial class OhDsc
    {
        [Key]
        [Description("NumOH")]
        [Column("NUM_OH",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String NumOh { get; set; }
        
        [Description("Matériaux")]
        [Column("CD_MAT_OH__CODE",Order=1)]
        [MaxLength(60)] 
        public String CdMatOhCode { get; set; }
        
        [Description("Tête aval")]
        [Column("CD_TETE_AV_OH__TETE_AV",Order=2)]
        [MaxLength(60)] 
        public String CdTeteAvOhTeteAv { get; set; }
        
        [Description("Profil")]
        [Column("CD_OUV_OH__OUV",Order=3)]
        [MaxLength(60)] 
        public String CdOuvOhOuv { get; set; }
        
        [Description("Ecoulement")]
        [Column("CD_ECOUL_OH__ECOUL",Order=4)]
        [MaxLength(60)] 
        public String CdEcoulOhEcoul { get; set; }
        
        [Description("Type exutoire")]
        [Column("CD_EXT_OH__TYPE",Order=5)]
        [MaxLength(60)] 
        public String CdExtOhType { get; set; }
        
        [Description("Eaux collectées")]
        [Column("CD_EAU_OH__EAU",Order=6)]
        [MaxLength(60)] 
        public String CdEauOhEau { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_OH__ENTREPRISE",Order=7)]
        [MaxLength(60)] 
        public String CdEntpOhEntreprise { get; set; }
        
        [Description("Type OH")]
        [Column("CD_TYPE_OH__TYPE",Order=8)]
        [Required()]
        [MaxLength(60)] 
        public String CdTypeOhType { get; set; }
        
        [Description("Protection Aval")]
        [Column("CD_PRO_AV_OH__PROTECT",Order=9)]
        [MaxLength(60)] 
        public String CdProAvOhProtect { get; set; }
        
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_OH__QUALITE",Order=10)]
        [MaxLength(25)] 
        public String CdQualiteOhQualite { get; set; }
        
        [Description("Maitre d'ouvrage")]
        [Column("CD_MO_OH__MO",Order=11)]
        [MaxLength(60)] 
        public String CdMoOhMo { get; set; }
        
        [Description("Tête amont")]
        [Column("CD_TETE_AM_OH__TETE_AM",Order=12)]
        [MaxLength(60)] 
        public String CdTeteAmOhTeteAm { get; set; }
        
        [Description("Nom cours d'eau")]
        [Column("CD_NOM_EAU_OH__NOM",Order=13)]
        [MaxLength(60)] 
        public String CdNomEauOhNom { get; set; }
        
        [Description("Sous type OH")]
        [Column("CD_SOUS_TYPE_OH__SOUS_TYPE",Order=14)]
        [MaxLength(60)] 
        public String CdSousTypeOhSousType { get; set; }
        
        [Description("Protection Amont")]
        [Column("CD_PRO_AM_OH__PROTECT",Order=15)]
        [MaxLength(60)] 
        public String CdProAmOhProtect { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_OH__FAMILLE",Order=16)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamOhFamille { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=17)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=18)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR")]
        [Column("ABS_DEB",Order=19)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Pr fin")]
        [Column("ABS_FIN",Order=20)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("NUM_EXPLOIT",Order=21)]
        [MaxLength(30)] 
        public String NumExploit { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=22)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Longueur (m)")]
        [Column("LONGUEUR",Order=23)]
        public Nullable<Double> Longueur { get; set; }
        
        [Description("Hauteur (mm)")]
        [Column("HAUTEUR",Order=24)]
        public Nullable<Int64> Hauteur { get; set; }
        
        [Description("Biais (degré)")]
        [Column("BIAIS",Order=25)]
        public Nullable<Int64> Biais { get; set; }
        
        [Description("Pente (%)")]
        [Column("PENTE",Order=26)]
        public Nullable<Double> Pente { get; set; }
        
        [Description("Portée - Ø (mm)")]
        [Column("PORTEE",Order=27)]
        public Nullable<Int64> Portee { get; set; }
        
        [Description("Jumellé")]
        [Column("JUM",Order=28)]
        public Nullable<Int64> Jum { get; set; }
        
        [Description("Nbre élément")]
        [Column("ELEM",Order=29)]
        public Nullable<Int64> Elem { get; set; }
        
        [Description("Nbre regard")]
        [Column("REGARD",Order=30)]
        public Nullable<Int64> Regard { get; set; }
        
        [Description("Ouvrage Perché")]
        [Column("PERCHE",Order=31)]
        public Nullable<Boolean> Perche { get; set; }
        
        [Description("Vulnérabilité")]
        [Column("VULNERABLE",Order=32)]
        public Nullable<Boolean> Vulnerable { get; set; }
        
        [Description("Aménagement petite faune")]
        [Column("FAUNE",Order=33)]
        public Nullable<Boolean> Faune { get; set; }
        
        [Description("Loi sur l'eau")]
        [Column("LOI",Order=34)]
        public Nullable<Boolean> Loi { get; set; }
        
        [Description("Niveau PHE (mm)")]
        [Column("PHE",Order=35)]
        public Nullable<Int64> Phe { get; set; }
        
        [Description("Débit-projet")]
        [Column("DEBIT",Order=36)]
        public Nullable<Int64> Debit { get; set; }
        
        [Description("Connexion Aval")]
        [Column("OUV_AVAL",Order=37)]
        [MaxLength(200)] 
        public String OuvAval { get; set; }
        
        [Description("Note Abords Amont")]
        [Column("NOTE1",Order=38)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Protection Amont")]
        [Column("NOTE2",Order=39)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Conduit")]
        [Column("NOTE3",Order=40)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Protection Aval")]
        [Column("NOTE4",Order=41)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Abord Aval")]
        [Column("NOTE5",Order=42)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=43)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DESC_INVA",Order=44)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=45)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=46)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("PROSURV_ANNEE",Order=47)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DERN_INSP",Order=48)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DERN_VST",Order=49)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("NOTE_VST",Order=50)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("ARCHIVE",Order=51)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=52)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("X1",Order=53)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("Y1",Order=54)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("Z1",Order=55)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("X2")]
        [Column("X2",Order=56)]
        public Nullable<Double> X2 { get; set; }
        
        [Description("Y2")]
        [Column("Y2",Order=57)]
        public Nullable<Double> Y2 { get; set; }
        
        [Description("Z2")]
        [Column("Z2",Order=58)]
        public Nullable<Double> Z2 { get; set; }
        
        [Description("Date relevé")]
        [Column("DATE_RELEVE",Order=59)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("TERRAIN",Order=60)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
