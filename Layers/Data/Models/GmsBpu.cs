using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_GMS",Schema="GMS")]
    public partial class GmsBpu
    {
        public virtual GmsCdTravaux GmsCdTravaux {get;set;}
        
        public virtual GmsCdUnite GmsCdUnite {get;set;}
        
        public virtual ICollection<GmsPrevision> GmsPrevisions { get; set; }
        
        public virtual ICollection<GmsCdPrecoSprtVst> GmsCdPrecoSprtVsts { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_GMS__ID_BPU",Order=0)]
        [Required()]
        public Int64 IdBpu { get; set; }
        
        [Description("Unité")]
        [Column("CD_UNITE_GMS__UNITE",Order=1)]
        [MaxLength(12)] 
        public String CdUniteGmsUnite { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_GMS__CODE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxGmsCode { get; set; }
        
        [Description("Technique")]
        [Column("BPU_GMS__TECHN",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Techn { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("BPU_GMS__PRIX",Order=4)]
        public Nullable<Int64> Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("BPU_GMS__DATE_MAJ",Order=5)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (mois)")]
        [Column("BPU_GMS__FREQ",Order=6)]
        public Nullable<Int64> Freq { get; set; }
        
        [Description("Préconisation Visite")]
        [Column("BPU_GMS__PRECO_VST",Order=7)]
        public Nullable<Boolean> PrecoVst { get; set; }
        
        [Description("Entretien réalisable")]
        [Column("BPU_GMS__REALIS_VST",Order=8)]
        public Nullable<Boolean> RealisVst { get; set; }
        
    }
}
