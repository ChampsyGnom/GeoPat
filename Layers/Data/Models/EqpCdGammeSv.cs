using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_GAMME_SV_EQP",Schema="EQP")]
    public partial class EqpCdGammeSv
    {
        [Key]
        [Description("Gamme")]
        [Column("GAMME",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Gamme { get; set; }
        
        [Description("Dimension (mm)")]
        [Column("DIMENSION",Order=1)]
        public Nullable<Int64> Dimension { get; set; }
        
    }
}
