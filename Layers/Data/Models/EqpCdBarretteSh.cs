using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_BARRETTE_SH_EQP",Schema="EQP")]
    public partial class EqpCdBarretteSh
    {
        [Key]
        [Description("Barette")]
        [Column("BARETTE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Barette { get; set; }
        
    }
}
