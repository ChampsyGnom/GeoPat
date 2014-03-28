using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_GOT",Schema="GOT")]
    public partial class GotBpu
    {
        public virtual GotCdTravaux GotCdTravaux {get;set;}
        
        public virtual GotCdUnite GotCdUnite {get;set;}
        
        public virtual ICollection<GotPrevision> GotPrevisions { get; set; }
        
        public virtual ICollection<GotCdPrecoSprtVst> GotCdPrecoSprtVsts { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_GOT__ID_BPU",Order=0)]
        [Required()]
        public Int64 IdBpu { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_GOT__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxGotCode { get; set; }
        
        [Description("Unité")]
        [Column("CD_UNITE_GOT__UNITE",Order=2)]
        [MaxLength(12)] 
        public String CdUniteGotUnite { get; set; }
        
        [Description("Technique")]
        [Column("BPU_GOT__TECHN",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Techn { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("BPU_GOT__PRIX",Order=4)]
        [Required()]
        public Int64 Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("BPU_GOT__DATE_MAJ",Order=5)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (mois)")]
        [Column("BPU_GOT__FREQ",Order=6)]
        public Nullable<Int64> Freq { get; set; }
        
        [Description("Préconisation Visite")]
        [Column("BPU_GOT__PRECO_VST",Order=7)]
        public Nullable<Boolean> PrecoVst { get; set; }
        
        [Description("Entretien réalisable")]
        [Column("BPU_GOT__REALIS_VST",Order=8)]
        public Nullable<Boolean> RealisVst { get; set; }
        
    }
}
