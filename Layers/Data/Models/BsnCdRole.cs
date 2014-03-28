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
        public virtual ICollection<BsnCdRoleDsc> BsnCdRoleDscs { get; set; }
        
        [Key]
        [Description("Rôle")]
        [Column("CD_ROLE_BSN__ROLE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Role { get; set; }
        
    }
}
