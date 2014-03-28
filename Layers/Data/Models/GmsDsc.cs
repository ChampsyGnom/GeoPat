using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_GMS",Schema="GMS")]
    public partial class GmsDsc
    {
        public virtual GmsCdFam GmsCdFam {get;set;}
        
        public virtual GmsCdEntp GmsCdEntp {get;set;}
        
        public virtual GmsCdPoutre GmsCdPoutre {get;set;}
        
        public virtual GmsCdType GmsCdType {get;set;}
        
        public virtual GmsCdAncrage GmsCdAncrage {get;set;}
        
        public virtual GmsCdAcces GmsCdAcces {get;set;}
        
        public virtual GmsCdPosMat GmsCdPosMat {get;set;}
        
        public virtual GmsCdQualite GmsCdQualite {get;set;}
        
        public virtual GmsCdProtec GmsCdProtec {get;set;}
        
        public virtual GmsCdInterface GmsCdInterface {get;set;}
        
        public virtual GmsCdFournisseur GmsCdFournisseur {get;set;}
        
        public virtual GmsCdPoteau GmsCdPoteau {get;set;}
        
        public virtual ICollection<GmsTravaux> GmsTravauxs { get; set; }
        
        public virtual ICollection<GmsPrevision> GmsPrevisions { get; set; }
        
        public virtual ICollection<GmsInsp> GmsInsps { get; set; }
        
        public virtual ICollection<GmsVst> GmsVsts { get; set; }
        
        public virtual ICollection<GmsHistoNote> GmsHistoNotes { get; set; }
        
        public virtual ICollection<GmsEvt> GmsEvts { get; set; }
        
        public virtual ICollection<GmsDscTemp> GmsDscTemps { get; set; }
        
        public virtual ICollection<GmsDscCamp> GmsDscCamps { get; set; }
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String NumGms { get; set; }
        
        [Description("Type Poteau")]
        [Column("CD_POTEAU_GMS__TYPE",Order=1)]
        [MaxLength(60)] 
        public String CdPoteauGmsType { get; set; }
        
        [Description("Position")]
        [Column("CD_POS_MAT_GMS__POSIT",Order=2)]
        [Required()]
        [MaxLength(4)] 
        public String CdPosMatGmsPosit { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_GMS__ENTREPRISE",Order=3)]
        [MaxLength(60)] 
        public String CdEntpGmsEntreprise { get; set; }
        
        [Description("Type ancrage")]
        [Column("CD_ANCRAGE_GMS__TYPE",Order=4)]
        [MaxLength(60)] 
        public String CdAncrageGmsType { get; set; }
        
        [Description("Type Accès visite")]
        [Column("CD_ACCES_GMS__TYPE",Order=5)]
        [MaxLength(60)] 
        public String CdAccesGmsType { get; set; }
        
        [Description("Type Traverse")]
        [Column("CD_POUTRE_GMS__TYPE",Order=6)]
        [MaxLength(60)] 
        public String CdPoutreGmsType { get; set; }
        
        [Description("Fournisseur")]
        [Column("CD_FOURNISSEUR_GMS__NOM",Order=7)]
        [MaxLength(60)] 
        public String CdFournisseurGmsNom { get; set; }
        
        [Description("Famille")]
        [Column("CD_FAM_GMS__FAMILLE",Order=8)]
        [Required()]
        [MaxLength(20)] 
        public String CdFamGmsFamille { get; set; }
        
        [Description("Type Ouvrage")]
        [Column("CD_TYPE_GMS__TYPE",Order=9)]
        [MaxLength(60)] 
        public String CdTypeGmsType { get; set; }
        
        [Description("Type de liaison GMS")]
        [Column("CD_INTERFACE_GMS__TYPE",Order=10)]
        [MaxLength(60)] 
        public String CdInterfaceGmsType { get; set; }
        
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_GMS__QUALITE",Order=11)]
        [MaxLength(25)] 
        public String CdQualiteGmsQualite { get; set; }
        
        [Description("Type protection")]
        [Column("CD_PROTEC_GMS__PROTEC",Order=12)]
        [MaxLength(60)] 
        public String CdProtecGmsProtec { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_GMS__LIAISON",Order=13)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_GMS__SENS",Order=14)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR")]
        [Column("DSC_GMS__ABS_DEB",Order=15)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("DSC_GMS__NUM_EXPLOIT",Order=16)]
        [MaxLength(17)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("DSC_GMS__NOM_USAGE",Order=17)]
        [MaxLength(255)] 
        public String NomUsage { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_GMS__DATE_MS",Order=18)]
        [Required()]
        public DateTime DateMs { get; set; }
        
        [Description("Gabarit sous structure (m)")]
        [Column("DSC_GMS__HAUT",Order=19)]
        public Nullable<Double> Haut { get; set; }
        
        [Description("Gabarit sous panneau (m)")]
        [Column("DSC_GMS__TIRAIR",Order=20)]
        public Nullable<Double> Tirair { get; set; }
        
        [Description("Résistance au vent (km/h)")]
        [Column("DSC_GMS__VENT",Order=21)]
        public Nullable<Int64> Vent { get; set; }
        
        [Description("dimension Massif Ancrage (cm)")]
        [Column("DSC_GMS__ANCRAGE",Order=22)]
        [MaxLength(60)] 
        public String Ancrage { get; set; }
        
        [Description("Portée (m)")]
        [Column("DSC_GMS__LARG",Order=23)]
        public Nullable<Double> Larg { get; set; }
        
        [Description("Nbr traverse")]
        [Column("DSC_GMS__TRAVERSE",Order=24)]
        public Nullable<Int64> Traverse { get; set; }
        
        [Description("Nbr élément de traverse")]
        [Column("DSC_GMS__ELEMENT",Order=25)]
        public Nullable<Int64> Element { get; set; }
        
        [Description("Nbr poteaux")]
        [Column("DSC_GMS__NB_POTEAUX",Order=26)]
        public Nullable<Int64> NbPoteaux { get; set; }
        
        [Description("Eclairage")]
        [Column("DSC_GMS__ECLAIRAGE",Order=27)]
        public Nullable<Boolean> Eclairage { get; set; }
        
        [Description("Accès condamné")]
        [Column("DSC_GMS__CONDAMNE",Order=28)]
        public Nullable<Boolean> Condamne { get; set; }
        
        [Description("Note Ancrage")]
        [Column("DSC_GMS__NOTE1",Order=29)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Structure")]
        [Column("DSC_GMS__NOTE2",Order=30)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Fixation")]
        [Column("DSC_GMS__NOTE3",Order=31)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Panneau")]
        [Column("DSC_GMS__NOTE4",Order=32)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Accessibilité")]
        [Column("DSC_GMS__NOTE5",Order=33)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("DSC_GMS__URGENCE",Order=34)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Description invalide")]
        [Column("DSC_GMS__DESC_INVA",Order=35)]
        [MaxLength(1000)] 
        public String DescInva { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("DSC_GMS__SECURITE",Order=36)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("DSC_GMS__PRIORITAIRE",Order=37)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
        [Description("Prochaine Inspection")]
        [Column("DSC_GMS__PROSURV_ANNEE",Order=38)]
        public Nullable<Int64> ProsurvAnnee { get; set; }
        
        [Description("Dernière Inspection")]
        [Column("DSC_GMS__DERN_INSP",Order=39)]
        public Nullable<DateTime> DernInsp { get; set; }
        
        [Description("Dernière Visite")]
        [Column("DSC_GMS__DERN_VST",Order=40)]
        public Nullable<DateTime> DernVst { get; set; }
        
        [Description("Note Visite")]
        [Column("DSC_GMS__NOTE_VST",Order=41)]
        [MaxLength(5)] 
        public String NoteVst { get; set; }
        
        [Description("Archive")]
        [Column("DSC_GMS__ARCHIVE",Order=42)]
        [MaxLength(255)] 
        public String Archive { get; set; }
        
        [Description("Commentaire")]
        [Column("DSC_GMS__COMMENTAIRE",Order=43)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
        [Description("X1")]
        [Column("DSC_GMS__X1",Order=44)]
        public Nullable<Double> X1 { get; set; }
        
        [Description("Y1")]
        [Column("DSC_GMS__Y1",Order=45)]
        public Nullable<Double> Y1 { get; set; }
        
        [Description("Z1")]
        [Column("DSC_GMS__Z1",Order=46)]
        public Nullable<Double> Z1 { get; set; }
        
        [Description("Date relevé")]
        [Column("DSC_GMS__DATE_RELEVE",Order=47)]
        public Nullable<DateTime> DateReleve { get; set; }
        
        [Description("Terrain")]
        [Column("DSC_GMS__TERRAIN",Order=48)]
        public Nullable<Boolean> Terrain { get; set; }
        
    }
}
