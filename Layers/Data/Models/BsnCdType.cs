using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_BSN",Schema="BSN")]
    public partial class BsnCdType
    {
        [Key]
        [Description("Sensibilité du milieu")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
