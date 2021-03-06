using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_STYPE_SV_EQP",Schema="EQP")]
    public partial class EqpCdStypeSv
    {
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_SV_EQP__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String CdFamSvEqpFamille { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_TYPE_SV_EQP__TYPE",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String CdTypeSvEqpType { get; set; }
        
        [Key]
        [Description("Sous type")]
        [Column("S_TYPE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String SType { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=3)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("Num Ordre")]
        [Column("N_ORDRE",Order=4)]
        [Required()]
        public Int64 NOrdre { get; set; }
        
    }
}
