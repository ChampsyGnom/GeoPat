using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_BSN",Schema="BSN")]
    public partial class BsnBpu
    {
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("ID_BPU",Order=0)]
        [Required()]
        public Int64 IdBpu { get; set; }
        
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_BSN__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxBsnCode { get; set; }
        
        [Description("Unité")]
        [Column("CD_UNITE_BSN__UNITE",Order=2)]
        [MaxLength(12)] 
        public String CdUniteBsnUnite { get; set; }
        
        [Description("Technique")]
        [Column("TECHN",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Techn { get; set; }
        
        [Description("Prix Unitaire")]
        [Column("PRIX",Order=4)]
        public Nullable<Int64> Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("DATE_MAJ",Order=5)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (mois)")]
        [Column("FREQ",Order=6)]
        public Nullable<Int64> Freq { get; set; }
        
        [Description("Préconisation Visite")]
        [Column("PRECO_VST",Order=7)]
        public Nullable<Boolean> PrecoVst { get; set; }
        
        [Description("Entretien réalisable")]
        [Column("REALIS_VST",Order=8)]
        public Nullable<Boolean> RealisVst { get; set; }
        
    }
}
