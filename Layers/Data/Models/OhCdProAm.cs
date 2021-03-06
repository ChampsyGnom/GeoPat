using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRO_AM_OH",Schema="OH")]
    public partial class OhCdProAm
    {
        [Key]
        [Description("Protection Amont")]
        [Column("PROTECT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Protect { get; set; }
        
    }
}
