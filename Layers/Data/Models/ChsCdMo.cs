using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MO_CHS",Schema="CHS")]
    public partial class ChsCdMo
    {
        [Key]
        [Description("Maître d'oeuvre")]
        [Column("MO",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Mo { get; set; }
        
    }
}
