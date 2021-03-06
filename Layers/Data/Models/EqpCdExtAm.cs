using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EXT_AM_EQP",Schema="EQP")]
    public partial class EqpCdExtAm
    {
        [Key]
        [Description("Extrémité début")]
        [Column("EXT_DEB",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String ExtDeb { get; set; }
        
    }
}
