using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CAUSE_CHS",Schema="CHS")]
    public partial class ChsCdCause
    {
        [Key]
        [Description("Cause")]
        [Column("CAUSE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Cause { get; set; }
        
    }
}
