using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TABLIER_OA",Schema="OA")]
    public partial class OaTablier
    {
        public virtual OaCdChape OaCdChape {get;set;}
        
        public virtual OaCdTech OaCdTech {get;set;}
        
        public virtual OaCdEntp OaCdEntp {get;set;}
        
        public virtual ICollection<OaJoint> OaJoints { get; set; }
        
        public virtual ICollection<OaEquipement> OaEquipements { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("N° Tablier")]
        [Column("TABLIER_OA__NUM_TAB",Order=1)]
        [Required()]
        public Int64 NumTab { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_OA__ENTREPRISE",Order=2)]
        [MaxLength(60)] 
        public String CdEntpOaEntreprise { get; set; }
        
        [Description("Technique")]
        [Column("CD_TECH_OA__TECHNIQUE",Order=3)]
        [MaxLength(12)] 
        public String CdTechOaTechnique { get; set; }
        
        [Description("Type chape d'étanchéité")]
        [Column("CD_CHAPE_OA__CHAPE",Order=4)]
        [MaxLength(60)] 
        public String CdChapeOaChape { get; set; }
        
        [Description("Date MS chape")]
        [Column("TABLIER_OA__DATE_MS_CHAPE",Order=5)]
        public Nullable<DateTime> DateMsChape { get; set; }
        
        [Description("Surf chape (m²)")]
        [Column("TABLIER_OA__SURF_CHAPE",Order=6)]
        public Nullable<Double> SurfChape { get; set; }
        
        [Description("Epaisseur Chape (cm)")]
        [Column("TABLIER_OA__EPAIS_CHAPE",Order=7)]
        public Nullable<Double> EpaisChape { get; set; }
        
        [Description("Date_MS Enrobé")]
        [Column("TABLIER_OA__DATE_MS_BB",Order=8)]
        public Nullable<DateTime> DateMsBb { get; set; }
        
        [Description("Epaisseur enrobé(cm)")]
        [Column("TABLIER_OA__EPAIS",Order=9)]
        public Nullable<Double> Epais { get; set; }
        
        [Description("Granulométrie")]
        [Column("TABLIER_OA__GRANULO",Order=10)]
        [MaxLength(8)] 
        public String Granulo { get; set; }
        
        [Description("Commentaire")]
        [Column("TABLIER_OA__COMMENTAIRE",Order=11)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
