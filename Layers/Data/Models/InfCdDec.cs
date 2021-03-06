using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_DEC_INF",Schema="INF")]
    public partial class InfCdDec
    {
        [Key]
        [Description("Code famille")]
        [Column("FAM_DEC_INF__FAM_DEC",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String FamDecInfFamDec { get; set; }
        
        [Key]
        [Description("Code decoupage")]
        [Column("CD_DEC",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDec { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
