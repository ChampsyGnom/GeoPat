using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_EQP",Schema="EQP")]
    public partial class EqpBpu
    {
        [Key]
        [Description("Technique")]
        [Column("TECHN",Order=0)]
        [Required()]
        [MaxLength(250)] 
        public String Techn { get; set; }
        
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_EQP__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxEqpCode { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("PRIX",Order=2)]
        [Required()]
        public Int64 Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("DATE_MAJ",Order=3)]
        public Nullable<DateTime> DateMaj { get; set; }
        
        [Description("Fréquence (Mois)")]
        [Column("FREQ",Order=4)]
        public Nullable<Int64> Freq { get; set; }
        
    }
}
