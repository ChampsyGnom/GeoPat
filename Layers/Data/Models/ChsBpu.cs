using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_CHS",Schema="CHS")]
    public partial class ChsBpu
    {
        [Key]
        [Description("Technique")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Code { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_CHS__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxChsCode { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(250)] 
        public String Libelle { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("PRIX",Order=3)]
        public Nullable<Int64> Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("DATE_MAJ",Order=4)]
        public Nullable<DateTime> DateMaj { get; set; }
        
    }
}
