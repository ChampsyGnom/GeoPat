using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ACCES_BSN",Schema="BSN")]
    public partial class BsnCdAcces
    {
        [Key]
        [Description("Voie d'accès")]
        [Column("VACCES",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Vacces { get; set; }
        
    }
}
