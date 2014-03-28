using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_OA",Schema="OA")]
    public partial class OaBpu
    {
        public virtual OaCdTravaux OaCdTravaux {get;set;}
        
        public virtual OaCdUnite OaCdUnite {get;set;}
        
        public virtual ICollection<OaPrevision> OaPrevisions { get; set; }
        
        public virtual ICollection<OaCdPrecoSprtVst> OaCdPrecoSprtVsts { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_OA__ID_BPU",Order=0)]
        [Required()]
        public Int64 IdBpu { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_OA__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxOaCode { get; set; }
        
        [Description("Unité")]
        [Column("CD_UNITE_OA__UNITE",Order=2)]
        [MaxLength(12)] 
        public String CdUniteOaUnite { get; set; }
        
        [Description("Technique")]
        [Column("BPU_OA__TECHN",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Techn { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("BPU_OA__PRIX",Order=4)]
        [Required()]
        public Int64 Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("BPU_OA__DATE_MAJ",Order=5)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (mois)")]
        [Column("BPU_OA__FREQ",Order=6)]
        public Nullable<Int64> Freq { get; set; }
        
        [Description("Préconisation Visite")]
        [Column("BPU_OA__PRECO_VST",Order=7)]
        public Nullable<Boolean> PrecoVst { get; set; }
        
        [Description("Entretien réalisable")]
        [Column("BPU_OA__REALIS_VST",Order=8)]
        public Nullable<Boolean> RealisVst { get; set; }
        
    }
}
