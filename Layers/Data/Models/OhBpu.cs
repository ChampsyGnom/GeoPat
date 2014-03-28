using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_OH",Schema="OH")]
    public partial class OhBpu
    {
        public virtual OhCdTravaux OhCdTravaux {get;set;}
        
        public virtual OhCdUnite OhCdUnite {get;set;}
        
        public virtual ICollection<OhPrevision> OhPrevisions { get; set; }
        
        public virtual ICollection<OhCdPrecoSprtVst> OhCdPrecoSprtVsts { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_OH__ID_BPU",Order=0)]
        [Required()]
        public Int64 IdBpu { get; set; }
        
        [Description("Unité")]
        [Column("CD_UNITE_OH__UNITE",Order=1)]
        [MaxLength(12)] 
        public String CdUniteOhUnite { get; set; }
        
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_OH__CODE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxOhCode { get; set; }
        
        [Description("Technique")]
        [Column("BPU_OH__TECHN",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Techn { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("BPU_OH__PRIX",Order=4)]
        public Nullable<Int64> Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("BPU_OH__DATE_MAJ",Order=5)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (mois)")]
        [Column("BPU_OH__FREQ",Order=6)]
        public Nullable<Int64> Freq { get; set; }
        
        [Description("Préconisation Visite")]
        [Column("BPU_OH__PRECO_VST",Order=7)]
        public Nullable<Boolean> PrecoVst { get; set; }
        
        [Description("Entretien réalisable")]
        [Column("BPU_OH__REALIS_VST",Order=8)]
        public Nullable<Boolean> RealisVst { get; set; }
        
    }
}
