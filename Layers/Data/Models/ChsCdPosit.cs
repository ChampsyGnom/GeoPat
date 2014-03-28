using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_POSIT_CHS",Schema="CHS")]
    public partial class ChsCdPosit
    {
        [Key]
        [Description("Position")]
        [Column("POSIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Posit { get; set; }
        
    }
}
