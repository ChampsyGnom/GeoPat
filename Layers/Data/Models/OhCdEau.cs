using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EAU_OH",Schema="OH")]
    public partial class OhCdEau
    {
        [Key]
        [Description("Eaux collectées")]
        [Column("EAU",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Eau { get; set; }
        
    }
}
