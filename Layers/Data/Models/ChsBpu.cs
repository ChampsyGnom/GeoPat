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
        public virtual ChsCdTravaux ChsCdTravaux {get;set;}
        
        public virtual ICollection<ChsPrevision> ChsPrevisions { get; set; }
        
        [Key]
        [Description("Technique")]
        [Column("BPU_CHS__CODE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Code { get; set; }
        
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_CHS__CODE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxChsCode { get; set; }
        
        [Description("Libellé")]
        [Column("BPU_CHS__LIBELLE",Order=2)]
        [MaxLength(250)] 
        public String Libelle { get; set; }
        
        [Description("Prix Unitaire (€)")]
        [Column("BPU_CHS__PRIX",Order=3)]
        public Nullable<Int64> Prix { get; set; }
        
        [Description("Date MAJ")]
        [Column("BPU_CHS__DATE_MAJ",Order=4)]
        public Nullable<DateTime> DateMaj { get; set; }
        
    }
}
