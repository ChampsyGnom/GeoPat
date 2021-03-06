using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EXT_AV_EQP",Schema="EQP")]
    public partial class EqpCdExtAv
    {
        [Key]
        [Description("Extrémité fin")]
        [Column("EXT_FIN",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String ExtFin { get; set; }
        
    }
}
