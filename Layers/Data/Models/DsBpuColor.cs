using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BPU_COLOR_DS",Schema="DS")]
    public partial class DsBpuColor
    {
        [Key]
        [Description("BPU_COLOR_DS__CODE")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(30)] 
        public String Code { get; set; }
        
        [Description("BPU_COLOR_DS__COLOR")]
        [Column("COLOR",Order=1)]
        [MaxLength(11)] 
        public String Color { get; set; }
        
    }
}
