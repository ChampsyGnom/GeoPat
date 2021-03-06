using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ROLE_BSN",Schema="BSN")]
    public partial class BsnCdRole
    {
        [Key]
        [Description("Rôle")]
        [Column("ROLE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Role { get; set; }
        
    }
}
