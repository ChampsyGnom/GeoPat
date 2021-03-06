using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MO_OH",Schema="OH")]
    public partial class OhCdMo
    {
        [Key]
        [Description("Maitre d'ouvrage")]
        [Column("MO",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Mo { get; set; }
        
    }
}
