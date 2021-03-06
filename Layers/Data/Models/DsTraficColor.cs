using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAFIC_COLOR_DS",Schema="DS")]
    public partial class DsTraficColor
    {
        [Key]
        [Description("TRAFIC_COLOR_DS__CODE")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(10)] 
        public String Code { get; set; }
        
        [Description("TRAFIC_COLOR_DS__COLOR")]
        [Column("COLOR",Order=1)]
        [MaxLength(11)] 
        public String Color { get; set; }
        
    }
}
