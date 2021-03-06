using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAILLE_EQP",Schema="EQP")]
    public partial class EqpCdMaille
    {
        [Key]
        [Description("Maille")]
        [Column("MAILLE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Maille { get; set; }
        
    }
}
