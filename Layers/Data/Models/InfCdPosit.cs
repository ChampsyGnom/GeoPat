using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_POSIT_INF",Schema="INF")]
    public partial class InfCdPosit
    {
        [Key]
        [Description("Position")]
        [Column("POSIT",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Posit { get; set; }
        
        [Description("N° Ordre")]
        [Column("ORDRE",Order=1)]
        public Nullable<Int64> Ordre { get; set; }
        
    }
}
