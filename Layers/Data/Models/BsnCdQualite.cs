using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_QUALITE_BSN",Schema="BSN")]
    public partial class BsnCdQualite
    {
        public virtual ICollection<BsnSeuilQualite> BsnSeuilQualites { get; set; }
        
        public virtual ICollection<BsnDsc> BsnDscs { get; set; }
        
        [Key]
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_BSN__QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
